using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Signatures;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFeSignHandwritten
{
    public partial class fMain : Form
    {
        public string PDFPathToOpenAtStart = "";

        PdfReader PDFReader;
        PdfDocument PDFDocument;
        private string PDFPath;
        private int PageCurrent=0;

        // Visual rectangle drawing
        private Point startPos;
        private Point currentPos;
        private bool drawing;
        private Rectangle signingArea;

        // Signing rectangle coordinates
        private Int32 X1;
        private Int32 Y1;
        private Int32 X2;
        private Int32 Y2;

        private fSign frmSign;

        public fMain()
        {
            X1 = Y1 = X2 = Y2 = -1;

            InitializeComponent();
        }

        private void bttPDFOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"samples");
            dlg.Title = "Select PDF to sign";
            dlg.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                PDFPath = dlg.FileName;
                PDFReader = new PdfReader(PDFPath);
                PDFDocument = new PdfDocument(PDFReader);
                Cursor = Cursors.Default;
                PageCurrent = 1;
                ShowPage();
            }
        }

        private void ShowPage()
        {
            if (picPDF.Image != null)
            {
                picPDF.Image.Dispose();
                picPDF.Image = null;
            }
            GhostScriptConvertPage(PageCurrent);
            System.Drawing.Image img = System.Drawing.Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out.jpg"));
            picPDF.Image = img;

            lblPageInfo.Text = string.Format("{0} / {1}", PageCurrent, PDFDocument.GetNumberOfPages());
        }

        private void GhostScriptConvertPage(int PageNumber)
        {
            string outputImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out.jpg");
            string ghostScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ghostscript", "bin", "gswin32c.exe");

            if (File.Exists(outputImagesPath)) File.Delete(outputImagesPath);

            String args = String.Format("-o {0} -sDEVICE=jpeg -dJPEGQ=100 -r150 -dFirstPage={1} -dLastPage={2} {3}", outputImagesPath, PageNumber, PageNumber, PDFPath);
            Process proc = new Process();
            proc.StartInfo.FileName = ghostScriptPath;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            string strOutput = proc.StandardOutput.ReadToEnd();
            Console.WriteLine(strOutput);
            proc.WaitForExit();
        }

        private void bttPagePrev_Click(object sender, EventArgs e)
        {
            if (PageCurrent >1)
            {
                Cursor = Cursors.WaitCursor;
                PageCurrent--;
                ShowPage();
                Cursor = Cursors.Default;
            }
        }

        private void bttPageNext_Click(object sender, EventArgs e)
        {
            if (PageCurrent < PDFDocument.GetNumberOfPages())
            {
                Cursor = Cursors.WaitCursor;
                PageCurrent++;
                ShowPage();
                Cursor = Cursors.Default;
            }
        }

        private void picPDF_MouseDown(object sender, MouseEventArgs e)
        {
            if (picPDF.Image == null) return;

            currentPos = e.Location;
            startPos = currentPos;
            drawing = true;
            signingArea = new Rectangle();

            if (e.Button == MouseButtons.Left)
            {
                CoordsCalculate(e.X, e.Y, ref X1, ref Y1);
            }
        }

        private void picPDF_MouseMove(object sender, MouseEventArgs e)
        {
            if (picPDF.Image == null) return;

            currentPos = e.Location;
            if (drawing) picPDF.Invalidate();

            if (e.Button == MouseButtons.Left && drawing)
            {
                CoordsCalculate(e.X, e.Y, ref X2, ref Y2);
            }
        }

        private void picPDF_MouseUp(object sender, MouseEventArgs e)
        {
            if (picPDF.Image == null) return;

            if (drawing)
            {
                drawing = false;
                Rectangle rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0)
                {
                    signingArea = rc;
                }
            }

            CoordsCalculate(e.X, e.Y, ref X2, ref Y2);
        }

        private void picPDF_Paint(object sender, PaintEventArgs e)
        {
            if (picPDF == null) return;

            e.Graphics.DrawRectangle(Pens.Black, signingArea);
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }

        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }

        private void CoordsCalculate(Int32 mouseX, Int32 mouseY, ref Int32 X, ref Int32 Y)
        {
            Int32 realW = picPDF.Image.Width;
            Int32 realH = picPDF.Image.Height;
            Int32 currentW = picPDF.ClientRectangle.Width;
            Int32 currentH = picPDF.ClientRectangle.Height;
            Double zoomW = (currentW / (Double)realW);
            Double zoomH = (currentH / (Double)realH);
            Double zoomActual = Math.Min(zoomW, zoomH);
            Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
            Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;

            Int32 realX = (Int32)((mouseX - padX) / zoomActual);
            Int32 realY = (Int32)((mouseY - padY) / zoomActual);
            X = realX < 0 || realX > realW ? -1 : realX;
            Y = realY < 0 || realY > realH ? -1 : realY;
        }

        private void bttPDFSign_Click(object sender, EventArgs e)
        {
            if (PDFPath == null)
            {
                MessageBox.Show("First you need to open a PDF to sign", "PDF Sign", MessageBoxButtons.OK);
                return;
            }

            if (X1==-1 || Y1==-1 || X2==-1 || Y2 == -1)
            {
                MessageBox.Show("First you need to draw a rectangle on the page", "PDF Sign", MessageBoxButtons.OK);
                return;
            }

            Cursor = Cursors.WaitCursor;

            if (frmSign == null) frmSign = new fSign();
            frmSign.ShowDialog();

            if (frmSign.sign)
            {
                Int32 t;
                Int32 pagewidth = (int)PDFDocument.GetPage(PageCurrent).GetPageSizeWithRotation().GetWidth();
                Int32 pageheight = (int)PDFDocument.GetPage(PageCurrent).GetPageSizeWithRotation().GetHeight();
                Int32 x1pdf = (X1 * pagewidth) / 1240;
                Int32 y1pdf = pageheight - ((Y1 * pageheight) / 1753);
                Int32 x2pdf = (X2 * pagewidth) / 1240;
                Int32 y2pdf = pageheight - ((Y2 * pageheight) / 1753);

                if (x2pdf < x1pdf)
                {
                    t = x1pdf;
                    x2pdf = x1pdf;
                    x1pdf = t;
                }

                if (y2pdf < y1pdf)
                {
                    t = y2pdf;
                    y2pdf = y1pdf;
                    y1pdf = t;
                }

                string KEYSTORE = frmSign.txtCertificate.Text;
                char[] PASSWORD = frmSign.txtCertificatePassword.Text.ToCharArray();

                Pkcs12Store pk12 = new Pkcs12Store(new FileStream(KEYSTORE, FileMode.Open, FileAccess.Read), PASSWORD);
                string alias = null;
                foreach (object a in pk12.Aliases)
                {
                    alias = ((string)a);
                    if (pk12.IsKeyEntry(alias))
                    {
                        break;
                    }
                }
                ICipherParameters pk = pk12.GetKey(alias).Key;

                X509CertificateEntry[] ce = pk12.GetCertificateChain(alias);
                Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[ce.Length];
                for (int k = 0; k < ce.Length; ++k)
                {
                    chain[k] = ce[k].Certificate;
                }

                PdfReader PDFReaderSign = new PdfReader(PDFPath);
                PdfSigner signer = new PdfSigner(PDFReaderSign, new FileStream(frmSign.txtPDFOutput.Text, FileMode.Create), new StampingProperties());

                // Create the signature appearance
                iText.Kernel.Geom.Rectangle rect = new iText.Kernel.Geom.Rectangle(x1pdf, y1pdf, x2pdf - x1pdf, y2pdf - y1pdf);
                PdfSignatureAppearance appearance = signer.GetSignatureAppearance();
                appearance
                    .SetReason(frmSign.txtReason.Text)
                    .SetLocation(frmSign.txtLocation.Text)
                    .SetContact(frmSign.txtContactInfo.Text)
                    .SetSignatureCreator(frmSign.txtName.Text)
                    .SetImage(ImageDataFactory.Create(frmSign.picSign.Image, Color.Transparent))
                    .SetImageScale(CalculateZoomToFit(frmSign.picSign.Image, rect))
                    .SetPageRect(rect)
                    .SetPageNumber(PageCurrent);

                signer.SetSignDate(DateTime.Now);
                signer.SetFieldName("sig");

                IExternalSignature pks = new PrivateKeySignature(pk, DigestAlgorithms.SHA256);

                ITSAClient tsaClient = new TSAClientBouncyCastle(frmSign.txtTimestampServer.Text, "", "", 8192, "SHA-256");
                signer.SignDetached(pks, chain, null, null, tsaClient, 8192, PdfSigner.CryptoStandard.CMS);

                MessageBox.Show("Signed PDF saved at " + frmSign.txtPDFOutput.Text, "PDFeSignHandwritten", MessageBoxButtons.OK);
                Process.Start(frmSign.txtPDFOutput.Text);

                //reset variables
                X1 = Y1 = X2 = Y2 = -1;
                PDFDocument.Close();
                PDFDocument = null;
                PDFReader.Close();
                PDFReader = null;
                PDFReaderSign.Close();
                PDFPath = "";
                if (picPDF.Image != null)
                {
                    picPDF.Image.Dispose();
                    picPDF.Image = null;
                }
                lblPageInfo.Text = "";
                signingArea = new Rectangle();
            }

            frmSign.Dispose();
            frmSign = null;
    
            Cursor = Cursors.Default;
        }

        public float CalculateZoomToFit(System.Drawing.Image image, iText.Kernel.Geom.Rectangle targetPanel)
        {
            var panel_ratio = targetPanel.GetWidth() / targetPanel.GetHeight();
            var image_ratio = image.Width / image.Height;

            return panel_ratio > image_ratio
                 ? targetPanel.GetHeight() / image.Height
                 : targetPanel.GetWidth() / image.Width
                 ;
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PDFPathToOpenAtStart))
            {
                Cursor = Cursors.WaitCursor;
                PDFPath = PDFPathToOpenAtStart;
                PDFReader = new PdfReader(PDFPath);
                PDFDocument = new PdfDocument(PDFReader);
                Cursor = Cursors.Default;
                PageCurrent = 1;
                ShowPage();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;

namespace PDFeSignHandwritten
{
    public partial class fMain : Form
    {
        private PdfDocument PDFDoc;
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
                PDFDoc = new PdfDocument();
                PDFDoc.LoadFromFile(dlg.FileName);
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
            Image img = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out.jpg"));
            picPDF.Image = img;

            lblPageInfo.Text = string.Format("{0} / {1}", PageCurrent, PDFDoc.Pages.Count);
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
            if (PageCurrent < PDFDoc.Pages.Count)
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

            if (e.Button == MouseButtons.Left)
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
            if (PDFDoc == null)
            {
                MessageBox.Show("First you need to open a PDF to sign", "PDF Sign", MessageBoxButtons.OK);
                return;
            }

            if (X1==-1 || Y1==-1 || X2==-1 || Y2 == -1)
            {
                MessageBox.Show("First you need to draw a rectangle on the page", "PDF Sign", MessageBoxButtons.OK);
                return;
            }

            if (frmSign == null) frmSign = new fSign();
            frmSign.txtPDFOutput.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "out.pdf");
            frmSign.txtCertificate.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "sample.p12");
            frmSign.txtCertificatePassword.Text = "sample";
            frmSign.ShowDialog();

            Int32 t;
            Int32 x1pdf = (X1 * 595) / 1240;
            Int32 y1pdf = (Y1 * 842) / 1753;
            Int32 x2pdf = (X2 * 595) / 1240;
            Int32 y2pdf = (Y2 * 842) / 1753;

            if (x2pdf < x1pdf)
            {
                t = x1pdf;
                x1pdf = x2pdf;
                x2pdf = t;
            }

            if (y2pdf < y1pdf)
            {
                t = y2pdf;
                y1pdf = y2pdf;
                y2pdf = t;
            }

            //load the certificate
            PdfCertificate cert = new PdfCertificate(frmSign.txtCertificate.Text,frmSign.txtCertificatePassword.Text);

            //add a signature to the specified position
            PdfSignature signature = new PdfSignature(PDFDoc, PDFDoc.Pages[PageCurrent - 1], cert, "signature");
            signature.Bounds = new RectangleF(new PointF(x1pdf, y1pdf), new SizeF(x2pdf - x1pdf, y2pdf - y1pdf));

            //set the signature content
            signature.NameLabel = frmSign.txtName.Text;
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = frmSign.txtLocation.Text;
            signature.ReasonLabel = "Reason: ";
            signature.Reason = frmSign.txtReason.Text;
            signature.ContactInfoLabel = "Contact Number: ";
            signature.ContactInfo = frmSign.txtContactInfo.Text;
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            signature.SignImageSource = PdfImage.FromImage(frmSign.picSign.Image);
            signature.SignImageLayout = SignImageLayout.Stretch;

            //configure a timestamp server
            signature.ConfigureTimestamp(frmSign.txtTimestampServer.Text);

            //save to file
            PDFDoc.SaveToFile(frmSign.txtPDFOutput.Text);

            MessageBox.Show(string.Format("PDF signed saved at {0}", frmSign.txtPDFOutput.Text), "PDF Sign", MessageBoxButtons.OK);

            //reset variables
            X1 = -1;
            Y1 = -1;
            X2 = -1;
            Y2 = -1;
            PDFPath = "";
            PDFDoc = new PdfDocument();
            picPDF.Image = null;
            lblPageInfo.Text = "";
            signingArea = new Rectangle();

            Cursor = Cursors.Default;
        }
    }
}
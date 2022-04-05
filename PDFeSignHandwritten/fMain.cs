using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Signatures;
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
        PdfDocument pdfDocument;
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
                pdfDocument = PdfReader.Open(PDFPath);
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

            lblPageInfo.Text = string.Format("{0} / {1}", PageCurrent, 10);
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
            if (PageCurrent < pdfDocument.PageCount)
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

            if (frmSign == null) frmSign = new fSign();
            frmSign.txtPDFOutput.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "out.pdf");
            frmSign.txtCertificate.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "sample.p12");
            frmSign.txtCertificatePassword.Text = "sample";
            frmSign.ShowDialog();

            Int32 t;
            Int32 x1pdf = (X1 * (int)pdfDocument.Pages[PageCurrent].Width.Point) / 1240;
            Int32 y1pdf = (int)pdfDocument.Pages[PageCurrent].Height.Point - ((Y1 * (int)pdfDocument.Pages[0].Height.Point) / 1753);
            Int32 x2pdf = (X2 * (int)pdfDocument.Pages[0].Width.Point) / 1240;
            Int32 y2pdf = (int)pdfDocument.Pages[PageCurrent].Height.Point - ((Y2 * (int)pdfDocument.Pages[0].Height.Point) / 1753);

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
            
            PdfSignatureOptions options = new PdfSignatureOptions
            {
                ContactInfo = "Contact Info",
                Location = "Paris",
                Reason = "Test signatures",
                Rectangle = new XRect(x1pdf, y1pdf, x2pdf - x1pdf, y2pdf - y1pdf),
                AppearanceHandler = new SignAppearenceHandler(frmSign.picSign.Image, frmSign.txtName.Text, frmSign.txtLocation.Text, frmSign.txtReason.Text, frmSign.txtContactInfo.Text)
            };

            X509Certificate2 cert = new X509Certificate2(frmSign.txtCertificate.Text, frmSign.txtCertificatePassword.Text, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
            PdfSignatureHandler pdfSignatureHandler = new PdfSignatureHandler(new DefaultSigner(cert), null, options);
            pdfSignatureHandler.AttachToDocument(pdfDocument, PageCurrent-1);
            pdfDocument.Save(frmSign.txtPDFOutput.Text);

            Process.Start(frmSign.txtPDFOutput.Text);
            MessageBox.Show(string.Format("PDF signed saved at {0}", frmSign.txtPDFOutput.Text), "PDF Sign", MessageBoxButtons.OK);

            //reset variables
            X1 = Y1 = X2 = Y2 = -1;
            pdfDocument.Close();
            pdfDocument = null;
            PDFPath = "";
            if (picPDF.Image != null)
            {
                picPDF.Image.Dispose();
                picPDF.Image = null;
            }
            lblPageInfo.Text = "";
            signingArea = new Rectangle();
            frmSign.Dispose();
            frmSign = null;
            Cursor = Cursors.Default;
        }

        private class SignAppearenceHandler : ISignatureAppearanceHandler
        {
            private XImage img;
            private string name;
            private string location;
            private string reason;
            private string contactinfo;

            public SignAppearenceHandler(Image img, string name, string location, string reason, string contactinfo){
                this.img = XImage.FromGdiPlusImage(img);
                this.name = name;
                this.location = location;
                this.reason = reason;
                this.contactinfo = contactinfo;
            }

            public void DrawAppearance(XGraphics gfx, XRect rect)
            {
                string text = "Name: " + name + "\nLocation: " + location +"\nReason: " + reason + "\nContact info: " + contactinfo + "\nDate: " + DateTime.Now.ToString();
                XFont font = new XFont("Verdana", 7.0, XFontStyle.Regular);
                XTextFormatter xTextFormatter = new XTextFormatter(gfx);
                XPoint xPoint = new XPoint(0.0, 0.0);
                bool flag = img != null;
                if (flag)
                {
                    double zoom = CalculateZoomToFit(img, rect);
                    gfx.DrawImage(img, xPoint.X, xPoint.Y, img.PixelWidth * zoom, img.PixelHeight * zoom);
                    xPoint = new XPoint(rect.Width / 2.0, 0.0);
                }
                xTextFormatter.DrawString(text, font, new XSolidBrush(XColor.FromKnownColor(XKnownColor.Black)), new XRect(xPoint.X, xPoint.Y, rect.Width - xPoint.X, rect.Height), XStringFormats.TopLeft);
            }

            public double CalculateZoomToFit(XImage image, XRect targetPanel)
            {
                var panel_ratio = targetPanel.Width / targetPanel.Height;
                var image_ratio = image.PixelWidth / image.PixelHeight;

                return panel_ratio > image_ratio
                     ? targetPanel.Height / image.PixelHeight
                     : targetPanel.Width / image.PixelWidth
                     ;
            }
        }
    }
}
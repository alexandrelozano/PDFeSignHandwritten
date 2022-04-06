using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFeSignHandwritten
{
    public partial class fSign : Form
    {
        Point lastPoint = Point.Empty;
        bool isMouseDown;

        public fSign()
        {
            InitializeComponent();

            Bitmap bmp = new Bitmap(picSign.Width, picSign.Height);
            picSign.Image = bmp;
        }

        private void picSign_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void picSign_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (lastPoint != Point.Empty)
                {
                    using (Graphics g = Graphics.FromImage(picSign.Image))
                    {
                        g.DrawLine(new Pen(Color.Blue, 2), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                    }
                    picSign.Invalidate();
                    lastPoint = e.Location;
                }
            }
        }

        private void picSign_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void bttSign_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bttPDFOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples");      
            saveFileDialog1.Title = "PDF signed output";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPDFOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void bttCertificate_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "sample.p12");
            saveFileDialog1.Title = "Certificate";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "p12";
            saveFileDialog1.Filter = "P12 files (*.p12)|*.p12|PFX files (*.pfx)|*.pfx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCertificate.Text = saveFileDialog1.FileName;
            }
        }

    }
}

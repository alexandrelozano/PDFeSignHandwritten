﻿using System;
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
using System.Configuration;

namespace PDFeSignHandwritten
{
    public partial class fSign : Form
    {
        Point lastPoint = Point.Empty;
        bool isMouseDown;

        public bool sign;

        public fSign()
        {
            InitializeComponent();

            Bitmap bmp = new Bitmap(picSign.Width, picSign.Height);
            picSign.Image = bmp;

            txtName.Text = ConfigurationManager.AppSettings["Name"];
            txtContactInfo.Text = ConfigurationManager.AppSettings["ContactInfo"];
            txtLocation.Text = ConfigurationManager.AppSettings["Location"];
            txtReason.Text = ConfigurationManager.AppSettings["Reason"];
            txtCertificate.Text = ConfigurationManager.AppSettings["Certificate"];
            txtCertificatePassword.Text = ConfigurationManager.AppSettings["CertificatePassword"];
            txtTimestampServer.Text = ConfigurationManager.AppSettings["TimestampServer"];
            txtPDFOutput.Text = ConfigurationManager.AppSettings["PDFOutput"];

            if (txtCertificate.Text == "")
            {
                txtCertificate.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "sample.p12");
                txtCertificatePassword.Text = "sample";
            }

            if (txtPDFOutput.Text == "")
            {
                txtPDFOutput.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "out.pdf");
            }

            cboPenColor.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();
            cboPenColor.MaxDropDownItems = 10;
            cboPenColor.IntegralHeight = false;
            cboPenColor.DrawMode = DrawMode.OwnerDrawFixed;
            cboPenColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPenColor.DrawItem += cboPen_DrawItem;

            for (int i = 0; i < cboPenColor.Items.Count - 1; i++)
            {
                Color c = (Color)cboPenColor.Items[i];
                if (c.Name == "Blue")
                    cboPenColor.SelectedIndex = i;
            }

            sign = false;
        }

        private void cboPen_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = cboPenColor.GetItemText(cboPenColor.Items[e.Index]);
                var color = (Color)cboPenColor.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, cboPenColor.Font, r2,
                    cboPenColor.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
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
                        Color c = Color.Blue;
                        if (cboPenColor.SelectedIndex >= 0)
                            c = (Color)cboPenColor.SelectedValue;
                        g.DrawLine(new Pen(c, 2), lastPoint, e.Location);
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
            ConfigurationManager.AppSettings["Name"] = txtName.Text;
            ConfigurationManager.AppSettings["ContactInfo"] = txtContactInfo.Text;
            ConfigurationManager.AppSettings["Location"] = txtLocation.Text;
            ConfigurationManager.AppSettings["Reason"] = txtReason.Text;
            ConfigurationManager.AppSettings["Certificate"] = txtCertificate.Text;
            ConfigurationManager.AppSettings["CertificatePassword"] = txtCertificatePassword.Text;
            ConfigurationManager.AppSettings["TimestampServer"] = txtTimestampServer.Text;
            ConfigurationManager.AppSettings["PDFOutput"] = txtPDFOutput.Text;

            sign = true;
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

        private void bttLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fillPictureBox(picSign, new Bitmap(open.FileName));
            }
        }

        static public void fillPictureBox(PictureBox pbox, Bitmap bmp)
        {
            pbox.SizeMode = PictureBoxSizeMode.Normal;
            bool source_is_wider = (float)bmp.Width / bmp.Height > (float)pbox.Width / pbox.Height;

            var resized = new Bitmap(pbox.Width, pbox.Height);
            var g = Graphics.FromImage(resized);
            var dest_rect = new Rectangle(0, 0, pbox.Width, pbox.Height);
            Rectangle src_rect;

            if (source_is_wider)
            {
                float size_ratio = (float)pbox.Height / bmp.Height;
                int sample_width = (int)(pbox.Width / size_ratio);
                src_rect = new Rectangle((bmp.Width - sample_width) / 2, 0, sample_width, bmp.Height);
            }
            else
            {
                float size_ratio = (float)pbox.Width / bmp.Width;
                int sample_height = (int)(pbox.Height / size_ratio);
                src_rect = new Rectangle(0, (bmp.Height - sample_height) / 2, bmp.Width, sample_height);
            }

            g.DrawImage(bmp, dest_rect, src_rect, GraphicsUnit.Pixel);
            g.Dispose();

            pbox.Image = resized;
        }
    }
}

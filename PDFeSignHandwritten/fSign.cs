using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
                    if (picSign.Image == null)
                    {
                        Bitmap bmp = new Bitmap(picSign.Width, picSign.Height);
                        picSign.Image = bmp;
                    }

                    using (Graphics g = Graphics.FromImage(picSign.Image))
                    {
                        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
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
    }
}

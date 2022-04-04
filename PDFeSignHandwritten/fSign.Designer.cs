
namespace PDFeSignHandwritten
{
    partial class fSign
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picSign = new System.Windows.Forms.PictureBox();
            this.bttSign = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSign)).BeginInit();
            this.SuspendLayout();
            // 
            // picSign
            // 
            this.picSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSign.Location = new System.Drawing.Point(12, 12);
            this.picSign.Name = "picSign";
            this.picSign.Size = new System.Drawing.Size(698, 360);
            this.picSign.TabIndex = 3;
            this.picSign.TabStop = false;
            this.picSign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSign_MouseDown);
            this.picSign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSign_MouseMove);
            this.picSign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSign_MouseUp);
            // 
            // bttSign
            // 
            this.bttSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttSign.Location = new System.Drawing.Point(313, 378);
            this.bttSign.Name = "bttSign";
            this.bttSign.Size = new System.Drawing.Size(97, 31);
            this.bttSign.TabIndex = 2;
            this.bttSign.Text = "Sign";
            this.bttSign.UseVisualStyleBackColor = true;
            this.bttSign.Click += new System.EventHandler(this.bttSign_Click);
            // 
            // fSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 421);
            this.Controls.Add(this.picSign);
            this.Controls.Add(this.bttSign);
            this.Name = "fSign";
            this.Text = "Sign";
            ((System.ComponentModel.ISupportInitialize)(this.picSign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picSign;
        internal System.Windows.Forms.Button bttSign;
    }
}
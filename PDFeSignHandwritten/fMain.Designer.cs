
namespace PDFeSignHandwritten
{
    partial class fMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.bttPageNext = new System.Windows.Forms.Button();
            this.bttPagePrev = new System.Windows.Forms.Button();
            this.bttPDFSign = new System.Windows.Forms.Button();
            this.picPDF = new System.Windows.Forms.PictureBox();
            this.bttPDFOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Location = new System.Drawing.Point(212, 10);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(53, 32);
            this.lblPageInfo.TabIndex = 10;
            this.lblPageInfo.Text = "0 / 0";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttPageNext
            // 
            this.bttPageNext.Location = new System.Drawing.Point(271, 10);
            this.bttPageNext.Name = "bttPageNext";
            this.bttPageNext.Size = new System.Drawing.Size(42, 33);
            this.bttPageNext.TabIndex = 9;
            this.bttPageNext.Text = ">";
            this.bttPageNext.UseVisualStyleBackColor = true;
            this.bttPageNext.Click += new System.EventHandler(this.bttPageNext_Click);
            // 
            // bttPagePrev
            // 
            this.bttPagePrev.Location = new System.Drawing.Point(164, 10);
            this.bttPagePrev.Name = "bttPagePrev";
            this.bttPagePrev.Size = new System.Drawing.Size(42, 33);
            this.bttPagePrev.TabIndex = 8;
            this.bttPagePrev.Text = "<";
            this.bttPagePrev.UseVisualStyleBackColor = true;
            this.bttPagePrev.Click += new System.EventHandler(this.bttPagePrev_Click);
            // 
            // bttPDFSign
            // 
            this.bttPDFSign.Image = global::PDFeSignHandwritten.Properties.Resources.pencil;
            this.bttPDFSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttPDFSign.Location = new System.Drawing.Point(319, 10);
            this.bttPDFSign.Name = "bttPDFSign";
            this.bttPDFSign.Size = new System.Drawing.Size(139, 33);
            this.bttPDFSign.TabIndex = 6;
            this.bttPDFSign.Text = "Sign...";
            this.bttPDFSign.UseVisualStyleBackColor = true;
            this.bttPDFSign.Click += new System.EventHandler(this.bttPDFSign_Click);
            // 
            // picPDF
            // 
            this.picPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPDF.Location = new System.Drawing.Point(12, 49);
            this.picPDF.Name = "picPDF";
            this.picPDF.Size = new System.Drawing.Size(778, 580);
            this.picPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPDF.TabIndex = 11;
            this.picPDF.TabStop = false;
            this.picPDF.Paint += new System.Windows.Forms.PaintEventHandler(this.picPDF_Paint);
            this.picPDF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPDF_MouseDown);
            this.picPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPDF_MouseMove);
            this.picPDF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPDF_MouseUp);
            // 
            // bttPDFOpen
            // 
            this.bttPDFOpen.Image = global::PDFeSignHandwritten.Properties.Resources.page_white_acrobat;
            this.bttPDFOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttPDFOpen.Location = new System.Drawing.Point(12, 10);
            this.bttPDFOpen.Name = "bttPDFOpen";
            this.bttPDFOpen.Size = new System.Drawing.Size(146, 33);
            this.bttPDFOpen.TabIndex = 7;
            this.bttPDFOpen.Text = "Open PDF...";
            this.bttPDFOpen.UseVisualStyleBackColor = true;
            this.bttPDFOpen.Click += new System.EventHandler(this.bttPDFOpen_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 641);
            this.Controls.Add(this.picPDF);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.bttPageNext);
            this.Controls.Add(this.bttPagePrev);
            this.Controls.Add(this.bttPDFOpen);
            this.Controls.Add(this.bttPDFSign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF handwritten eSign";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picPDF;
        internal System.Windows.Forms.Label lblPageInfo;
        internal System.Windows.Forms.Button bttPageNext;
        internal System.Windows.Forms.Button bttPagePrev;
        internal System.Windows.Forms.Button bttPDFOpen;
        internal System.Windows.Forms.Button bttPDFSign;
    }
}


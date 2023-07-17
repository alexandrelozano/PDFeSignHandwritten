
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSign));
            this.bttLoadImage = new System.Windows.Forms.Button();
            this.picSign = new System.Windows.Forms.PictureBox();
            this.bttSign = new System.Windows.Forms.Button();
            this.cboPenColor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPenWidth = new System.Windows.Forms.ComboBox();
            this.chkOpenPDFAfterSign = new System.Windows.Forms.CheckBox();
            this.grpeSign = new System.Windows.Forms.GroupBox();
            this.txtTimestampServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCertificatePassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bttCertificate = new System.Windows.Forms.Button();
            this.txtCertificate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkeSign = new System.Windows.Forms.CheckBox();
            this.bttPDFOutput = new System.Windows.Forms.Button();
            this.txtPDFOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSign)).BeginInit();
            this.grpeSign.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttLoadImage
            // 
            this.bttLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttLoadImage.Image = global::PDFeSignHandwritten.Properties.Resources.picture_import;
            this.bttLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttLoadImage.Location = new System.Drawing.Point(12, 378);
            this.bttLoadImage.Name = "bttLoadImage";
            this.bttLoadImage.Size = new System.Drawing.Size(173, 31);
            this.bttLoadImage.TabIndex = 22;
            this.bttLoadImage.Text = "Load image from file...";
            this.bttLoadImage.UseVisualStyleBackColor = true;
            this.bttLoadImage.Click += new System.EventHandler(this.bttLoadImage_Click);
            // 
            // picSign
            // 
            this.picSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSign.Location = new System.Drawing.Point(12, 12);
            this.picSign.Name = "picSign";
            this.picSign.Size = new System.Drawing.Size(525, 360);
            this.picSign.TabIndex = 3;
            this.picSign.TabStop = false;
            this.picSign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSign_MouseDown);
            this.picSign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSign_MouseMove);
            this.picSign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSign_MouseUp);
            // 
            // bttSign
            // 
            this.bttSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSign.Image = global::PDFeSignHandwritten.Properties.Resources.pencil;
            this.bttSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttSign.Location = new System.Drawing.Point(543, 378);
            this.bttSign.Name = "bttSign";
            this.bttSign.Size = new System.Drawing.Size(173, 31);
            this.bttSign.TabIndex = 2;
            this.bttSign.Text = "Sign";
            this.bttSign.UseVisualStyleBackColor = true;
            this.bttSign.Click += new System.EventHandler(this.bttSign_Click);
            // 
            // cboPenColor
            // 
            this.cboPenColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPenColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPenColor.FormattingEnabled = true;
            this.cboPenColor.Location = new System.Drawing.Point(252, 384);
            this.cboPenColor.Name = "cboPenColor";
            this.cboPenColor.Size = new System.Drawing.Size(120, 21);
            this.cboPenColor.TabIndex = 23;
            this.cboPenColor.SelectedValueChanged += new System.EventHandler(this.cboPenColor_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(191, 387);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Pen color:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(378, 387);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Pen color:";
            // 
            // cboPenWidth
            // 
            this.cboPenWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPenWidth.FormattingEnabled = true;
            this.cboPenWidth.Location = new System.Drawing.Point(439, 384);
            this.cboPenWidth.Name = "cboPenWidth";
            this.cboPenWidth.Size = new System.Drawing.Size(98, 21);
            this.cboPenWidth.TabIndex = 25;
            this.cboPenWidth.SelectedIndexChanged += new System.EventHandler(this.cboPenWidth_SelectedIndexChanged);
            // 
            // chkOpenPDFAfterSign
            // 
            this.chkOpenPDFAfterSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOpenPDFAfterSign.AutoSize = true;
            this.chkOpenPDFAfterSign.Checked = true;
            this.chkOpenPDFAfterSign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenPDFAfterSign.Location = new System.Drawing.Point(543, 355);
            this.chkOpenPDFAfterSign.Name = "chkOpenPDFAfterSign";
            this.chkOpenPDFAfterSign.Size = new System.Drawing.Size(122, 17);
            this.chkOpenPDFAfterSign.TabIndex = 27;
            this.chkOpenPDFAfterSign.Text = "Open PDF after sign";
            this.chkOpenPDFAfterSign.UseVisualStyleBackColor = true;
            // 
            // grpeSign
            // 
            this.grpeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpeSign.Controls.Add(this.txtTimestampServer);
            this.grpeSign.Controls.Add(this.label8);
            this.grpeSign.Controls.Add(this.txtCertificatePassword);
            this.grpeSign.Controls.Add(this.label7);
            this.grpeSign.Controls.Add(this.bttCertificate);
            this.grpeSign.Controls.Add(this.txtCertificate);
            this.grpeSign.Controls.Add(this.label6);
            this.grpeSign.Controls.Add(this.txtContactInfo);
            this.grpeSign.Controls.Add(this.label4);
            this.grpeSign.Controls.Add(this.txtReason);
            this.grpeSign.Controls.Add(this.label3);
            this.grpeSign.Controls.Add(this.txtLocation);
            this.grpeSign.Controls.Add(this.label2);
            this.grpeSign.Controls.Add(this.txtName);
            this.grpeSign.Controls.Add(this.label1);
            this.grpeSign.Location = new System.Drawing.Point(543, 12);
            this.grpeSign.Name = "grpeSign";
            this.grpeSign.Size = new System.Drawing.Size(173, 295);
            this.grpeSign.TabIndex = 28;
            this.grpeSign.TabStop = false;
            // 
            // txtTimestampServer
            // 
            this.txtTimestampServer.Location = new System.Drawing.Point(10, 268);
            this.txtTimestampServer.Name = "txtTimestampServer";
            this.txtTimestampServer.Size = new System.Drawing.Size(154, 20);
            this.txtTimestampServer.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Timestamp server:";
            // 
            // txtCertificatePassword
            // 
            this.txtCertificatePassword.Location = new System.Drawing.Point(10, 229);
            this.txtCertificatePassword.Name = "txtCertificatePassword";
            this.txtCertificatePassword.PasswordChar = '*';
            this.txtCertificatePassword.Size = new System.Drawing.Size(154, 20);
            this.txtCertificatePassword.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Certificate password:";
            // 
            // bttCertificate
            // 
            this.bttCertificate.Location = new System.Drawing.Point(140, 189);
            this.bttCertificate.Name = "bttCertificate";
            this.bttCertificate.Size = new System.Drawing.Size(24, 22);
            this.bttCertificate.TabIndex = 35;
            this.bttCertificate.Text = "...";
            this.bttCertificate.UseVisualStyleBackColor = true;
            // 
            // txtCertificate
            // 
            this.txtCertificate.Location = new System.Drawing.Point(10, 190);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(131, 20);
            this.txtCertificate.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Certificate:";
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(10, 151);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(154, 20);
            this.txtContactInfo.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Contact info:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(10, 112);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(154, 20);
            this.txtReason.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Reason:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(10, 73);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(154, 20);
            this.txtLocation.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Location:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(10, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name:";
            // 
            // chkeSign
            // 
            this.chkeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkeSign.AutoSize = true;
            this.chkeSign.Checked = true;
            this.chkeSign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkeSign.Location = new System.Drawing.Point(555, 9);
            this.chkeSign.Name = "chkeSign";
            this.chkeSign.Size = new System.Drawing.Size(103, 17);
            this.chkeSign.TabIndex = 40;
            this.chkeSign.Text = "eSign document";
            this.chkeSign.UseVisualStyleBackColor = true;
            this.chkeSign.CheckedChanged += new System.EventHandler(this.chkeSign_CheckedChanged);
            // 
            // bttPDFOutput
            // 
            this.bttPDFOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPDFOutput.Location = new System.Drawing.Point(683, 329);
            this.bttPDFOutput.Name = "bttPDFOutput";
            this.bttPDFOutput.Size = new System.Drawing.Size(24, 22);
            this.bttPDFOutput.TabIndex = 46;
            this.bttPDFOutput.Text = "...";
            this.bttPDFOutput.UseVisualStyleBackColor = true;
            // 
            // txtPDFOutput
            // 
            this.txtPDFOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPDFOutput.Location = new System.Drawing.Point(553, 329);
            this.txtPDFOutput.Name = "txtPDFOutput";
            this.txtPDFOutput.Size = new System.Drawing.Size(131, 20);
            this.txtPDFOutput.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Output PDF:";
            // 
            // fSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 421);
            this.Controls.Add(this.bttPDFOutput);
            this.Controls.Add(this.txtPDFOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkeSign);
            this.Controls.Add(this.grpeSign);
            this.Controls.Add(this.chkOpenPDFAfterSign);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPenWidth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboPenColor);
            this.Controls.Add(this.bttLoadImage);
            this.Controls.Add(this.picSign);
            this.Controls.Add(this.bttSign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "fSign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Draw your signature in the box";
            this.Resize += new System.EventHandler(this.fSign_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSign)).EndInit();
            this.grpeSign.ResumeLayout(false);
            this.grpeSign.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picSign;
        internal System.Windows.Forms.Button bttSign;
        internal System.Windows.Forms.Button bttLoadImage;
        private System.Windows.Forms.ComboBox cboPenColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPenWidth;
        public System.Windows.Forms.CheckBox chkOpenPDFAfterSign;
        private System.Windows.Forms.GroupBox grpeSign;
        public System.Windows.Forms.TextBox txtTimestampServer;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtCertificatePassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bttCertificate;
        public System.Windows.Forms.TextBox txtCertificate;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox chkeSign;
        private System.Windows.Forms.Button bttPDFOutput;
        public System.Windows.Forms.TextBox txtPDFOutput;
        private System.Windows.Forms.Label label5;
    }
}

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPDFOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bttPDFOutput = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bttCertificate = new System.Windows.Forms.Button();
            this.txtCertificate = new System.Windows.Forms.TextBox();
            this.txtCertificatePassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.picSign = new System.Windows.Forms.PictureBox();
            this.bttSign = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSign)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(544, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(544, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 20);
            this.txtName.TabIndex = 5;
            this.txtName.Text = "Digitally signed by somebody";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(544, 69);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(172, 20);
            this.txtLocation.TabIndex = 7;
            this.txtLocation.Text = "New york";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Location:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(544, 108);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(172, 20);
            this.txtReason.TabIndex = 9;
            this.txtReason.Text = "Ensure authenticity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Reason:";
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(543, 147);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(172, 20);
            this.txtContactInfo.TabIndex = 11;
            this.txtContactInfo.Text = "+34 987654321";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Contact info:";
            // 
            // txtPDFOutput
            // 
            this.txtPDFOutput.Location = new System.Drawing.Point(543, 186);
            this.txtPDFOutput.Name = "txtPDFOutput";
            this.txtPDFOutput.Size = new System.Drawing.Size(152, 20);
            this.txtPDFOutput.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Output PDF:";
            // 
            // bttPDFOutput
            // 
            this.bttPDFOutput.Location = new System.Drawing.Point(692, 185);
            this.bttPDFOutput.Name = "bttPDFOutput";
            this.bttPDFOutput.Size = new System.Drawing.Size(24, 22);
            this.bttPDFOutput.TabIndex = 14;
            this.bttPDFOutput.Text = "...";
            this.bttPDFOutput.UseVisualStyleBackColor = true;
            this.bttPDFOutput.Click += new System.EventHandler(this.bttPDFOutput_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Certificate:";
            // 
            // bttCertificate
            // 
            this.bttCertificate.Location = new System.Drawing.Point(692, 224);
            this.bttCertificate.Name = "bttCertificate";
            this.bttCertificate.Size = new System.Drawing.Size(24, 22);
            this.bttCertificate.TabIndex = 17;
            this.bttCertificate.Text = "...";
            this.bttCertificate.UseVisualStyleBackColor = true;
            this.bttCertificate.Click += new System.EventHandler(this.bttCertificate_Click);
            // 
            // txtCertificate
            // 
            this.txtCertificate.Location = new System.Drawing.Point(543, 225);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(152, 20);
            this.txtCertificate.TabIndex = 16;
            // 
            // txtCertificatePassword
            // 
            this.txtCertificatePassword.Location = new System.Drawing.Point(543, 264);
            this.txtCertificatePassword.Name = "txtCertificatePassword";
            this.txtCertificatePassword.PasswordChar = '*';
            this.txtCertificatePassword.Size = new System.Drawing.Size(172, 20);
            this.txtCertificatePassword.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(544, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Certificate password:";
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
            this.bttSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttSign.Image = global::PDFeSignHandwritten.Properties.Resources.pencil;
            this.bttSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Controls.Add(this.txtCertificatePassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bttCertificate);
            this.Controls.Add(this.txtCertificate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bttPDFOutput);
            this.Controls.Add(this.txtPDFOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picSign);
            this.Controls.Add(this.bttSign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fSign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Draw your signature in the box";
            ((System.ComponentModel.ISupportInitialize)(this.picSign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picSign;
        internal System.Windows.Forms.Button bttSign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtLocation;
        public System.Windows.Forms.TextBox txtReason;
        public System.Windows.Forms.TextBox txtContactInfo;
        public System.Windows.Forms.TextBox txtPDFOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bttPDFOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bttCertificate;
        public System.Windows.Forms.TextBox txtCertificate;
        public System.Windows.Forms.TextBox txtCertificatePassword;
        private System.Windows.Forms.Label label7;
    }
}
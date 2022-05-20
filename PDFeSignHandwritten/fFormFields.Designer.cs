
namespace PDFeSignHandwritten
{
    partial class fFormFields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFormFields));
            this.dgFormFields = new System.Windows.Forms.DataGridView();
            this.bttCancel = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormFields)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFormFields
            // 
            this.dgFormFields.AllowUserToAddRows = false;
            this.dgFormFields.AllowUserToDeleteRows = false;
            this.dgFormFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFormFields.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgFormFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFormFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.FieldValue});
            this.dgFormFields.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFormFields.Location = new System.Drawing.Point(12, 12);
            this.dgFormFields.Name = "dgFormFields";
            this.dgFormFields.RowHeadersVisible = false;
            this.dgFormFields.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFormFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgFormFields.Size = new System.Drawing.Size(324, 322);
            this.dgFormFields.TabIndex = 9;
            // 
            // bttCancel
            // 
            this.bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttCancel.Image = global::PDFeSignHandwritten.Properties.Resources.cross;
            this.bttCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttCancel.Location = new System.Drawing.Point(12, 340);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(139, 33);
            this.bttCancel.TabIndex = 8;
            this.bttCancel.Text = "Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // bttSave
            // 
            this.bttSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSave.Image = global::PDFeSignHandwritten.Properties.Resources.disk;
            this.bttSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttSave.Location = new System.Drawing.Point(197, 340);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(139, 33);
            this.bttSave.TabIndex = 7;
            this.bttSave.Text = "Save";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // FieldName
            // 
            this.FieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FieldName.HeaderText = "Name";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Width = 60;
            // 
            // FieldValue
            // 
            this.FieldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FieldValue.HeaderText = "Value";
            this.FieldValue.Name = "FieldValue";
            // 
            // fFormFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 385);
            this.Controls.Add(this.dgFormFields);
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.bttSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "fFormFields";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form fields...";
            this.Load += new System.EventHandler(this.fFormFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFormFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bttSave;
        internal System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.DataGridView dgFormFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldValue;
    }
}
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFeSignHandwritten
{
    public partial class fFormFields : Form
    {
        public string PDFPath;

        public fFormFields()
        {
            InitializeComponent();

            dgFormFields.Columns["FieldName"].Frozen = true;
            dgFormFields.Columns["FieldName"].DefaultCellStyle.BackColor = dgFormFields.ColumnHeadersDefaultCellStyle.BackColor;
            dgFormFields.DefaultCellStyle.SelectionBackColor = dgFormFields.DefaultCellStyle.BackColor;
            dgFormFields.DefaultCellStyle.SelectionForeColor = dgFormFields.DefaultCellStyle.ForeColor;
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            SaveFormFields();

            this.Close();
        }

        private void fFormFields_Load(object sender, EventArgs e)
        {
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(PDFPath));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            IDictionary<String, PdfFormField> fields = form.GetFormFields();

            foreach (KeyValuePair<string, PdfFormField> field in fields)
            {
                var index = dgFormFields.Rows.Add();
                PdfString fieldName = field.Value.GetFieldName();
                if (fieldName != null)
                    dgFormFields.Rows[index].Cells["FieldName"].Value = fieldName.ToString();
                dgFormFields.Rows[index].Cells["FieldName"].Tag = field.Key;
                dgFormFields.Rows[index].Cells["FieldValue"].Value = field.Value.GetValueAsString();

                String[] states = field.Value.GetAppearanceStates();
                if (states.Length > 0)
                {
                    dgFormFields.Rows[index].Cells["FieldValue"].Value = null;
                    DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                    foreach (String state in states)
                    {
                        c.Items.Add(state);
                    }
                    dgFormFields.Rows[index].Cells["FieldValue"] = c;
                }
            }

            pdfDoc.Close();
        }

        private void SaveFormFields()
        {
            string pdfTmp = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(PDFPath), new PdfWriter(pdfTmp));

            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            IDictionary<String, PdfFormField> fields = form.GetFormFields();

            foreach (KeyValuePair<string, PdfFormField> field in fields)
            { 
                foreach (DataGridViewRow r in dgFormFields.Rows)
                {
                    if ((string)r.Cells["FieldName"].Tag == field.Key)
                    {
                        field.Value.SetValue((string)r.Cells["FieldValue"].Value);
                    }
                }
            }

            pdfDoc.Close();
            PDFPath = pdfTmp;
        }
    }
}

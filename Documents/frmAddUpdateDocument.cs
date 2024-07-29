using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleRentalManagmentSystem.Global;

namespace VehicleRentalManagmentSystem.Documents
{
    public partial class frmAddUpdateDocument : Form
    {
        public frmAddUpdateDocument(int CustomerID, int DocumentID)
        {
            InitializeComponent();

            _CustomerID = CustomerID;
            _DocumentID = DocumentID;
            _Mode = enMode.Update;
        }
        
        public frmAddUpdateDocument(int CustomerID)
        {
            InitializeComponent();

            _CustomerID = CustomerID;
            _Mode = enMode.AddNew;
        }

        int _CustomerID;
        int _DocumentID;
        clsDocuments _Document;


        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        private void frmAddUpdateDocument_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                _Document = new clsDocuments();
                this.Text = "Add New Document";
            }
            else
                this.Text = "Update Document";

            txtDocumentName.Text = "";
            txtDocumentPath.Text = "";
        }

        void _LoadData()
        {
            _Document = clsDocuments.Find(_DocumentID);

            if (_Document == null )
            {
                MessageBox.Show("Failed To Find Document With ID ["+_Document+"]", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtDocumentName .Text = _Document.Name;
            txtDocumentPath .Text = _Document.Path;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                txtDocumentPath.Text = selectedFilePath;
                // ...
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Document.Name = txtDocumentName.Text.Trim();
            _Document.Path = txtDocumentPath.Text;
            _Document.CustomerID = _CustomerID;
            _Document.CreatedBy = clsGlobal.CurrentUser.UserID;

            if (_Document.Save())
            {
                btnSave.Enabled = false;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed To Save Data", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDocumentPath_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentPath.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDocumentPath, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtDocumentPath, null);
            }
        }

        private void txtDocumentName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDocumentName, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtDocumentName, null);
            }
        }
    }
}

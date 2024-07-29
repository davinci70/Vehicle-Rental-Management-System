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
using VehicleRentalManagmentSystem.Properties;

namespace VehicleRentalManagmentSystem.Customers
{
    public partial class frmAddUpdateCustomer : Form
    {
        public frmAddUpdateCustomer()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateCustomer(int CustomerID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _CustomerID = CustomerID;
        }

        clsCustomers _Customer;
        int _CustomerID;

        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode = enMode.AddNew;

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                _Customer = new clsCustomers();
                this.Text = "Add New Customer";
            }
            else
            {
                this.Text = "Update Customer";
            }

            txtFullName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            rbMale.Checked = true;
            txtLicenseNo.Text = "";
            pbImage.Image = Resources.man_avatar;
            btnRemoveImage.Visible = false;
        }

        void _LoadData()
        {
            _Customer = clsCustomers.Find(_CustomerID);

            if ( _Customer == null )
            {
                MessageBox.Show("No customer with ID = " + _CustomerID, "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            txtFullName.Text = _Customer.Name.Trim();
            txtPhoneNumber.Text = _Customer.PhoneNumber.Trim();
            txtEmail.Text = _Customer.Email.Trim();
            txtAddress.Text = _Customer.Address.Trim();
            dtpDateOfBirth.Value = _Customer.DateOfBirth.Value;
            txtLicenseNo.Text = _Customer.LicenseNumber.Trim();

            if (_Customer.Gender == 1)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if (_Customer.ImagePath == null)
            {
                btnRemoveImage.Visible = false;

                if (_Customer.Gender == 1)
                    pbImage.Image = Resources.man_avatar;
                else
                    pbImage.Image = Resources.woman_avatar;
            }
            else
            {
                pbImage.ImageLocation = _Customer.ImagePath;
                btnRemoveImage.Visible = true;
            }
        }

        private void frmAddUpdateCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Customer.Email = txtEmail.Text.Trim();
            _Customer.Name = txtFullName.Text.Trim();
            _Customer.PhoneNumber = txtPhoneNumber.Text.Trim();
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.LicenseNumber = txtLicenseNo.Text.Trim();
            _Customer.DateOfBirth = dtpDateOfBirth.Value;

            if (rbFemale.Checked)
                _Customer.Gender = 2;
            else
                _Customer.Gender = 1;

            if (pbImage.ImageLocation != null)
                _Customer.ImagePath = pbImage.ImageLocation.ToString();
            else
                _Customer.ImagePath = null;

            if (_Customer.Save())
            {
                if (_Mode == enMode.AddNew)
                    _ResetDefaultValues();

                MessageBox.Show("Customer has been saved successfuly!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save Customer!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
            {
                pbImage.Image = Resources.man_avatar;
            }
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
            {
                pbImage.Image = Resources.woman_avatar;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbImage.Load(selectedFilePath);
                btnRemoveImage.Visible = true;
                // ...
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbFemale.Checked)
            {
                pbImage.Image = Resources.woman_avatar;
            }
            else
            {
                pbImage.Image = Resources.man_avatar;
            }

            btnRemoveImage.Visible = false;
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFullName, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFullName, null);
            };
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, null);
            };
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            };
        }

        private void txtLicenseNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseNo, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtLicenseNo, null);
            };
        }
    }
}

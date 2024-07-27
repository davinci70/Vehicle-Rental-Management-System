using BusinessLayer;
using Microsoft.Win32;
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

namespace VehicleRentalManagmentSystem.Users
{
    public partial class frmAddUpdateUsers : Form
    {
        public frmAddUpdateUsers()
        {
            InitializeComponent();

            // add new mode
            _Mode = enMode.AddNew;
        }
        
        public frmAddUpdateUsers(int UserID)
        {
            InitializeComponent();

            // update mode
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        enum enMode { AddNew = 1, Update = 2 };
        enMode _Mode = enMode.AddNew;

        int _UserID;
        clsUsers _User;

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUsers();
                this.Text = "Add New User";
            }
            else
            {
                this.Text = "Update User";
            }

            txtAddress.Text = "";
            txtFullName.Text = "";
            txtPhoneNumber.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            btnRemoveImage.Visible = false;
            chkIsActive.Checked = false;
            pbImage.Image = Resources.man_avatar;
        }

        void _LoadData()
        {
            _User = clsUsers.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            txtAddress.Text = _User.Address.Trim();
            txtFullName.Text = _User.FullName.Trim();
            txtPhoneNumber.Text = _User.PhoneNumber.Trim();
            txtPassword.Text = _User.Password.Trim();
            txtConfirmPassword.Text = _User.Password.Trim();
            txtUsername.Text = _User.Username.Trim();
            chkIsActive.Checked = (_User.status == true);

            if (_User.ImagePath == null)
                pbImage.Image = Resources.man_avatar;
            else
            {
                pbImage.ImageLocation = _User.ImagePath;
                btnRemoveImage.Visible = true;
            }
        }

        private void frmAddUpdateUsers_Load(object sender, EventArgs e)
        {
            // reset data to the default
            _ResetDefaultValues();

            // if it's update mode then load data for the user to be updated
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check validations
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // assign data to user object
            _User.FullName = txtFullName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.Address = txtAddress.Text.Trim();
            _User.PhoneNumber = txtPhoneNumber.Text.Trim();
            _User.status = chkIsActive.Checked;
            _User.Username = txtUsername.Text.Trim();

            if (pbImage.ImageLocation == null)
                _User.ImagePath = null;
            else
                _User.ImagePath = pbImage.ImageLocation;

            // save data
            if (_User.Save())
            {
                MessageBox.Show("User has been saved successfuly!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed to save User!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // upload image to picture box (pbImage)
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
            // invisible remove image button if there is image uploaded to pbImage
            pbImage.ImageLocation = null;
            pbImage.Image = Resources.man_avatar;
            btnRemoveImage.Visible = false;
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFullName, "this field is required!");
                return;
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
                return;
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, null);
            };
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "this field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            };
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "this field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            };
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "this field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "this field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }
    }
}

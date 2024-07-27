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

namespace VehicleRentalManagmentSystem.VehicleTypes
{
    public partial class frmAddUpdateVehicleCategories : Form
    {
        public frmAddUpdateVehicleCategories()
        {
            InitializeComponent();

            // add new mode
            _Mode = enMode.AddNew;
        }
        
        public frmAddUpdateVehicleCategories(int VehicleCategoryID)
        {
            InitializeComponent();

            // update mode
            _VehicleCategoryID = VehicleCategoryID;
            _Mode = enMode.Update;
        }

        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode = enMode.AddNew;

        int _VehicleCategoryID;
        clsVehicleCategories _VehicleCategory;

        private void frmAddUpdateVehicleCategory_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                // create a new object if it's add new mode
                _VehicleCategory = new clsVehicleCategories();
                this.Text = "Add New Vehicle Category";
            }
            else
            {
                // if it's update mode then find the category and apply edits
                this.Text = "Update Vehicle Category";

                _VehicleCategory = clsVehicleCategories.Find(_VehicleCategoryID);

                if ( _VehicleCategory == null )
                {
                    MessageBox.Show("No vehicle category with ID = " + _VehicleCategoryID, "Vehicle Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                txtVehicleCategoryName.Text = _VehicleCategory.CategoryName.Trim();
            }            

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

            // save data
            _VehicleCategory.CategoryName = txtVehicleCategoryName.Text.Trim();

            if (_VehicleCategory.Save())
            {
                MessageBox.Show("Vehicle category has been saved successfuly!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save vehicle category!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVehicleCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleCategoryName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVehicleCategoryName, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtVehicleCategoryName, null);
            }
        }
    }
}

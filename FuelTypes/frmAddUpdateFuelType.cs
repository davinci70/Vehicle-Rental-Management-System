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

namespace VehicleRentalManagmentSystem.Makes
{
    public partial class frmAddUpdateFuelType : Form
    {
        public frmAddUpdateFuelType()
        {
            InitializeComponent();

            // add new mode
            _Mode = enMode.AddNew;
        }
        
        public frmAddUpdateFuelType(int FuelTypeID)
        {
            InitializeComponent();

            // update mode
            _FuelTypeID = FuelTypeID;
            _Mode = enMode.Update;
        }

        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode = enMode.AddNew;

        int _FuelTypeID;
        clsFuelTypes _FuelType;

        private void frmAddUpdateFuelType_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                // create a new object if it's add new mode
                _FuelType = new clsFuelTypes();
                this.Text = "Add New Fuel Type";
            }
            else
            {
                // find the fuel type and apply edits if it's update mode
                this.Text = "Update Fuel Type";

                _FuelType = clsFuelTypes.Find(_FuelTypeID);

                if (_FuelType == null)
                {
                    MessageBox.Show("No fuel type with ID = " + _FuelTypeID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                txtFuelType.Text = _FuelType.FuelType.Trim();
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

            // save data
            _FuelType.FuelType = txtFuelType.Text.Trim();

            if (_FuelType.Save())
            {
                MessageBox.Show("Fuel type has been saved successfuly!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save fuel type!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFuelType_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFuelType.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFuelType, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtFuelType, null);
            }
        }
    }
}

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
using static System.Net.Mime.MediaTypeNames;

namespace VehicleRentalManagmentSystem.Vehicles
{
    public partial class frmAddUpdateVehicle : Form
    {
        public frmAddUpdateVehicle()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        
        public frmAddUpdateVehicle(int VehicleID)
        {
            InitializeComponent();

            _VehicleID = VehicleID;
            _Mode = enMode.Update;
        }

        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode = enMode.AddNew;

        int _VehicleID;
        clsVehicles _Vehicle;

        void _FillFuelTypeInComboBox()
        {
            DataTable dtFuelTypes = clsFuelTypes.GetAll();

            foreach (DataRow row in dtFuelTypes.Rows)
            {
                cbFuelType.Items.Add(row["FuelType"]);
            }

            cbFuelType.SelectedIndex = 0;
        }
        void _FillVehicleCategoriesInComboBox()
        {
            DataTable dtCategories = clsVehicleCategories.GetAll();

            foreach (DataRow row in dtCategories.Rows)
            {
                cbVehicleCategory.Items.Add(row["CategoryName"]);
            }

            cbVehicleCategory.SelectedIndex = 0;
        }

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Vehicle";
                _Vehicle = new clsVehicles();
            }
            else
            {
                this.Text = "Update Vehicle";
            }

            _FillFuelTypeInComboBox();
            _FillVehicleCategoriesInComboBox();
            txtMake.Text = "";
            txtModel.Text = "";
            txtPlateNumber.Text = "";
            txtPricePerDay.Text = "";
            txtMilage.Text = "";
            txtYear.Text = "";
            chkIsAvailable.Checked = true;
            btnRemoveImage.Visible = false;
            pbVehicleImage.Image = Resources.car_placeholder;
        }

        void _LoadData()
        {
            _Vehicle = clsVehicles.Find(_VehicleID);

            if ( _Vehicle == null )
            {
                MessageBox.Show("The vehicle with ID "+_VehicleID+" was not found!", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  
                return;
            }

            txtMake.Text = _Vehicle.Make.Trim();
            txtModel.Text= _Vehicle.Model.Trim();
            txtPlateNumber.Text = _Vehicle.PlateNumber.Trim();
            txtPricePerDay.Text = _Vehicle.PricePerDay.ToString().Trim();
            txtMilage.Text = _Vehicle.Milage.ToString().Trim();
            txtYear.Text = _Vehicle.Year.ToString().Trim();
            cbFuelType.SelectedItem = _Vehicle.FuelTypeInfo.FuelType.Trim();
            cbVehicleCategory.SelectedItem = _Vehicle.VehicleCategoryInfo.CategoryName.Trim();
            chkIsAvailable.Checked = (_Vehicle.IsAvailable == true);
            btnRemoveImage.Visible = (_Vehicle.ImagePath !=  null);

            if (_Vehicle.ImagePath != null)
                pbVehicleImage.ImageLocation = _Vehicle.ImagePath;
            else
                pbVehicleImage.Image = Resources.car_placeholder;
        }

        private void frmAddUpdateVehicle_Load(object sender, EventArgs e)
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

            _Vehicle.Make = txtMake.Text.Trim();
            _Vehicle.Model = txtModel.Text.Trim();
            _Vehicle.PlateNumber = txtPlateNumber.Text.Trim();
            _Vehicle.Milage = Convert.ToInt32(txtMilage.Text.Trim());
            _Vehicle.PricePerDay = Convert.ToDecimal(txtPricePerDay.Text.Trim());
            _Vehicle.Year = Convert.ToInt32(txtYear.Text.Trim());
            _Vehicle.FuelTypeID = clsFuelTypes.FindByName(cbFuelType.SelectedItem.ToString()).ID;
            _Vehicle.VehicleCategoryID = clsVehicleCategories.FindByName(cbVehicleCategory.SelectedItem.ToString()).CategoryID;
            _Vehicle.IsAvailable = (chkIsAvailable.Checked == true);

            if (pbVehicleImage.ImageLocation != null)
                _Vehicle.ImagePath = pbVehicleImage.ImageLocation.ToString();
            else
                _Vehicle.ImagePath = null;

            if (_Vehicle.Save())
            {
                if (_Mode == enMode.AddNew)
                    _ResetDefaultValues();

                MessageBox.Show("Vehicle has been saved successfuly!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save Vehicle!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                pbVehicleImage.Load(selectedFilePath);
                btnRemoveImage.Visible = true;
                // ...
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbVehicleImage.ImageLocation = null;
            pbVehicleImage.Image = Resources.car_placeholder;
            btnRemoveImage.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMake_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMake.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMake, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtMake, null);
            }
        }

        private void txtModel_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtModel, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtModel, null);
            }
        }

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtYear, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtYear, null);
            }
        }

        private void txtMilage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMilage.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMilage, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtMilage, null);
            }
        }

        private void txtPlateNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPlateNumber, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtPlateNumber, null);
            }
        }

        private void txtPricePerDay_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPricePerDay.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPricePerDay, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtPricePerDay, null);
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMilage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPricePerDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }
    }
}

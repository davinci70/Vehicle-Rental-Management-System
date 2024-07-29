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
using VehicleRentalManagmentSystem.Maintenance;
using VehicleRentalManagmentSystem.Makes;
using VehicleRentalManagmentSystem.Users;
using VehicleRentalManagmentSystem.VehicleTypes;

namespace VehicleRentalManagmentSystem.Settings
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        // get all categories
        DataTable _dtVehicleCategories = clsVehicleCategories.GetAll();

        // get all fuel types
        DataTable _dtFuelTypes = clsFuelTypes.GetAll();

        // get all users
        static DataTable _dtAllUsers = clsUsers.GetAll();

        // get all maintenances
        static DataTable _dtAllMaintenances;
        static DataTable _dtMaintenances;

        // view certain columns from users table
        DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false,"UserID", "FullName",
            "Username", "Status");

        private void btnVehicleCategories_Click(object sender, EventArgs e)
        {
            // view vehicle categories tab
            tcSettings.SelectedTab = tcSettings.TabPages["tabVehicleCategories"];
        }

        private void btnFuelTypes_Click(object sender, EventArgs e)
        {
            // view fuel types tab
            tcSettings.SelectedTab = tcSettings.TabPages["tabFuelTypes"];
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // view Users tab
            tcSettings.SelectedTab = tcSettings.TabPages["tabUsers"];
        }

        void _LoadFuelTypesData()
        {
            // get fuel types data and list them

            _dtFuelTypes = clsFuelTypes.GetAll();
            
            if (_dtFuelTypes.Rows.Count > 0)
            {
                dgvFuelTypes.DataSource = _dtFuelTypes;
                dgvFuelTypes.Columns["ID"].DisplayIndex = 0;
                dgvFuelTypes.Columns["FuelType"].DisplayIndex = 1;
                dgvFuelTypes.Columns["EditFuelType"].DisplayIndex = 2;
                dgvFuelTypes.Columns["DeleteFuelType"].DisplayIndex = 3;
                dgvFuelTypes.Columns["EditFuelType"].Width = 30;
                dgvFuelTypes.Columns["DeleteFuelType"].Width = 30;
            }
        }
        void _LoadVehicleCategoriesData()
        {
            // get vehicle categories data and list them

            _dtVehicleCategories = clsVehicleCategories.GetAll();
            
            if (_dtVehicleCategories.Rows.Count > 0 )
            {
              dgvVehicleCategories.DataSource = _dtVehicleCategories;
              dgvVehicleCategories.Columns["CategoryID"].DisplayIndex = 0;
              dgvVehicleCategories.Columns["CategoryName"].DisplayIndex = 1;
              dgvVehicleCategories.Columns["EditVehicleCategory"].DisplayIndex = 2;
              dgvVehicleCategories.Columns["DeleteVehicleCategory"].DisplayIndex = 3;
              dgvVehicleCategories.Columns["EditVehicleCategory"].Width = 30;
              dgvVehicleCategories.Columns["DeleteVehicleCategory"].Width = 30;
            }
        }
        void _LoadUsersData()
        {
            // get Users data and list them

            _dtAllUsers = clsUsers.GetAll();
            
            if (_dtUsers.Rows.Count > 0)
            {
                _dtUsers = _dtAllUsers.DefaultView.ToTable(false,"UserID", "FullName",
                    "Username", "Status");

                dgvUsers.DataSource = _dtUsers;
                dgvUsers.Columns["UserID"].DisplayIndex = 0;
                dgvUsers.Columns["FullName"].DisplayIndex = 1;
                dgvUsers.Columns["Username"].DisplayIndex = 2;
                dgvUsers.Columns["Status"].DisplayIndex = 3;
                dgvUsers.Columns["EditUser"].DisplayIndex = 4;
                dgvUsers.Columns["DeleteUser"].DisplayIndex = 5;
                dgvUsers.Columns["EditUser"].Width = 30;
                dgvUsers.Columns["DeleteUser"].Width = 30;
            }
        }
        void _LoadMaintenanceData()
        {
            // get maintenances data and list them

            _dtAllMaintenances = clsMaintenances.GetAll();

            if (_dtAllMaintenances.Rows.Count > 0)
            {
                _dtMaintenances = _dtAllMaintenances.DefaultView.ToTable(false, "MaintenanceID",
                    "Vehicle", "Description", "Cost", "Status");

                dgvMaintenances.DataSource = _dtMaintenances;
                dgvMaintenances.Columns["MaintenanceID"].DisplayIndex = 0;
                dgvMaintenances.Columns["Vehicle"].DisplayIndex = 1;
                dgvMaintenances.Columns["Description"].DisplayIndex = 2;
                dgvMaintenances.Columns["Cost"].DisplayIndex = 3;
                dgvMaintenances.Columns["Status"].DisplayIndex = 4;
            }
        }

        void _LoadData()
        {
            // gather all data in one void function 
            _LoadFuelTypesData();
            _LoadVehicleCategoriesData();
            _LoadUsersData();
            _LoadMaintenanceData();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            btnVehicleCategories.PerformClick();

            // load gathered data
            _LoadData();
        }

        private void dgvVehicleCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvVehicleCategories.Columns["EditVehicleCategory"].Index)
                {
                    // update category
                    frmAddUpdateVehicleCategories frm = new frmAddUpdateVehicleCategories((int)dgvVehicleCategories.CurrentRow.Cells["CategoryID"].Value);
                    frm.ShowDialog();

                    // refresh and view updated data
                    _LoadVehicleCategoriesData();
                }
                else if (e.ColumnIndex == dgvVehicleCategories.Columns["DeleteVehicleCategory"].Index)
                {
                    // delete category
                    if (MessageBox.Show("Are you sure you want to delete Vehicle category [" + dgvVehicleCategories.CurrentRow.Cells["CategoryID"].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Perform Delete and refresh
                        if (clsVehicleCategories.Delete((int)dgvVehicleCategories.CurrentRow.Cells["CategoryID"].Value))
                        {
                            MessageBox.Show("Vehicle Category Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadVehicleCategoriesData();
                        }

                        else
                            MessageBox.Show("Vehicle category was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddNewVehicleCategory_Click(object sender, EventArgs e)
        {
            // add new category
            frmAddUpdateVehicleCategories frm = new frmAddUpdateVehicleCategories();
            frm.ShowDialog();

            // refresh
            _LoadVehicleCategoriesData();
        }

        private void txtVehicleCategoryFilterValue_TextChanged(object sender, EventArgs e)
        {
            // search category
            _dtVehicleCategories.DefaultView.RowFilter = $"CategoryName LIKE '%{txtVehicleCategoryFilterValue.Text}%'";
        }

        private void dgvFuelTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvFuelTypes.Columns["EditFuelType"].Index)
                {
                    // update fuel type
                    frmAddUpdateFuelType frm = new frmAddUpdateFuelType((int)dgvFuelTypes.CurrentRow.Cells["ID"].Value);
                    frm.ShowDialog();

                    // refresh and view updated data
                    _LoadFuelTypesData();
                }
                else if (e.ColumnIndex == dgvFuelTypes.Columns["DeleteFuelType"].Index)
                {
                    // delete fuel type
                    if (MessageBox.Show("Are you sure you want to delete fuel type [" + dgvFuelTypes.CurrentRow.Cells["ID"].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Perform Delete and refresh
                        if (clsFuelTypes.Delete((int)dgvFuelTypes.CurrentRow.Cells["ID"].Value))
                        {
                            MessageBox.Show("Fuel Type Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadFuelTypesData();
                        }

                        else
                            MessageBox.Show("Fuel type was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddNewFuelType_Click(object sender, EventArgs e)
        {
            // add new fuel type
            frmAddUpdateFuelType frm = new frmAddUpdateFuelType();
            frm.ShowDialog();

            // refresh
            _LoadFuelTypesData();
        }

        private void txtFuelTypeFilterValue_TextChanged(object sender, EventArgs e)
        {
            // search fuel type
            _dtFuelTypes.DefaultView.RowFilter = $"FuelType LIKE '%{txtFuelTypeFilterValue.Text}%'";
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // update user 
                if (e.ColumnIndex == dgvUsers.Columns["EditUser"].Index)
                {
                    frmAddUpdateUsers frm = new frmAddUpdateUsers((int)dgvUsers.CurrentRow.Cells["UserID"].Value);
                    frm.ShowDialog();

                    // refresh and view updated data
                    _LoadUsersData();
                }
                else if (e.ColumnIndex == dgvUsers.Columns["DeleteUser"].Index)
                {
                    // delete user
                    if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells["UserID"].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Perform Delete and refresh
                        if (clsUsers.Delete((int)dgvUsers.CurrentRow.Cells["UserID"].Value))
                        {
                            MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadUsersData();
                        }

                        else
                            MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsers frm = new frmAddUpdateUsers();
            frm.ShowDialog();

            _LoadUsersData();
        }

        private void txtUserValueFilter_TextChanged(object sender, EventArgs e)
        {
            _dtUsers.DefaultView.RowFilter = $"FullName LIKE '%{txtUserValueFilter.Text}%' OR Username LIKE '%{txtUserValueFilter.Text}%'";
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            // view Maintenace tab
            tcSettings.SelectedTab = tcSettings.TabPages["tabMaintenance"];
        }

        private void btnAddNewMaintenance_Click(object sender, EventArgs e)
        {
            frmAddUpdateMaintenace frm = new frmAddUpdateMaintenace();
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release the vehicle?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsMaintenances maintenance = clsMaintenances.Find((int)dgvMaintenances.CurrentRow.Cells["MaintenanceID"].Value);

                if (clsMaintenances.ReleaseVehicleAfterMaintenance((int)dgvMaintenances.CurrentRow.Cells["MaintenanceID"].Value, (int)maintenance.VehicleID))
                {
                    MessageBox.Show("Vehicle Released From Maintenance Successfully", "Released",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //refresh
                    _LoadMaintenanceData();
                }
                else
                {
                    MessageBox.Show("Failed To Release Vehicle", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmsReleaseVehicle_Opening(object sender, CancelEventArgs e)
        {
            if (dgvMaintenances.Rows.Count > 0)
                releaseToolStripMenuItem.Enabled = !clsMaintenances.IsMaintenanceCompleted((int)dgvMaintenances.CurrentRow.Cells["MaintenanceID"].Value);
            else
                releaseToolStripMenuItem.Enabled = false;
        }
    }
}

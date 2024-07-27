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
using VehicleRentalManagmentSystem.Customers;
using VehicleRentalManagmentSystem.Vehicles;

namespace VehicleRentalManagmentSystem
{
    public partial class frmListVehicles : Form
    {
        public frmListVehicles()
        {
            InitializeComponent();
        }

        static DataTable _dtAllVehicles = clsVehicles.GetAll();
        DataTable _dtVehicles = _dtAllVehicles.DefaultView.ToTable(false, "VehicleID",
            "Name", "Milage", "FuelType", "PlateNumber", "Category", "PricePerDay");

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.ShowDialog();

            _RefreshData();
        }

        void _RefreshData()
        {
            _dtAllVehicles = clsVehicles.GetAll();
            _dtVehicles = _dtAllVehicles.DefaultView.ToTable(false, "VehicleID",
            "Name", "Milage", "FuelType", "PlateNumber", "Category", "PricePerDay");

            if (_dtVehicles.Rows.Count > 0 )
            {
                dgvAllVehicles.DataSource = _dtVehicles;
                dgvAllVehicles.Columns["VehicleID"].DisplayIndex = 0;
                dgvAllVehicles.Columns["Name"].DisplayIndex = 1;
                dgvAllVehicles.Columns["Milage"].DisplayIndex = 2;
                dgvAllVehicles.Columns["FuelType"].DisplayIndex = 3;
                dgvAllVehicles.Columns["PlateNumber"].DisplayIndex = 4;
                dgvAllVehicles.Columns["Category"].DisplayIndex = 5;
                dgvAllVehicles.Columns["PricePerDay"].DisplayIndex = 6;
                //dgvAllVehicles.Columns["IsAvailable"].DisplayIndex = 7;
                dgvAllVehicles.Columns["View"].DisplayIndex = 7;
                dgvAllVehicles.Columns["Edit"].DisplayIndex = 8;
                dgvAllVehicles.Columns["Delete"].DisplayIndex = 9;
                dgvAllVehicles.Columns["Name"].Width = 150;
                dgvAllVehicles.Columns["View"].Width = 30;
                dgvAllVehicles.Columns["Edit"].Width = 30;
                dgvAllVehicles.Columns["Delete"].Width = 30;
            }

        }

        private void frmListVehicles_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        void OpenChildForm(Form ChildForm)
        {
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            pnlCustomerInfo.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void dgvAllVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvAllVehicles.Columns["View"].Index)
                {
                    OpenChildForm(new frmVehicleInfo((int)dgvAllVehicles.CurrentRow.Cells["VehicleID"].Value));
                }
                else if (e.ColumnIndex == dgvAllVehicles.Columns["Edit"].Index)
                {
                    frmAddUpdateVehicle frm = new frmAddUpdateVehicle((int)dgvAllVehicles.CurrentRow.Cells["VehicleID"].Value);
                    frm.ShowDialog();

                    _RefreshData();
                }
                else if (e.ColumnIndex == dgvAllVehicles.Columns["Delete"].Index)
                {
                    if (MessageBox.Show("Are you sure you want to delete Vehicle [" + dgvAllVehicles.CurrentRow.Cells["VehicleID"].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Perform Delete and refresh
                        if (clsVehicles.Delete((int)dgvAllVehicles.CurrentRow.Cells["VehicleID"].Value))
                        {
                            MessageBox.Show("Vehicle Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshData();
                        }
                        else
                            MessageBox.Show("Vehicle was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _dtVehicles.DefaultView.RowFilter = $"Name LIKE '%{txtFilterValue.Text}%' OR Category LIKE '%{txtFilterValue.Text}%' OR FuelType LIKE '%{txtFilterValue.Text}%'";
        }
    }
}

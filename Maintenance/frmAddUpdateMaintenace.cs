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
using VehicleRentalManagmentSystem.Vehicles;

namespace VehicleRentalManagmentSystem.Maintenance
{
    public partial class frmAddUpdateMaintenace : Form
    {
        public frmAddUpdateMaintenace()
        {
            InitializeComponent();
        }

        clsMaintenances _Maintenance = new clsMaintenances();
        public clsVehicles Vehicle;

        DataTable dtVehicles = clsVehicles.GetAll();
        ctrlVehicleMaintenance ctrl;
        void _ListVehicles()
        {
            if (dtVehicles.Rows.Count > 0)
            {
                for (int i = 0; i < dtVehicles.Rows.Count; i++)
                {
                    ctrl = new ctrlVehicleMaintenance();
                    pnlListVehicles.Controls.Add(ctrl);
                    ctrl.LoadVehicleData(Convert.ToInt32(dtVehicles.Rows[i][0]));

                    ctrl._frmAddUpdateMaintenance = this;
                }
            }
        }

        private void frmAddUpdateMaintenace_Load(object sender, EventArgs e)
        {
            _ListVehicles();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Maintenance.VehicleID = Vehicle.VehicleID;
            _Maintenance.MaintenanceDate = dtpMaintenanceDate.Value;
            _Maintenance.Description = txtDescription.Text.Trim();
            _Maintenance.Cost = Convert.ToDecimal(txtCost.Text.Trim());
            _Maintenance.Status = "On Process";
            _Maintenance.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Maintenance.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed To Save Data", "Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCost.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCost, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtCost, null);
            }
        }
    }
}

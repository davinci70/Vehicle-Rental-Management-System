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
using VehicleRentalManagmentSystem.Properties;

namespace VehicleRentalManagmentSystem.Vehicles
{
    public partial class ctrlVehicleMaintenance : UserControl
    {
        public ctrlVehicleMaintenance()
        {
            InitializeComponent();
        }

        clsVehicles _Vehicle;
        public frmAddUpdateMaintenace _frmAddUpdateMaintenance;

        public void LoadVehicleData(int VehicleID)
        {
            _Vehicle = clsVehicles.Find(VehicleID);

            if (_Vehicle == null)
                _SetDefaultValues();
            else
                _LoadData();
        }

        void _SetDefaultValues()
        {
            pbVehicleImage.Image = Resources.car_placeholder;
            lblVehicleName.Text = "[????]";
        }

        void _LoadData()
        {
            pbVehicleImage.ImageLocation = _Vehicle.ImagePath;
            lblVehicleName.Text = _Vehicle.Name;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _Vehicle = clsVehicles.FindIfAvailable(_Vehicle.VehicleID);

            if ( _Vehicle == null )
            {
                MessageBox.Show("Vehicle Is NOT Available \n (On Rent/Under Maintenance)", "NOT Available",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _frmAddUpdateMaintenance.tcVehicleMaintenance.SelectedTab = _frmAddUpdateMaintenance.tcVehicleMaintenance.TabPages["tabMaintenanceInfo"];
            _frmAddUpdateMaintenance.btnSave.Enabled = true;
            _frmAddUpdateMaintenance.Vehicle = _Vehicle;
        }
    }
}

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
using VehicleRentalManagmentSystem.Bookings;
using VehicleRentalManagmentSystem.Properties;

namespace VehicleRentalManagmentSystem.Vehicles
{
    public partial class ctrlVehicle : UserControl
    {
        public ctrlVehicle()
        {
            InitializeComponent();
        }

        clsVehicles _Vehicle;
        public frmAddUpdateBooking _frm;

        public clsVehicles Vehicle
        { get { return _Vehicle; } }

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
            lblPricePerDay.Text = "[????]";
            lblVehicleName.Text = "[????]";
        }

        void _LoadData()
        {
            pbVehicleImage.ImageLocation = _Vehicle.ImagePath;
            lblVehicleName.Text = _Vehicle.Name;
            lblPricePerDay.Text = _Vehicle.PricePerDay + " Per Day";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _Vehicle = clsVehicles.FindIfAvailable(_Vehicle.VehicleID);

            if (_Vehicle == null)
            {
                MessageBox.Show("Vehicle Is NOT Available \n (On Rent/Under Maintenance)", "NOT Available",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _frm.tabBookingSteps.SelectedTab = _frm.tabBookingSteps.TabPages["StepThree"];
            _frm.Vehicle = _Vehicle;
            _frm.txtPricePerDay.Text = Vehicle.PricePerDay.ToString();
            _frm.lblVehicle.Visible = true;
            _frm.lblVehicle.Text = _Vehicle.Name;            
            _frm.pbBookingImage.Image = Resources.ColoredAppointment;
        }
    }
}

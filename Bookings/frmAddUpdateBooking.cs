using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleRentalManagmentSystem.Global;
using VehicleRentalManagmentSystem.Properties;
using VehicleRentalManagmentSystem.Vehicles;

namespace VehicleRentalManagmentSystem.Bookings
{
    public partial class frmAddUpdateBooking : Form
    {
        public frmAddUpdateBooking()
        {
            InitializeComponent();
        }

        int CustomerID;

        clsBookAndPay _BookAndPay = new clsBookAndPay();

        public clsVehicles Vehicle;
        clsCustomers _Customer;
        ctrlVehicle ctrl;

        DataTable dtVehicles = clsVehicles.GetAll();
       

        private static DataTable _dtAllCustomers;
        private DataTable _dtCustomers;
        private void ListCustomers()
        {
            // get all customers data and list them in data grid view
            _dtAllCustomers = clsCustomers.GetAll();

            if (_dtAllCustomers.Rows.Count > 0)
            {
                _dtCustomers = _dtAllCustomers.DefaultView.ToTable(false,
                "CustomerID", "Name", "LicenseNumber", "PhoneNumber");

                dgvAllCustomers.DataSource = _dtCustomers;

                dgvAllCustomers.Columns["CustomerID"].DisplayIndex = 0;
                dgvAllCustomers.Columns["Name"].DisplayIndex = 1;
                dgvAllCustomers.Columns["LicenseNumber"].DisplayIndex = 2;
                dgvAllCustomers.Columns["PhoneNumber"].DisplayIndex = 3;
            }
        }
        void ListVehicles()
        {
            // get all Vehicles data and list them

            if (dtVehicles.Rows.Count > 0)
            {
                for (int i = 0; i < dtVehicles.Rows.Count; i++)
                {
                    ctrl = new ctrlVehicle();
                    pnlListVehicles.Controls.Add(ctrl);
                    ctrl.LoadVehicleData(Convert.ToInt32(dtVehicles.Rows[i][0]));

                    ctrl._frm = this;
                }
            }
        }
        void _DefaultValues()
        {
            // reset to default values

            Vehicle = ctrl.Vehicle;

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtPickupLocation.Text = "";
            txtDropoffLocation.Text = "";
            txtNotes.Text = "";
            txtPaymentDetails.Text = "";

            pbCustomerImage.Image = Resources.ColoredCustomer;
            pbVehicleImage.Image = Resources.Vehicle__2_;
            pbBookingImage.Image = Resources.appointment;
            lblCustomerName.Visible = true;
            lblVehicle.Visible = false;
        }

        private void frmAddUpdateBooking_Load(object sender, EventArgs e)
        {           
            ListVehicles();
            ListCustomers();
            _DefaultValues();            
        }
        
        private void dgvAllCustomers_DoubleClick(object sender, EventArgs e)
        {
            // get customer id for the customer who owns the booking
            CustomerID = (int)dgvAllCustomers.CurrentRow.Cells["CustomerID"].Value; 

            // proceed to the next step (select the vehicle)
            tabBookingSteps.SelectedTab = tabBookingSteps.TabPages["Vehicles"];

            // find customer by id
            _Customer = clsCustomers.Find(CustomerID);

            if (_Customer != null)
                // if the customer is not null assign their name to customer name label
                lblCustomerName.Text = _Customer.Name;

            // indicate that the next step is on process
            pbVehicleImage.Image = Resources.car__1_;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // assign booking data to the object
            _BookAndPay.CustomerID = CustomerID;
            _BookAndPay.VehicleID = Vehicle.VehicleID;
            _BookAndPay.StartDate = dtpStartDate.Value;
            _BookAndPay.EndDate = dtpEndDate.Value;
            _BookAndPay.DropoffLocation = txtDropoffLocation.Text.Trim();
            _BookAndPay.PickupLocation = txtPickupLocation.Text.Trim();
            _BookAndPay.PricePerDay = Vehicle.PricePerDay;
            _BookAndPay.InitialTotalDueAmount = _BookAndPay.EndDate.Date.Subtract(_BookAndPay.StartDate.Date).Days * _BookAndPay.PricePerDay;
            _BookAndPay.Notes = txtNotes.Text.Trim();
            _BookAndPay.Status = "Ongoing";
            _BookAndPay.Details = txtPaymentDetails.Text.Trim();
            _BookAndPay.InitialPaidTotalDueAmount = Convert.ToDecimal(txtInitialPaidTotalAmount.Text.Trim());
            _BookAndPay.PaymentDate = DateTime.Now;
            _BookAndPay.UpdatedPaymentDate = DateTime.Now;
            _BookAndPay.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_BookAndPay.Save())
            {                                

                if (MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    // after the booking is saved perform these steps
                    _BookAndPay = new clsBookAndPay();
                    tabBookingSteps.SelectedTab = tabBookingSteps.TabPages["Customers"];
                    pnlListVehicles.Controls.Clear();
                    this.frmAddUpdateBooking_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Failed To Save Data", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (Vehicle != null)
            {
                // calculate the period of the booking
                txtDays.Text = (dtpEndDate.Value.Date.Subtract(dtpStartDate.Value.Date).Days).ToString();
                // multiply the vehicle price per day by total days to get initial total amount
                txtInitialTotalAmount.Text = ((dtpEndDate.Value.Date.Subtract(dtpStartDate.Value.Date).Days) * Vehicle.PricePerDay).ToString();
                // same as the previous
                txtInitialPaidTotalAmount.Text = ((dtpEndDate.Value.Date.Subtract(dtpStartDate.Value.Date).Days) * Vehicle.PricePerDay).ToString();
            }
        }

        private void txtPickupLocation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPickupLocation.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPickupLocation, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtPickupLocation, null);
            }
        }

        private void txtDropoffLocation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDropoffLocation.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDropoffLocation, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtDropoffLocation, null);
            }
        }

        private void txtNotes_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotes.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNotes, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtNotes, null);
            }
        }

        private void txtPaymentDetails_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaymentDetails.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPaymentDetails, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtPaymentDetails, null);
            }
        }
    }
}

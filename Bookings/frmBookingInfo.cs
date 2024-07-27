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
using VehicleRentalManagmentSystem.Returns;

namespace VehicleRentalManagmentSystem.Bookings
{
    public partial class frmBookingInfo : Form
    {
        public frmBookingInfo(int BookingID)
        {
            InitializeComponent();

            _BookingID = BookingID;
        }

        int _BookingID;
        clsBookings _Booking;
        clsPayments _Payment;
        clsReturns _Return;

        void _LoadData()
        {
            _Booking = clsBookings.Find(_BookingID);
            _Payment = clsPayments.FindByBookingID(_BookingID);

            if ( _Booking == null || _Payment == null )
            {
                MessageBox.Show("An error has occurred while finding booking with ID ["+_BookingID+"]", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // load booking data
            lblVehicleName.Text = _Booking.VehicleInfo.Name;
            lblBookingID.Text = _BookingID.ToString();
            lblStartDate.Text = _Booking.StartDate.ToString("d");
            lblEndDate.Text = _Booking.EndDate.ToString("d");
            lblFullName.Text = _Booking.CustomerInfo.Name;
            lblPhone.Text = _Booking.CustomerInfo.PhoneNumber;
            lblEmail.Text = _Booking.CustomerInfo.Email;
            lblRentalDays.Text = (_Booking.EndDate.Date - _Booking.StartDate.Date).Days.ToString();
            lblPricePerDay.Text = _Booking.PricePerDay.ToString();
            lblTotalAmount.Text = _Booking.InitialTotalDueAmount.ToString();
            lblPickupLocation.Text = _Booking.PickupLocation;
            lblDropoffLocation.Text = _Booking.DropoffLocation;
            lblNotes.Text = _Booking.Notes;

            if (_Booking.Status == "Completed")
                lblStatus.Text = "Completed";
            else
                lblStatus.Text = "Ongoing";

            if (_Booking.VehicleInfo.ImagePath != null )
                pbVehicleImage.ImageLocation = _Booking.VehicleInfo.ImagePath;

            // load payment data
            lblInitialPaidTotalDueAmount.Text = _Payment.InitialPaidTotalDueAmount.ToString();
            lblPaymentDate.Text = _Payment.PaymentDate.ToString();
            lblUpdatedPaymentDate.Text = _Payment.UpdatedPaymentDate.ToString();
            lblUsername.Text = _Payment.UserInfo.Username;
            lblDetails.Text = _Payment.Details;

            if (_Payment.ActualTotalDueAmount.HasValue)
                lblActualTotalAmount.Text = _Payment.ActualTotalDueAmount.ToString();
            else
                lblActualTotalAmount.Text = "Not calculated yet";

            if (_Payment.TotalRemaining.HasValue)
                lblTotalRemaining.Text = _Payment.TotalRemaining.ToString();
            else
                lblTotalRemaining.Text = "Not Calculated yet";

            if (_Payment.TotalRefundedAmount.HasValue)
                lblTotalRefundedAmount.Text = _Payment.TotalRefundedAmount.ToString();
            else
                lblTotalRefundedAmount.Text = "Not calculated yet";


            btnReturnVehicle.Enabled = (!_Payment.ReturnID.HasValue);

            // load return data
            if ( _Payment.ReturnID.HasValue )
            {
                pnlReturn.Visible = true;
                pnlVehicleOnRent.Visible = false;

                _Return = clsReturns.Find(_Payment.ReturnID);

                if (_Return != null )
                {
                    lblActualRentalDays.Text = _Return.ActualRentalDays.ToString();
                    lblActualReturnDate.Text = _Return.ActualReturnDate.ToString();
                    lblConsumedMilage.Text = _Return.ConsumedMilage.ToString();
                    lblAdditionalCharges.Text = _Return.AdditionalCharges.ToString();
                    lblFinalCheckNotes.Text = _Return.FinalCheckNotes;
                    lblCreatedBy.Text = _Return.UserInfo.Username;
                }                
            }
            else
            {
                pnlReturn.Visible = false;
                pnlVehicleOnRent.Visible = true;
            }
        }

        private void frmBookingInfo_Load(object sender, EventArgs e)
        {
            _LoadData();           
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            tcBookingDetails.SelectedTab = tcBookingDetails.TabPages["tabInfo"];
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            tcBookingDetails.SelectedTab = tcBookingDetails.TabPages["tabPayments"];
        }

        private void btnReturnVehicle_Click(object sender, EventArgs e)
        {
            frmReturnVehicle frm = new frmReturnVehicle(_Booking, _Payment);
            frm.ShowDialog();

            // refresh
            _LoadData();
        }

        private void btnReturnTab_Click(object sender, EventArgs e)
        {
            tcBookingDetails.SelectedTab = tcBookingDetails.TabPages["tabReturn"];
        }

    }
}

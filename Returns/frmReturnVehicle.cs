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

namespace VehicleRentalManagmentSystem.Returns
{
    public partial class frmReturnVehicle : Form
    {
        public frmReturnVehicle(clsBookings Booking, clsPayments payment)
        {
            InitializeComponent();

            _Booking = Booking;
            _Payment = payment;
        }

        clsBookings _Booking;
        clsPayments _Payment;
        clsReturnAndUpdate _Return = new clsReturnAndUpdate();

        private void frmReturnVehicle_Load(object sender, EventArgs e)
        {
            dtpReturnDate.Value = DateTime.Now;
            txtActualTotalDueAmount.Text = ((dtpReturnDate.Value.Date - _Booking.StartDate.Date).Days * _Booking.PricePerDay).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Return.ActualReturnDate = dtpReturnDate.Value;
            _Return.ActualRentalDays = Convert.ToByte(txtActualRentalDays.Text);
            _Return.ConsumedMilage = Convert.ToInt16(txtConsumedMilage.Text);

            if (!string.IsNullOrWhiteSpace(txtFinalCheckNotes.Text))
                _Return.FinalCheckNotes = txtFinalCheckNotes.Text;
            else
                _Return.FinalCheckNotes = "No Notes";

            if (!string.IsNullOrWhiteSpace(txtAdditionalCharges.Text))
                _Return.AdditionalCharges = Convert.ToDecimal(txtAdditionalCharges.Text);
            else
                _Return.AdditionalCharges = 0;

            _Return.ActualTotalDueAmount = Convert.ToDecimal(txtActualTotalDueAmount.Text);
            _Return.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _Return.InitialPaidTotalDueAmount = _Payment.InitialPaidTotalDueAmount;
            _Return.VehicleID = _Booking.VehicleID;
            _Return.Milage = _Booking.VehicleInfo.Milage;
            _Return.PaymentID = _Payment.PaymentID;
            _Return.BookingID = _Booking.BookingID;

            if (_Return.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed to save data", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReturnDate.Value.Date == _Booking.EndDate.Date)
            {
                txtActualRentalDays.Text = _Booking.ActualRentalDays().ToString();
                txtActualTotalDueAmount.Text = _Booking.InitialTotalDueAmount.ToString();
            }
            else
            {
                txtActualRentalDays.Text = (dtpReturnDate.Value.Date - _Booking.StartDate.Date).Days.ToString();
                txtActualTotalDueAmount.Text = ((dtpReturnDate.Value.Date - _Booking.StartDate.Date).Days * _Booking.PricePerDay).ToString();
            }               
        }

        private void txtAdditionalCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-';
        }

        private void txtAdditionalCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtAdditionalCharges.Text))
                    txtActualTotalDueAmount.Text = (Convert.ToDecimal(txtActualTotalDueAmount.Text) + Convert.ToDecimal(txtAdditionalCharges.Text)).ToString();
            }
        }

        private void txtConsumedMilage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConsumedMilage.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConsumedMilage, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtConsumedMilage, null);
            }
        }

    }
}

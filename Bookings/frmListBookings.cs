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

namespace VehicleRentalManagmentSystem.Bookings
{
    public partial class frmListBookings : Form
    {
        public frmListBookings(frmMain Main)
        {
            InitializeComponent();

            _frmMain = Main;
        }

        frmMain _frmMain;

        private static DataTable _dtAllBookings;

        private DataTable _dtBookings;

        void _LoadData()
        {
            // load bookings data and list them in data grid view
            _dtAllBookings = clsBookings.GetAll();

            if (_dtAllBookings.Rows.Count > 0)
            {
                _dtBookings = _dtAllBookings.DefaultView.ToTable(false, "BookingID", "Customer", "Vehicle",
                    "Start Date", "End Date", "Status", "Created By");

                dgvAllBookings.DataSource = _dtBookings;

                dgvAllBookings.Columns["BookingID"].DisplayIndex = 0;
                dgvAllBookings.Columns["Customer"].DisplayIndex = 1;
                dgvAllBookings.Columns["Vehicle"].DisplayIndex = 2;
                dgvAllBookings.Columns["Start Date"].DisplayIndex = 3;
                dgvAllBookings.Columns["End Date"].DisplayIndex = 4;
                dgvAllBookings.Columns["Status"].DisplayIndex = 5;
                dgvAllBookings.Columns["Created By"].DisplayIndex = 6;
                dgvAllBookings.Columns["View"].DisplayIndex = 7;
                dgvAllBookings.Columns["Delete"].DisplayIndex = 8;

                dgvAllBookings.Columns["BookingID"].Width = 80;
                dgvAllBookings.Columns["Created By"].Width = 90;
                dgvAllBookings.Columns["Vehicle"].Width = 150;
                dgvAllBookings.Columns["View"].Width = 30;
                dgvAllBookings.Columns["Delete"].Width = 30;
            }
        }

        private void frmListBookings_Load(object sender, EventArgs e)
        {
             _LoadData();
        }

        void OpenChildForm(Form ChildForm)
        {
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            _frmMain.pnlHome.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void btnAddNewBooking_Click(object sender, EventArgs e)
        {
            frmAddUpdateBooking frm = new frmAddUpdateBooking();
            frm.ShowDialog();

            // refresh
            _LoadData();
        }

        private void dgvAllBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvAllBookings.Columns["View"].Index)
                {
                    OpenChildForm(new frmBookingInfo((int)dgvAllBookings.CurrentRow.Cells["BookingID"].Value));
                }
                else if (e.ColumnIndex == dgvAllBookings.Columns["Delete"].Index)
                {
                    if (MessageBox.Show("Are you sure you want to delete booking [" + dgvAllBookings.CurrentRow.Cells["BookingID"].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Perform Delete and refresh
                        if (clsBookings.Delete((int)dgvAllBookings.CurrentRow.Cells["BookingID"].Value))
                        {
                            MessageBox.Show("Booking Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadData();                            
                        }

                        else
                            MessageBox.Show("Booking was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

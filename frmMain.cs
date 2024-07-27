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
using VehicleRentalManagmentSystem.Settings;
using Microsoft.Win32;
using VehicleRentalManagmentSystem.Bookings;
using VehicleRentalManagmentSystem.Dashboard;

namespace VehicleRentalManagmentSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.btnDashboard.PerformClick();
        }

        Form CurrentForm;

        void OpenChildForm(Form ChildForm)
        {
            CurrentForm = ChildForm;

            CurrentForm.TopLevel = false;
            CurrentForm.FormBorderStyle = FormBorderStyle.None;
            CurrentForm.Dock = DockStyle.Fill;

            pnlHome.Controls.Add(CurrentForm);
            CurrentForm.BringToFront();
            CurrentForm.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListCustomers());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListVehicles());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSettings());
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListBookings(this));
        }
    }
}

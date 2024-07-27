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
using System.Windows.Forms.DataVisualization.Charting;

namespace VehicleRentalManagmentSystem.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _LoadData();
            _LoadChartsData();
        }

        void _LoadData()
        {
            lblCountBookings.Text = clsBookings.CountBookings().ToString();
            lblCountOnRent.Text = clsBookings.CountOnRent().ToString();
            lblCountReturns.Text = clsPayments.CountReturns().ToString();
            lblCountMaintenance.Text = clsMaintenances.CountUnderMaintenance().ToString(); 
        }

        void _LoadChartsData()
        {
            chart1.Series["Series1"].Points[0].SetValueY(clsVehicles.CountVehiclesByCategory("Sedan"));
            chart1.Series["Series1"].Points[1].SetValueY(clsVehicles.CountVehiclesByCategory("Pickup"));
            chart1.Series["Series1"].Points[2].SetValueY(clsVehicles.CountVehiclesByCategory("Motorcycles"));

            chart2.Series["Series2"].Points.AddXY(DateTime.Now.AddMonths(0).ToString("MMMM"), 3000);
            chart2.Series["Series2"].Points.AddXY(DateTime.Now.AddMonths(-1).ToString("MMMM"), 3500);
            //chart2.Series["Series2"].Points.AddXY(DateTime.Now.AddMonths(-1).ToString("MMMM"), clsPayments.GetTotalRevenueByMonth(DateTime.Now.Month - 1));
            chart2.Series["Series2"].Points.AddXY(DateTime.Now.AddMonths(-2).ToString("MMMM"), 2000);
            //chart2.Series["Series2"].Points.AddXY(DateTime.Now.AddMonths(-2).ToString("MMMM"), clsPayments.GetTotalRevenueByMonth(DateTime.Now.Month - 2));
        }
    }
}

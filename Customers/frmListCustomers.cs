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

namespace VehicleRentalManagmentSystem.Customers
{
    public partial class frmListCustomers : Form
    {
        public frmListCustomers()
        {
            InitializeComponent();
        }

        private static DataTable _dtAllCustomers;
        private DataTable _dtCustomers;

        private void _LoadData()
        {
            _dtAllCustomers = clsCustomers.GetAll();
            
            if ( _dtAllCustomers.Rows.Count > 0 )
            {
                _dtCustomers = _dtAllCustomers.DefaultView.ToTable(false,
                "CustomerID", "Name", "LicenseNumber", "PhoneNumber");

                dgvAllCustomers.DataSource = _dtCustomers;

                dgvAllCustomers.Columns["CustomerID"].DisplayIndex = 0;
                dgvAllCustomers.Columns["Name"].DisplayIndex = 1;
                dgvAllCustomers.Columns["LicenseNumber"].DisplayIndex = 2;
                dgvAllCustomers.Columns["PhoneNumber"].DisplayIndex = 3;
                dgvAllCustomers.Columns["View"].DisplayIndex = 4;
                dgvAllCustomers.Columns["Edit"].DisplayIndex = 5;
                dgvAllCustomers.Columns["Delete"].DisplayIndex = 6;

                dgvAllCustomers.Columns["View"].Width = 30;
                dgvAllCustomers.Columns["Edit"].Width = 30;
                dgvAllCustomers.Columns["Delete"].Width = 30;
            }
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

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();

            _LoadData();
        }

        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void dgvAllCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvAllCustomers.Columns["View"].Index)
                {
                    OpenChildForm(new frmCustomerInfo((int)dgvAllCustomers.CurrentRow.Cells["CustomerID"].Value));
                }
                else if (e.ColumnIndex == dgvAllCustomers.Columns["Edit"].Index)
                {
                    frmAddUpdateCustomer frm = new frmAddUpdateCustomer((int)dgvAllCustomers.CurrentRow.Cells["CustomerID"].Value);
                    frm.ShowDialog();

                    _LoadData();
                }
                else if (e.ColumnIndex == dgvAllCustomers.Columns["Delete"].Index)
                {
                    if (MessageBox.Show("Are you sure you want to delete Customer [" + dgvAllCustomers.CurrentRow.Cells["CustomerID"].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Perform Delete and refresh
                        if (clsCustomers.Delete((int)dgvAllCustomers.CurrentRow.Cells["CustomerID"].Value))
                        {
                            MessageBox.Show("Customer Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadData();
                        }

                        else
                            MessageBox.Show("Customer was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _dtCustomers.DefaultView.RowFilter = $"Name LIKE '%{txtFilterValue.Text}%' OR LicenseNumber LIKE '%{txtFilterValue.Text}%'";
        }
    }
}

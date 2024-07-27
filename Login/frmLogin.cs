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
using Microsoft.Win32;

namespace VehicleRentalManagmentSystem.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            // get stored username and password if there were
            clsGlobal.GetStoredUsernameAndPasswordFromWindowsRegistry(ref Username, ref Password);

            if (Username != "" &&  Password != "")
            {
                // set username and password to textboxes
                txtUsername.Text = Username;
                txtPassword.Text = Password;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // find user by given username and password
            clsUsers User = clsUsers.FindByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (User != null)
            {
                if (chkRememberMe.Checked)
                {
                    // if chkRememverMe is checked
                    // then store username and password to windows registry
                    clsGlobal.RememberUsernameAndPasswordInWindowsRegistry(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    // if chkRememverMe is unchecked
                    // then store empty values to windows registry
                    clsGlobal.RememberUsernameAndPasswordInWindowsRegistry("", "");
                }

                // make the found user is the global user
                clsGlobal.CurrentUser = User;

                // hide login form
                this.Hide();

                // open the system
                frmMain frm = new frmMain();
                frm.Show();
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

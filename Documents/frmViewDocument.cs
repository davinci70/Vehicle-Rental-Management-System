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

namespace VehicleRentalManagmentSystem.Documents
{
    public partial class frmViewDocument : Form
    {
        public frmViewDocument(clsDocuments Document)
        {
            InitializeComponent();
            _Document = Document;
        }

        clsDocuments _Document;

        private void frmViewDocument_Load(object sender, EventArgs e)
        {

            if (_Document != null)
            {
                pbDocument.ImageLocation = _Document.Path;
                lblDocumentName.Text = _Document.Name;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

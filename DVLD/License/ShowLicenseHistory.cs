using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class ShowLicenseHistory : Form
    {
        private int _PersonID;
        public ShowLicenseHistory(int PersonID)
        {
            InitializeComponent();

            this._PersonID = PersonID;

        }

 

        private void ShowLicensesHistory1_Load(object sender, EventArgs e)
        {
            showLicensesHistory1.LoadAllInfo(_PersonID);
        }

        private void ShowLicenseHistory_Load(object sender, EventArgs e)
        {

        }

        private void BtClose_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

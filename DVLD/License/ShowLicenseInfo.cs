using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDVLDLayer;

namespace DVLD.License
{
    public partial class ShowLicenseInfo : Form
    {
        private int _LicenseID;

        public ShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            this._LicenseID = LicenseID;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            licenseInfo1.LoadLicenseInfo(_LicenseID);
        }
    }
}

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
    public partial class ShowInternationaLicenseInfo : Form
    {
        private int _InternationaLicenseID = -1;
        public ShowInternationaLicenseInfo(int InternationaLicenseID)
        {
            InitializeComponent();
            this._InternationaLicenseID = InternationaLicenseID;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ShowInternationaLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_InternationaLicenseID != -1)
            {
                internationalLicenseInfo1.LoadInfo(_InternationaLicenseID);
            }
        }
    }
}

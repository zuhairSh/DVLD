using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DL_Services.LocalDrivingLicenseApplication
{
    public partial class ShowApplicationInfo : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public ShowApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void ShowApplicationInfo_Load(object sender, EventArgs e)
        {
            lDrivingLicenseApplicationInfo1.LoadAllInfo(_LocalDrivingLicenseApplicationID);
        }

        private void LDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}

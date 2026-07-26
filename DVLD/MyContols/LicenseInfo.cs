using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDVLDLayer;


namespace DVLD.MyContols
{
    public partial class LicenseInfo : UserControl
    {
        public int LicenseID = -1;
        private clsLicense _License;
        public LicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            this.LicenseID = LicenseID;

            this._License = clsLicense.Find(LicenseID);

            if(this._License == null)
            {
                MessageBox.Show("The License is NOT Found !!.",
                    "NOT Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                lblLicenseID.Text = _License.LicenseID.ToString();
                lblIsActive.Text = _License.IsActive ? "Yes" : "No";

                lblIsDetained.Text = clsDetainedAndReleaseLicense.IsLicenseDetained(_License.LicenseID)
                    ? "Detained" : "UnDetained";

                lblClass.Text = _License.LicenseClassIfo.ClassName;
                lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
                lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
                lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
                lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("yyy-mm-dd");

                lblDriverID.Text = _License.DriverID.ToString();
                lblIssueDate.Text = _License.IssueDate.ToString("yyy-mm-dd"); ;
                lblExpirationDate.Text = _License.ExpirationDate.ToString("yyy-mm-dd"); ;
                lblIssueReason.Text = _License.IssueReasonText;
                lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
                _LoadPersonImage();


            }
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void LicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

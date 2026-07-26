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

namespace DVLD.DL_Services.ReplacementDamagedLostLicenses
{
    public partial class ReplacementDamagedLostLicenses : Form
    {
        public ReplacementDamagedLostLicenses()
        {
            InitializeComponent();
        }

     

        

        private void ReplacementDamagedLostLicenses_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = GlobalClass.clsSettingLogin.CurretUser.UserName;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;

        }

        private void RadioDamagedLicenses_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement Damaged Licenses";
            lblMode.Text = "Replacement Damaged Licenses";

            lblApplicationFees.Text = 
                clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).ApplicationFees.ToString();

        }

        private void RadioLostLicenses_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement LostLicenses";
            lblMode.Text = "Replacement LostLicenses";

            lblApplicationFees.Text = 
                clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).ApplicationFees.ToString();

        }

        private void FilterLicense1_OnLicenseSelected(int obj)
        {
            int OldLicenseID = obj;

            lblLocalLicenseID.Text = OldLicenseID.ToString();
            linkLabel1.Enabled = true;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License.ShowLicenseHistory licenseHistory =
                new License.ShowLicenseHistory(filterLicense1.SelectedLicenseInfo.DriverInfo.PersonID);

            licenseHistory.ShowDialog();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License.ShowLicenseInfo licenseInfo = 
                new License.ShowLicenseInfo(filterLicense1.SelectedLicenseInfo.LicenseID);

            licenseInfo.ShowDialog();
        }

        private bool _ValidateLicenseForReplacement()
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please select a license first!", "License Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!radioDamagedLicenses.Checked && !radioLostLicenses.Checked)
            {
                MessageBox.Show("Please select an issue type (Damaged or Lost) for replacement!", "Replacement Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!filterLicense1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is NOT Active, please choose an active license.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (filterLicense1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is Expired. You should Renew it first before requesting a replacement.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void BtIssueReplacement_Click(object sender, EventArgs e)
        {

            if (!_ValidateLicenseForReplacement())
                return;

            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
            

            clsLicense NewLicense;

            if (radioLostLicenses.Checked)
            {
                NewLicense = 
                filterLicense1.SelectedLicenseInfo.ReplaceLostLicense(GlobalClass.clsSettingLogin.CurretUser.UserID);
            }
            else
            {
                NewLicense =
                filterLicense1.SelectedLicenseInfo.ReplaceDamaged(GlobalClass.clsSettingLogin.CurretUser.UserID);
            }

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a Replacment License!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lbLicenseID.Text = NewLicense.LicenseID.ToString();

            MessageBox.Show("License Replaced Successfully with ID = " + NewLicense.LicenseID,
                            "License Replaced",MessageBoxButtons.OK, MessageBoxIcon.Information);
            btIssueReplacement.Enabled = false;
            filterLicense1.Enabled = false;
            groupBox1.Enabled = false;

            linkLabel2.Enabled = true;
        
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LblMode_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace DVLD.DL_Services.International_Driving_License
{
    public partial class NewInternationalDrivingLicense : Form
    {
        private int _InternationalLicenseID = -1;

        public NewInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = GlobalClass.clsSettingLogin.CurretUser.UserName;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            lblFees.Text = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lbIssueDate.Text = lblApplicationDate.Text;

        }

        private void NewInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            
            _LoadInfo();
        }

        private void BtIssue_Click(object sender, EventArgs e)
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid local license first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to issue the license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

     
            InternationalLicense.ApplicantPersonID = filterLicense1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees;
            InternationalLicense.CreatedByUserID = GlobalClass.clsSettingLogin.CurretUser.UserID;

            InternationalLicense.DriverID = filterLicense1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = filterLicense1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lbLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();

            MessageBox.Show("International License Issued Successfully with ID = " + InternationalLicense.InternationalLicenseID.ToString(),
                            "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btIssue.Enabled = false;
            filterLicense1.Enabled = false;
        }

        private void FilterLicense1_Load(object sender, EventArgs e)
        {

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid license first!", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            License.ShowLicenseInfo showLicenseInfo = 
                new License.ShowLicenseInfo(filterLicense1.SelectedLicenseInfo.LicenseID);

            showLicenseInfo.ShowDialog();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid local license first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            License.ShowLicenseHistory showLicenseHistory =
                new License.ShowLicenseHistory(filterLicense1.SelectedLicenseInfo.DriverInfo.PersonID);

            showLicenseHistory.ShowDialog();
        }

        private void FilterLicense1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lbLicenseID.Text = filterLicense1.SelectedLicenseInfo.LicenseID.ToString();

        }
    }
}
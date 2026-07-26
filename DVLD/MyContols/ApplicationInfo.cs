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
using BusinessDVLDLayerPeople;

namespace DVLD.MyContors
{
    public partial class ApplicationInfo : UserControl
    {
        private clsApplication Application;
        public ApplicationInfo()
        {
            InitializeComponent();
        }

        private void ApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            Application = clsApplication.FindBaseApplication(ApplicationID);
            if (Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _LoadAllInfo();
        }


        private void _LoadAllInfo()
        {
            lblApplicationID.Text = Application.ApplicationID.ToString();
            lblDate.Text = Application.ApplicationDate.ToString("yyyy-MM-dd");
            lblFees.Text = Application.PaidFees.ToString();
            lblStatus.Text = Application.StatusText;
            lblType.Text = Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblCreatedByUser.Text = GlobalClass.clsSettingLogin.CurretUser.UserID.ToString();
            lblApplicant.Text = Application.ApplicantFullName;
            lblStatusDate.Text = Application.LastStatusDate.ToString("yyyy-MM-dd");
        }

        public void ResetApplicationInfo()
        {
            

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }

        private void LlViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            People.clsShowDetailsPerson showDetailsPerson =
                new People.clsShowDetailsPerson(Application.ApplicantPersonID);

            showDetailsPerson.ShowDialog();

            _LoadAllInfo();
        }
    }
}

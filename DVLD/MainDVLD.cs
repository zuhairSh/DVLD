using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.GlobalClass;
using DVLD.Users;

namespace DVLD
{
    public partial class MainDVLD : Form
    {
        LoginScreen _frmLogin;
        public MainDVLD(LoginScreen frm )
        {
            InitializeComponent();
            _frmLogin = frm;
        }  
   

        private void PebuleMenuItem_Click(object sender, EventArgs e)
        {
            People.MainPeople mainPeople = new People.MainPeople();
            mainPeople.ShowDialog();

        }

        

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.MainUsers mainUsers = new Users.MainUsers();
            mainUsers.ShowDialog();
        }

        
        private void CurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ShowDetailsUser detailsUser = new ShowDetailsUser(clsSettingLogin.CurretUser.UserID);
           detailsUser.ShowDialog();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(clsSettingLogin.CurretUser.UserID);
            changePassword.ShowDialog();
        }



        private void SingOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsSettingLogin.CurretUser = null;
            this.Hide();
            _frmLogin.Show();

        }

        private void MainDVLD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationType.MainApplicationTypes mainApplicationTypes = new ApplicationType.MainApplicationTypes();
            mainApplicationTypes.ShowDialog();
        }

        private void TestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypes.MainTestTypes mainTestTypes = new TestTypes.MainTestTypes();
            mainTestTypes.ShowDialog();
        }

        private void LocalLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.NewDL.AddEditLocalLicense addEditLocalLicense =
                new DL_Services.NewDL.AddEditLocalLicense(-1);

            addEditLocalLicense.ShowDialog();
        }

        private void LocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.LocalDrivingLicenseApplication.ManageLocalDrivingLicenseApplication manageLocalDrivingLicense =
                new DL_Services.LocalDrivingLicenseApplication.ManageLocalDrivingLicenseApplication();
            manageLocalDrivingLicense.ShowDialog();
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drivers.MainDrivers mainDrivers = new Drivers.MainDrivers();
            mainDrivers.ShowDialog();
        }

        private void InternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.International_Driving_License.NewInternationalDrivingLicense newInternational
                = new DL_Services.International_Driving_License.NewInternationalDrivingLicense();

            newInternational.ShowDialog();

        }

        private void InternationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.International_Driving_License.ManageInternationalDrivingLicense 
                manageInternationalDriving =
               new DL_Services.International_Driving_License.ManageInternationalDrivingLicense();

            manageInternationalDriving.ShowDialog();
        }

        private void MainDVLD_Load(object sender, EventArgs e)
        {

        }

        private void RenewLocalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.RenewLocalDrivingLicense.RenewLocalDrivingLicense renewLocalDriving = 
                new DL_Services.RenewLocalDrivingLicense.RenewLocalDrivingLicense();

            renewLocalDriving.ShowDialog();
        }

        private void ReplacementDamagedOrLostLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.ReplacementDamagedLostLicenses.ReplacementDamagedLostLicenses ReplacementLicense
                = new DL_Services.ReplacementDamagedLostLicenses.ReplacementDamagedLostLicenses();

            ReplacementLicense.ShowDialog();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DL_Services.DetainLicense.NewDetainLicense detainLicense = 
                new DL_Services.DetainLicense.NewDetainLicense();
            detainLicense.ShowDialog();
        }

        private void ManageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.ReleaseLicense.ReleaseLicense releaseLicense = 
                new DL_Services.ReleaseLicense.ReleaseLicense();

            releaseLicense.ShowDialog();
        }

        private void ReleaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.ReleaseLicense.ReleaseLicense releaseLicense =
               new DL_Services.ReleaseLicense.ReleaseLicense();

            releaseLicense.ShowDialog();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DL_Services.ReleaseLicense.MainDetainedLicenses mainDetainedLicenses = 
                new DL_Services.ReleaseLicense.MainDetainedLicenses();

            mainDetainedLicenses.ShowDialog();
        }
    }
}

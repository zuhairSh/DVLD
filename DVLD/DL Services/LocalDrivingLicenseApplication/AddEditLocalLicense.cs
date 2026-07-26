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

namespace DVLD.DL_Services.NewDL
{
    public partial class AddEditLocalLicense : Form
    {
        private enum enMode { eAdd = 0, eUpdate = 1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public AddEditLocalLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (this._LocalDrivingLicenseApplicationID == -1)
            {
                _Mode = enMode.eAdd;
            }
            else
                _Mode = enMode.eUpdate;
        }


        private void _FillComboBoxLicenseClass()
        {
            DataTable dataTable = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["ClassName"].ToString());
            }

            comboBox1.SelectedIndex = 2;
        }


        private void _LoadDataOfEditMode()
        {
            this.Text = "Edit Local Driving License Application";
            labMode.Text = "Edit Local Driving License Application";
            displayFilter1.Enabled = false;

            labUserName.Text = GlobalClass.clsSettingLogin.CurretUser.UserName;

            labID.Text = _LocalDrivingLicenseApplicationID.ToString();

            _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            labDate.Text = DateTime.Now.ToString();
            labFees.Text = clsApplicationTypes.FindApplicationType
            ((int)clsLocalDrivingLicenseApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();


            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("This Local Driving License Application is Not Found in Data !!");
                this.Close();
                return;
            }

            clsPeople Person =
                clsPeople.FindPersonByID(_LocalDrivingLicenseApplication.ApplicantPersonID);

            displayFilter1.Person = Person;
            displayFilter1._DownData(Person);
        }

        private void _SendDefaultValue()
        {
            displayFilter1.textBox1.Focus();
            _FillComboBoxLicenseClass();

            if (_Mode == enMode.eAdd)
            {
                this.Text = "Add Local Driving License Application";
                labMode.Text = "Add Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                labUserName.Text = GlobalClass.clsSettingLogin.CurretUser.UserName;
                labDate.Text = DateTime.Now.ToString();
                labFees.Text = clsApplicationTypes.FindApplicationType
                ((int)clsLocalDrivingLicenseApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();



                return;
            }

            else
            {

                _LoadDataOfEditMode();

            }
        }


        private void AddEditLocalLicense_Load(object sender, EventArgs e)
        {
            _SendDefaultValue();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (displayFilter1.Person == null)
            {
                MessageBox.Show("Please select a person first!", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsLicenseClasses.Find(comboBox1.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(displayFilter1.Person.PersonID, 
                clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }


            

            _LocalDrivingLicenseApplication.ApplicantPersonID = displayFilter1.Person.PersonID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LicenseClassID = comboBox1.SelectedIndex + 1;
            _LocalDrivingLicenseApplication.CreatedByUserID = GlobalClass.clsSettingLogin.CurretUser.UserID;
            _LocalDrivingLicenseApplication.PaidFees = float.Parse(labFees.Text);
    

            if (_LocalDrivingLicenseApplication.Save())
            {
                
                _Mode = enMode.eUpdate;
                _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                _LoadDataOfEditMode();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
              , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            if (displayFilter1.Person != null)
            {
                tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                MessageBox.Show("Please select any Person!!", "Verified"
              , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtPrev_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
    }
}

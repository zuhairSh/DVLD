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

namespace DVLD.TestAppointment
{
    public partial class TakeTest : Form
    {
        private int _TestAppointmentID = -1;
        private clsTestType.enTestType _TestTypeID;
        private clsTest _Test;

        public TakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            this._TestAppointmentID = TestAppointmentID;
            this._TestTypeID = TestTypeID;

        }

        private void _LoadInfo()
        {
            if(_TestAppointmentID == -1)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            else
            {
                scheduledTest1.TestTypeID = this._TestTypeID;

                scheduledTest1.LoadInfo(this._TestAppointmentID);

                if (scheduledTest1.TestAppointmentID == -1)
                    btSave.Enabled = false;
                else
                    btSave.Enabled = true;


                int _TestID = scheduledTest1.TestID;
                if (_TestID != -1)
                {
                    _Test = clsTest.Find(_TestID);

                    if (_Test.TestResult)
                        rbPass.Checked = true;
                    else
                        rbFail.Checked = true;
                    txtNotes.Text = _Test.Notes;

                    lblUserMessage.Visible = true;
                    rbFail.Enabled = false;
                    rbPass.Enabled = false;
                }

                else
                    _Test = new clsTest();
            }
        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?" +
                " After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = GlobalClass.clsSettingLogin.CurretUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btSave.Enabled = false;

                this.Close();

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                

            }

        }

        private void ScheduledTest1_Load(object sender, EventArgs e)
        {

        }
    }
}

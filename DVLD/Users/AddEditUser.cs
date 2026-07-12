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
using DVLD.People;

namespace DVLD.Users
{
    public partial class AddEditUser : Form
    {
        public clsUser User;
        enum enModes { eAddNew = 0, eUpdate = 1 };
        private enModes _Mode;
        public int UserID;


         
        
        public AddEditUser(int UserID)
        {
            InitializeComponent();

            this.UserID = UserID;

            if (UserID == -1)
            {
                _Mode = enModes.eAddNew;

            }
            else
            {
                _Mode = enModes.eUpdate;
            }
        }


        private void _LoadData()
        {

            if (_Mode == enModes.eAddNew)
            {
                labMode.Text = "Add User";
                User = new clsUser();

                return;

            }
            else
            {
                labMode.Text = "Edit User";

                labUserID.Text = UserID.ToString();


                User = clsUser.FindUser(UserID);

                if (User == null)
                {
                    MessageBox.Show("This User id Not Found in Data !!");
                    this.Close();
                    return;
                }

                clsPeople Person = clsPeople.FindPersonByID(User.PersonID);
                displayFilter1.Person = Person;

                displayFilter1._DownData(Person);    
                labUserID.Text = UserID.ToString();
                textUserName.Text = User.UserName;
                textPassword.Text = User.Password;
                textPassword2.Text = User.Password;

                checkBox1.Checked = User.isActive;
            }
        }


        private bool _Verified()
        {
            bool isValid = true;

            string ErroeMess = "Please fill in the required fields";

            if (string.IsNullOrWhiteSpace(textUserName.Text))
            {
                errorProvider1.SetError(textUserName, ErroeMess);
                isValid = false;
            }
            else { errorProvider1.SetError(textUserName, ""); }


            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                errorProvider1.SetError(textPassword, ErroeMess);
                isValid = false;
            }
            else { errorProvider1.SetError(textPassword, ""); }

            if (string.IsNullOrWhiteSpace(textPassword2.Text))
            {
                errorProvider1.SetError(textPassword2, ErroeMess);
                isValid = false;
            }
            else { errorProvider1.SetError(textPassword2, ""); }

            if (textPassword2.Text != textPassword.Text)
            {
                errorProvider1.SetError(textPassword2, "Password does not match");
                isValid = false;
            }
            else { errorProvider1.SetError(textPassword2, ""); }

            

            return isValid;

        }

        private bool _VerifieduserAlreadyThere(string txt)
        {
            bool Verified = true;

            if (displayFilter1.comboBox1.SelectedIndex == 0)
            {
                int.TryParse(txt, out int PersonID);
                if (clsUser.IsUserExistByPersonID(PersonID))
                {
                    return Verified = false;

                }
                else
                    return Verified = true;
            }
            else
            {
                if (clsUser.isUserExist(txt))
                {
                    return Verified = false;

                }
                else
                    return Verified = true;
            }

            return Verified;
        }

        private bool _VerifiedUserisFoundAlready()
        {
            if (!_VerifieduserAlreadyThere(displayFilter1.textBox1.Text))
            {
                return false;  
            }
            else
            {
                return true;
            }
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ShowDetails1_Load(object sender, EventArgs e)
        {
            btPrev.Visible = (tabControl1.SelectedTab != tabPage2);
        }

        private void DisplayFilter1_Load(object sender, EventArgs e)
        {

        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            if(displayFilter1.Person != null)
            {
                if (!_VerifieduserAlreadyThere(displayFilter1.textBox1.Text))
                {
                    MessageBox.Show("The user is already there !!", "Verified"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    tabControl1.SelectedTab = tabPage2;
                }
                
            }
            else
            {
                MessageBox.Show("Please select a person !!", "Verified"
               , MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
                

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

       

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtClose_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

 
        private void BtSave_Click(object sender, EventArgs e)
        {
            if (displayFilter1.Person == null)
            {
                MessageBox.Show("Please select a person first!", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_VerifiedUserisFoundAlready())
            {

                if (_Verified())
                {
                    User.PersonID = displayFilter1.Person.PersonID;
                    User.UserName = textUserName.Text;
                    User.Password = textPassword2.Text;
                    User.isActive = checkBox1.Checked;

                    if (User.Save())
                    {
                        MessageBox.Show("Save successfully !!", "successfully"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mode = enModes.eUpdate;
                        this.UserID = User.UserID;

                        _LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Save failed !!", "Failed"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in the required fields", "Failed"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The user is already there !!", "Verified"
                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage2;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            People.AddEditPerson AddEditForm = new AddEditPerson(User.PersonID);
            AddEditForm.ShowDialog();
            _LoadData();
        }
    }
}

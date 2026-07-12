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
using BusinessDVLDLayerPeople;
using DVLD.People;

namespace DVLD.Users
{
    public partial class ChangePassword : Form
    {
        private clsUser _User { get; set; }
        private int _UserID;

        public ChangePassword(int UserID)
        {
            InitializeComponent();

            this._UserID = UserID;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void _LoadInfo(clsPeople _Person)
        {
            showDetails1.labID.Text = _Person.PersonID.ToString();
            showDetails1.labName.Text = _Person.FirstName + " " + _Person.SeccondName + " " +
                _Person.TherdName + " " + _Person.LastName;
            showDetails1.labNational.Text = _Person.NationalNo;

            if (_Person.Gendor == 0)
            {
                showDetails1.labGendor.Text = "Male";
            }
            else
                showDetails1.labGendor.Text = "Female";

            showDetails1.labEmail.Text = _Person.Email.ToString();
            showDetails1.labAddress.Text = _Person.Address.ToString();
            showDetails1.labDateOfBirth.Text = _Person.DateOfBirth.ToString();
            showDetails1.labPhone.Text = _Person.Phone.ToString();
            showDetails1.labCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                using (FileStream fs = new FileStream(_Person.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    showDetails1.picturePerson.Image = new Bitmap(Image.FromStream(fs));
                }
            }
            else
            {
                showDetails1.picturePerson.Image = Properties.Resources.Male_512;
            }
        }

        private bool _isLoadPersonInfo(int PersoniD)
        {
            bool _Load = true;

            if (clsUser.isUserExist(_UserID) && clsPeople.isPersonExist(PersoniD))
            {
                
                clsPeople Person = clsPeople.FindPersonByID(PersoniD);

                if (Person == null && _User == null)
                {
                    _Load = false;
                }

                else
                {
                    _LoadInfo(Person);
                    _Load = true;
                }

            }
            else
                _Load = false;

            return _Load;
        }
        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void ShowDetails1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void _LoadUser()
        {
            _User = clsUser.FindUser(this._UserID);
            if (_User == null) return;

            if(!_isLoadPersonInfo(this._User.PersonID))
            {
                MessageBox.Show("The User id Not Found !!", "Verified"
               , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            labUserID.Text = _User.UserID.ToString();
            labUserName.Text = _User.UserName;
            labisActive.Text = (_User.isActive) ? "Active" : "Inactive";



        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            _LoadUser();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            People.AddEditPerson AddEditForm = new AddEditPerson(_User.PersonID);
            AddEditForm.ShowDialog();
            _isLoadPersonInfo(_User.PersonID);
        }

        private bool _Verified()
        {
            bool isValid = true;

            string ErroeMess = "Please fill in the required fields";

            if (string.IsNullOrWhiteSpace(textConfirm.Text))
            {
                errorProvider1.SetError(textConfirm, ErroeMess);
                isValid = false;
            }
            else { errorProvider1.SetError(textConfirm, ""); }


            if (string.IsNullOrWhiteSpace(textNewPassword.Text))
            {
                errorProvider1.SetError(textNewPassword, ErroeMess);
                isValid = false;
            }
            else { errorProvider1.SetError(textNewPassword, ""); }


            if (string.IsNullOrWhiteSpace(textCurrontPassword.Text))
            {
                errorProvider1.SetError(textCurrontPassword, ErroeMess);
                isValid = false;
            }
            else { errorProvider1.SetError(textCurrontPassword, ""); }

            if (textNewPassword.Text != textConfirm.Text)
            {
                errorProvider1.SetError(textConfirm, "Password does not match");
                isValid = false;
            }
            else { errorProvider1.SetError(textConfirm, ""); }

            if(textCurrontPassword.Text != _User.Password)
            {
                errorProvider1.SetError(textCurrontPassword, "The password is incorrect");
                isValid = false;
            }
            else { errorProvider1.SetError(textCurrontPassword, ""); }
        

            return isValid;

        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (this._User == null)
            {
                MessageBox.Show("User is Not Found !!", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (_Verified())
            {
                _User.Password = textConfirm.Text;
               
                if (_User.Save())
                {
                    MessageBox.Show("Save successfully !!", "successfully"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
               , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            

            }
            
        }
    }
}

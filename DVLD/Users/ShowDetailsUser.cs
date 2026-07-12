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
    public partial class ShowDetailsUser : Form
    {
        private int _UserID = -1;
        private clsUser _User;
        public ShowDetailsUser(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void _LoadInfoPerson(int PersonID)
        {
            if (PersonID == -1) return;

            clsPeople _Person = clsPeople.FindPersonByID(PersonID);

            if (_Person == null) return;

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

        private void _LoadInfo()
        {
            if (this._UserID == -1) return;

            _User = clsUser.FindUser(this._UserID);

            if (_User == null) return;

            labUserID.Text = _User.UserID.ToString();
            labUserName.Text = _User.UserName;
            labisActive.Text = (_User.isActive == true) ? "Active" : "Inactive";

            _LoadInfoPerson(_User.PersonID);

        }


        private void ShowDetailsUser_Load(object sender, EventArgs e)
        {
            _LoadInfo();
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

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser(_User.UserID);
            addEditUser.ShowDialog();
            _LoadInfo();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDVLDLayerPeople;
using BusinessDVLDLayer;
using System.IO;

namespace DVLD.People
{
    public partial class clsShowDetailsPerson : Form
    {
        private int _PersonID;
        private string _NationalNo;
        private clsPeople _Person;
        public clsShowDetailsPerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }
        public clsShowDetailsPerson(string NationalNo)
        {
            InitializeComponent();
            this._NationalNo = NationalNo;

        }

        private void _LoadData()
        {

            if (_PersonID != 0 && _PersonID != -1)
            {
                _Person = clsPeople.FindPersonByID(_PersonID);
            }
            else if (!string.IsNullOrEmpty(_NationalNo))
            {
                _Person = clsPeople.FindPersonByNationalNo(_NationalNo);
            }


            if (_Person != null)
            {


                showDetails1.labID.Text = _Person.PersonID.ToString();
                showDetails1.labName.Text = _Person.FirstName.ToString() + " " + _Person.SeccondName.ToString()
                    + " " + _Person.TherdName.ToString() + " " + _Person.LastName.ToString();
                showDetails1.labNational.Text = _Person.NationalNo.ToString();

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

        }
        private void ShowDetailsPerson_Load(object sender, EventArgs e)
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

        }

        private void LabelMode_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            People.AddEditPerson AddEditForm = new AddEditPerson(_PersonID);
            AddEditForm.ShowDialog();
            _LoadData();
            
        }
    }
}

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
using DVLD.People;

namespace DVLD
{
    public partial class DisplayFilter : UserControl
    {
        public clsPeople Person { get; set; }
        public DisplayFilter()
        {
            InitializeComponent();
        }

        private void DisplayFilter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void _Defaultvalues()
        {
            showDetails1.labID.Text = "N/A";
            showDetails1.labName.Text = "N/A";
            showDetails1.labNational.Text = "N/A";
            showDetails1.labGendor.Text = "N/A";
            showDetails1.labEmail.Text = "N/A";
            showDetails1.labAddress.Text = "N/A";
            showDetails1.labDateOfBirth.Text = "N/A";
            showDetails1.labPhone.Text = "N/A";
            showDetails1.labCountry.Text = "N/A";
            showDetails1.picturePerson.Image = Properties.Resources.Male_512;

        }

        public void _DownData(clsPeople _Person)
        {
            showDetails1.labID.Text = _Person.PersonID.ToString();
            showDetails1.labName.Text = _Person.FirstName + " " + _Person.SeccondName
                + " " + _Person.TherdName + " " + _Person.LastName;
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


        private void _Search(string txt)
        {
            if (comboBox1 == null)
                return;

            if (comboBox1.SelectedIndex == 0)
            {
                int.TryParse(txt, out int PersonID);
                Person = clsPeople.FindPersonByID(PersonID);

                if (Person == null)
                {
                    MessageBox.Show("The Person is Not Found!!", "Verified",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Defaultvalues();
                    return;
                }

                _DownData(Person);
            }


            else
            {

                Person = clsPeople.FindPersonByNationalNo(txt);

                if (Person == null)
                {
                    MessageBox.Show("The Person is Not Found!!", "Verified",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Defaultvalues();
                    return;
                }

                _DownData(Person);

            }




        }




        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            _Search(textBox1.Text);
        }

        private void Guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            People.AddEditPerson AddPerson = new People.AddEditPerson(-1);
            AddPerson.ShowDialog();

            Person = clsPeople.FindPersonByID(AddPerson._PersonID);

            if (Person == null)
            {
                return;
            } 
            _DownData(Person);

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (showDetails1.labID.Text == "N/A")
            {
                MessageBox.Show("Please choose a user first!!", "Verified",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            People.AddEditPerson AddEditForm = new AddEditPerson(Person.PersonID);
            AddEditForm.ShowDialog();

            this.Person = clsPeople.FindPersonByID(this.Person.PersonID);
            _DownData(this.Person);
        }

        private void ShowDetails1_Load(object sender, EventArgs e)
        {

        }
    }
    
}

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
using DVLD.GlobalClass;

namespace DVLD.Users
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsSettingLogin.GetStoredCredential(ref UserName, ref Password))
            {
                textUserName.Text = UserName;
                textPassword.Text = Password;
                checkBox1.Checked = true;
            }
            else
                checkBox1.Checked = false;

        }

        private bool _VerifiedFillInfo()
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

            return isValid;
        }


        private void BtLogin_Click(object sender, EventArgs e)
        {
            if (_VerifiedFillInfo())
            {
                clsUser user = clsUser.GetUserInfoByUserNameAndPassword(textUserName.Text, textPassword.Text);

                if (user != null)
                {

                    if (checkBox1.Checked)
                    {
                        //store username and password
                        clsSettingLogin.RememberUsernameAndPassword(textUserName.Text, textPassword.Text);

                    }
                    else
                    {
                        //store empty username and password
                        clsSettingLogin.RememberUsernameAndPassword("", "");

                    }

                    //incase the user is not active
                    if (!user.isActive)
                    {

                        textUserName.Focus();
                        MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsSettingLogin.CurretUser = user;
                    this.Hide();
                    MainDVLD frm = new MainDVLD(this);
                    frm.ShowDialog();


                }
                else
                {
                    textUserName.Focus();
                    MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      

        private void CheckBoxShowPassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textPassword.UseSystemPasswordChar = false;
            }
            else
                textPassword.UseSystemPasswordChar = true;

        }
    }
}

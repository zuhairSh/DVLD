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

        private bool _CheckLogin()
        {
            return clsUser.isAllowedLogin(textUserName.Text, textPassword.Text);
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

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

        private void _SendInfoForSettingLogin()
        {
            clsSettingLogin.UserName = textUserName.Text;
            clsSettingLogin.Password = textPassword.Text;
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            if (_VerifiedFillInfo())
            {
                if (_CheckLogin())
                {
                    _SendInfoForSettingLogin();

                    this.Hide();
                    MainDVLD mainDVLD = new MainDVLD();
                    mainDVLD.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("The username or password is incorrect or you do not have validity!!", "Login",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

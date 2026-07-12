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

        public MainDVLD()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PebuleMenuItem_Click(object sender, EventArgs e)
        {
            People.MainPeople mainPeople = new People.MainPeople();
            mainPeople.ShowDialog();

        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainDVLD_Load(object sender, EventArgs e)
        {

        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.MainUsers mainUsers = new Users.MainUsers();
            mainUsers.ShowDialog();
        }

        private bool _GetUserID()
        {
            return clsSettingLogin.GetUserID();
        }

        private void CurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_GetUserID())
            {
                ShowDetailsUser detailsUser = new ShowDetailsUser(clsSettingLogin.UserID);
                detailsUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("The User is Not Found !!", "Verified"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_GetUserID())
            {
                ChangePassword changePassword = new ChangePassword(clsSettingLogin.UserID);
                changePassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("The User is Not Found !!", "Verified"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

        }

        private void SingOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.LoginScreen loginScreen = new Users.LoginScreen();
            loginScreen.textUserName.Text = clsSettingLogin.UserName;
            loginScreen.textPassword.Text = clsSettingLogin.Password;
            loginScreen.checkBox1.Checked = clsSettingLogin.isRemandUser;
            this.Hide();
            loginScreen.ShowDialog();
            this.Close();

        }
    }
}

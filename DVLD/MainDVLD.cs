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
        LoginScreen _frmLogin;
        public MainDVLD(LoginScreen frm )
        {
            InitializeComponent();
            _frmLogin = frm;
        }  
   

        private void PebuleMenuItem_Click(object sender, EventArgs e)
        {
            People.MainPeople mainPeople = new People.MainPeople();
            mainPeople.ShowDialog();

        }

        

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.MainUsers mainUsers = new Users.MainUsers();
            mainUsers.ShowDialog();
        }

        
        private void CurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ShowDetailsUser detailsUser = new ShowDetailsUser(clsSettingLogin.CurretUser.UserID);
           detailsUser.ShowDialog();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(clsSettingLogin.CurretUser.UserID);
            changePassword.ShowDialog();
        }



        private void SingOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsSettingLogin.CurretUser = null;
            _frmLogin.Show();
            this.Close();

        }
    }
}

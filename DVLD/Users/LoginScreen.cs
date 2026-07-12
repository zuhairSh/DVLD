using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainDVLD mainDVLD = new MainDVLD();
            mainDVLD.ShowDialog();
            this.Close();
        }
    }
}

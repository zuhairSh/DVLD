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


namespace DVLD.Users
{
    public partial class MainUsers : Form
    {
        public MainUsers()
        {
            InitializeComponent();
        }

    

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void _LoadData()
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            dgvUsers.DataSource = clsUser.GetAllUsers();
        }

        private void MainUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            else if(comboBox1.SelectedIndex == 5)
            {
                textBox1.Visible = false;
                comboBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = true;
                comboBox2.Visible = false;
            }
        }

        private void BtAddUser_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser(-1);
            addEditUser.ShowDialog();
            _LoadData();
        }

        private void DeletUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure the User was deleted?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clsUser.DeleteUserByID((int)dgvUsers.CurrentRow.Cells[0].Value);

                MessageBox.Show("Deleted successfully", "Deleted "
               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadData();
            }
        }

        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Maintenance in progress", "Maintenance "
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PhoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Maintenance in progress", "Maintenance "
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _FilterData(string txt)
        {
            if (dgvUsers.DataSource == null) return;
            DataTable dataTable = (DataTable)dgvUsers.DataSource;


            if (comboBox1.SelectedItem == null) return;

            string columnName = comboBox1.SelectedItem.ToString();
            string fillterColumn = "[" + columnName + "]";

            if (string.IsNullOrWhiteSpace(txt))
            {
                dataTable.DefaultView.RowFilter = "";
                return;
            }

            
            else if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 3) // باقي الأعمدة الرقمية
            {
                if (int.TryParse(txt, out int result))
                {
                    dataTable.DefaultView.RowFilter = string.Format("{0} = {1}", fillterColumn, result);
                }
                else
                {
                    dataTable.DefaultView.RowFilter = "1=0"; // لا شيء يطابق
                }
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", fillterColumn, txt);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            _FilterData(textBox1.Text);
        }

        private void _FilterActive(int Selected)
        {
            if (dgvUsers.DataSource == null) return;

            DataTable dataTable = (DataTable)dgvUsers.DataSource;


            if (Selected == 0)
            {
                dataTable.DefaultView.RowFilter = "";
                return;
            }

            if (Selected == 1) //is Active
            {
                dataTable.DefaultView.RowFilter = string.Format("isActive = 1");
            }
            else //is not Active
            {
                dataTable.DefaultView.RowFilter = string.Format("isActive = 0");

            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterActive(comboBox2.SelectedIndex);
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            addEditUser.ShowDialog();
            _LoadData();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser(-1);
            addEditUser.ShowDialog();
            _LoadData();
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ShowInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetailsUser detailsUser = new ShowDetailsUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            detailsUser.ShowDialog();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
            _LoadData();
        }
    }
}

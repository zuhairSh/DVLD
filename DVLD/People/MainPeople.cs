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

namespace DVLD.People
{
    public partial class MainPeople : Form
    {
        public MainPeople()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void _RefreshData()
        {
            comboBox1.SelectedIndex = 0;
            dgvPeople.DataSource = clsPeople.GetAllPeople();

        }

        private void MainPeople_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void BtAddPerson_Click(object sender, EventArgs e)
        {
            People.AddEditPerson AddEditForm = new AddEditPerson(-1);
            AddEditForm.ShowDialog();
            _RefreshData();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _FilterDataGV(string txt)
        {
            if (dgvPeople.DataSource == null) return;
            DataTable dataTable = (DataTable)dgvPeople.DataSource;

            if (comboBox1.SelectedItem == null) return;

            string columnName = comboBox1.SelectedItem.ToString();
            string fillterColumn = "[" + columnName + "]";

            if (string.IsNullOrWhiteSpace(txt))
            {
                dataTable.DefaultView.RowFilter = "";
                return;
            }

            if (columnName == "GendorCaption") 
            {
                dataTable.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", fillterColumn, txt);
            }
            else if (comboBox1.SelectedIndex == 1) // باقي الأعمدة الرقمية
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
            _FilterDataGV(textBox1.Text);
        }

        private void AddPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People.AddEditPerson AddEditForm = new AddEditPerson(-1);
            AddEditForm.ShowDialog();
            _RefreshData();
        }

        private void EditPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People.AddEditPerson AddEditForm = new AddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            AddEditForm.ShowDialog();
            _RefreshData();
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

        private void DeletPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure the person was deleted?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clsPeople.DeletePersonByID((int)dgvPeople.CurrentRow.Cells[0].Value);

                MessageBox.Show("Deleted successfully", "Deleted "
               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshData();
            }
            
        }

        private void ShowInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsShowDetailsPerson detailsPerson = new clsShowDetailsPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            detailsPerson.ShowDialog();
            _RefreshData();
        }
    }
}

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
using BusinessDVLDLayerPeople;

namespace DVLD.Drivers
{
    public partial class MainDrivers : Form
    {
        public MainDrivers()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Visible = false;
            textBox1.Text = null;
            dgvDrivers.DataSource = clsDriver.GetAllDrivers();
        }

        private void MainDrivers_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

   
        private void _FilterData(string txt)
        {
            if (dgvDrivers.DataSource == null) return;

            DataTable dataTable = (DataTable)dgvDrivers.DataSource;


            if (comboBox1.SelectedItem == null) return;

            string columnName = comboBox1.SelectedItem.ToString();
            string fillterColumn = "[" + columnName + "]";

            if (string.IsNullOrWhiteSpace(txt))
            {
                dataTable.DefaultView.RowFilter = "";
                return;
            }


            else if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2) // باقي الأعمدة الرقمية
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

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                textBox1.Visible = true;
            }
        }

        private void ShowInfoPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDrivers.CurrentRow.Cells[0].Value;
            clsDriver driver = clsDriver.FindByDriverID(DriverID);

            People.clsShowDetailsPerson showDetailsPerson = new People.clsShowDetailsPerson(driver.PersonID);
            showDetailsPerson.ShowDialog();

            _LoadInfo();
        
        }

        private void ShowLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;

            License.ShowLicenseHistory showLicenseHistory = new License.ShowLicenseHistory(PersonID);
            showLicenseHistory.ShowDialog();

            _LoadInfo();
        }
    }
}

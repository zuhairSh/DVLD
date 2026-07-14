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

namespace DVLD.TestTypes
{
    public partial class MainTestTypes : Form
    {
        public MainTestTypes()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            labTotalTestTypes.Text = dgvTestTypes.RowCount.ToString();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MainTestTypes_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypes.UpdateTestType updateTestType =
                new UpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            updateTestType.ShowDialog();

            _LoadInfo();
        }
    }
}

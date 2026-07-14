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

namespace DVLD.ApplicationType
{
    public partial class MainApplicationTypes : Form
    {
        public MainApplicationTypes()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            dgvApplicationTypes.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            labTotalApplicationTypes.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void MainApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationType.UpdateApplicationType updateApplicationType =
                new UpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);

            updateApplicationType.ShowDialog();

            _LoadInfo();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}

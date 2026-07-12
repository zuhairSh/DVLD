
namespace DVLD.People
{
    partial class AddEditPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelPersonID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.addEdit1 = new DVLD.AddEdit();
            this.SuspendLayout();
            // 
            // labelMode
            // 
            this.labelMode.BackColor = System.Drawing.Color.Transparent;
            this.labelMode.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.Location = new System.Drawing.Point(346, 12);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(180, 30);
            this.labelMode.TabIndex = 1;
            this.labelMode.Text = "Add New Person";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 54);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(75, 21);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Person ID :";
            // 
            // labelPersonID
            // 
            this.labelPersonID.BackColor = System.Drawing.Color.Transparent;
            this.labelPersonID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPersonID.Location = new System.Drawing.Point(106, 54);
            this.labelPersonID.Name = "labelPersonID";
            this.labelPersonID.Size = new System.Drawing.Size(30, 21);
            this.labelPersonID.TabIndex = 3;
            this.labelPersonID.Text = "N/A";
            // 
            // addEdit1
            // 
            this.addEdit1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.addEdit1.Location = new System.Drawing.Point(-5, 81);
            this.addEdit1.Name = "addEdit1";
            this.addEdit1.Size = new System.Drawing.Size(883, 350);
            this.addEdit1.TabIndex = 0;
            // 
            // AddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 433);
            this.Controls.Add(this.labelPersonID);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.addEdit1);
            this.Name = "AddEditPerson";
            this.Text = "AddEditPerson";
            this.Load += new System.EventHandler(this.AddEditPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AddEdit addEdit1;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelMode;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelPersonID;
    }
}

namespace DVLD.People
{
    partial class clsShowDetailsPerson
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
            this.btClose = new Guna.UI2.WinForms.Guna2Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.showDetails1 = new DVLD.ShowDetails();
            this.SuspendLayout();
            // 
            // labelMode
            // 
            this.labelMode.BackColor = System.Drawing.Color.Transparent;
            this.labelMode.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.Location = new System.Drawing.Point(289, 12);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(154, 30);
            this.labelMode.TabIndex = 2;
            this.labelMode.Text = "Details Person";
            this.labelMode.Click += new System.EventHandler(this.LabelMode_Click);
            // 
            // btClose
            // 
            this.btClose.Animated = true;
            this.btClose.AutoRoundedCorners = true;
            this.btClose.BackColor = System.Drawing.Color.Transparent;
            this.btClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btClose.FillColor = System.Drawing.Color.Gray;
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.Transparent;
            this.btClose.IndicateFocus = true;
            this.btClose.Location = new System.Drawing.Point(12, 374);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(103, 28);
            this.btClose.TabIndex = 40;
            this.btClose.Text = "Close";
            this.btClose.UseTransparentBackground = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(639, 38);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 19);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Info Person";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // showDetails1
            // 
            this.showDetails1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.showDetails1.Location = new System.Drawing.Point(-4, 60);
            this.showDetails1.Name = "showDetails1";
            this.showDetails1.Size = new System.Drawing.Size(793, 308);
            this.showDetails1.TabIndex = 42;
            this.showDetails1.Load += new System.EventHandler(this.ShowDetails1_Load);
            // 
            // clsShowDetailsPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 415);
            this.Controls.Add(this.showDetails1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.labelMode);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "clsShowDetailsPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ShowDetailsPerson";
            this.Load += new System.EventHandler(this.ShowDetailsPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel labelMode;
        public Guna.UI2.WinForms.Guna2Button btClose;
        public System.Windows.Forms.LinkLabel linkLabel1;
        private ShowDetails showDetails1;
    }
}
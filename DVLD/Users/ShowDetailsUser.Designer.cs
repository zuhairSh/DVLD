
namespace DVLD.Users
{
    partial class ShowDetailsUser
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
            this.labMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btClose = new Guna.UI2.WinForms.Guna2Button();
            this.labUserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labisActive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.showDetails1 = new DVLD.ShowDetails();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labMode
            // 
            this.labMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labMode.AutoSize = true;
            this.labMode.Font = new System.Drawing.Font("Myanmar Text", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labMode.ForeColor = System.Drawing.Color.DarkBlue;
            this.labMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labMode.Location = new System.Drawing.Point(263, -3);
            this.labMode.Name = "labMode";
            this.labMode.Size = new System.Drawing.Size(174, 48);
            this.labMode.TabIndex = 45;
            this.labMode.Text = "Details User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Person Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btClose);
            this.groupBox1.Controls.Add(this.labUserName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labisActive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labUserID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 118);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
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
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btClose.ForeColor = System.Drawing.Color.Transparent;
            this.btClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btClose.IndicateFocus = true;
            this.btClose.Location = new System.Drawing.Point(664, 89);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(108, 29);
            this.btClose.TabIndex = 55;
            this.btClose.Text = "Close";
            this.btClose.UseTransparentBackground = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserName.Location = new System.Drawing.Point(297, 47);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(36, 20);
            this.labUserName.TabIndex = 5;
            this.labUserName.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(202, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "UserName:";
            // 
            // labisActive
            // 
            this.labisActive.AutoSize = true;
            this.labisActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labisActive.Location = new System.Drawing.Point(559, 47);
            this.labisActive.Name = "labisActive";
            this.labisActive.Size = new System.Drawing.Size(36, 20);
            this.labisActive.TabIndex = 3;
            this.labisActive.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(472, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Is Active  :";
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserID.Location = new System.Drawing.Point(98, 47);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(36, 20);
            this.labUserID.TabIndex = 1;
            this.labUserID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(645, 52);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 19);
            this.linkLabel1.TabIndex = 48;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Info User";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // showDetails1
            // 
            this.showDetails1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.showDetails1.Location = new System.Drawing.Point(-3, 38);
            this.showDetails1.Name = "showDetails1";
            this.showDetails1.Size = new System.Drawing.Size(777, 331);
            this.showDetails1.TabIndex = 0;
            this.showDetails1.Load += new System.EventHandler(this.ShowDetails1_Load);
            // 
            // ShowDetailsUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 500);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labMode);
            this.Controls.Add(this.showDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowDetailsUser";
            this.Text = "ShowDetailsUser";
            this.Load += new System.EventHandler(this.ShowDetailsUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ShowDetails showDetails1;
        private System.Windows.Forms.Label labMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labisActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2Button btClose;
        public System.Windows.Forms.LinkLabel linkLabel1;
    }
}
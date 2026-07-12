
namespace DVLD.Users
{
    partial class ChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textConfirm = new System.Windows.Forms.TextBox();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.textCurrontPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labisActive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btClose = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.showDetails1 = new DVLD.ShowDetails();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel1.Location = new System.Drawing.Point(557, 12);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 19);
            this.linkLabel1.TabIndex = 58;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Info Person";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Person Information";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.btClose);
            this.groupBox1.Controls.Add(this.textConfirm);
            this.groupBox1.Controls.Add(this.textNewPassword);
            this.groupBox1.Controls.Add(this.textCurrontPassword);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labUserName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labisActive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labUserID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 232);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // textConfirm
            // 
            this.textConfirm.Location = new System.Drawing.Point(512, 138);
            this.textConfirm.Name = "textConfirm";
            this.textConfirm.Size = new System.Drawing.Size(149, 22);
            this.textConfirm.TabIndex = 11;
            // 
            // textNewPassword
            // 
            this.textNewPassword.Location = new System.Drawing.Point(171, 140);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.Size = new System.Drawing.Size(149, 22);
            this.textNewPassword.TabIndex = 10;
            // 
            // textCurrontPassword
            // 
            this.textCurrontPassword.Location = new System.Drawing.Point(171, 98);
            this.textCurrontPassword.Name = "textCurrontPassword";
            this.textCurrontPassword.Size = new System.Drawing.Size(149, 22);
            this.textCurrontPassword.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Curront Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "New Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(361, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm Password :";
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
            this.btClose.Location = new System.Drawing.Point(8, 197);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(108, 29);
            this.btClose.TabIndex = 55;
            this.btClose.Text = "Close";
            this.btClose.UseTransparentBackground = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(241, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 37);
            this.label8.TabIndex = 61;
            this.label8.Text = "Change Password";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btSave
            // 
            this.btSave.Animated = true;
            this.btSave.AutoRoundedCorners = true;
            this.btSave.BackColor = System.Drawing.Color.Transparent;
            this.btSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSave.FillColor = System.Drawing.Color.Gray;
            this.btSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btSave.ForeColor = System.Drawing.Color.Transparent;
            this.btSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSave.IndicateFocus = true;
            this.btSave.Location = new System.Drawing.Point(597, 197);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(108, 29);
            this.btSave.TabIndex = 62;
            this.btSave.Text = "Save";
            this.btSave.UseTransparentBackground = true;
            this.btSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // showDetails1
            // 
            this.showDetails1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.showDetails1.Location = new System.Drawing.Point(12, 12);
            this.showDetails1.Name = "showDetails1";
            this.showDetails1.Size = new System.Drawing.Size(709, 305);
            this.showDetails1.TabIndex = 57;
            this.showDetails1.Load += new System.EventHandler(this.ShowDetails1_Load);
            // 
            // ChangePassword
            // 
            this.AcceptButton = this.btSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 564);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.showDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.LinkLabel linkLabel1;
        internal ShowDetails showDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labisActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2Button btClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textConfirm;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.TextBox textCurrontPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public Guna.UI2.WinForms.Guna2Button btSave;
    }
}
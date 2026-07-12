
namespace DVLD.Users
{
    partial class AddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditUser));
            this.labMode = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btNext = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btPrev = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textPassword2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.btClose = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.displayFilter1 = new DVLD.DisplayFilter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labMode
            // 
            resources.ApplyResources(this.labMode, "labMode");
            this.labMode.ForeColor = System.Drawing.Color.DarkBlue;
            this.labMode.Name = "labMode";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btNext);
            this.tabPage1.Controls.Add(this.displayFilter1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            resources.ApplyResources(this.btNext, "btNext");
            this.btNext.Animated = true;
            this.btNext.BackColor = System.Drawing.Color.Transparent;
            this.btNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btNext.FillColor = System.Drawing.SystemColors.ControlText;
            this.btNext.ForeColor = System.Drawing.SystemColors.Control;
            this.btNext.Image = ((System.Drawing.Image)(resources.GetObject("btNext.Image")));
            this.btNext.IndicateFocus = true;
            this.btNext.Name = "btNext";
            this.btNext.UseTransparentBackground = true;
            this.btNext.Click += new System.EventHandler(this.BtNext_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Silver;
            this.tabPage2.Controls.Add(this.labUserID);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.btPrev);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.textUserName);
            this.tabPage2.Controls.Add(this.textPassword);
            this.tabPage2.Controls.Add(this.textPassword2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Click += new System.EventHandler(this.TabPage2_Click);
            // 
            // labUserID
            // 
            resources.ApplyResources(this.labUserID, "labUserID");
            this.labUserID.Name = "labUserID";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // btPrev
            // 
            this.btPrev.Animated = true;
            this.btPrev.BackColor = System.Drawing.Color.Transparent;
            this.btPrev.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btPrev.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btPrev.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btPrev.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btPrev.FillColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btPrev, "btPrev");
            this.btPrev.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btPrev.Image = ((System.Drawing.Image)(resources.GetObject("btPrev.Image")));
            this.btPrev.IndicateFocus = true;
            this.btPrev.Name = "btPrev";
            this.btPrev.PressedColor = System.Drawing.Color.AntiqueWhite;
            this.btPrev.UseTransparentBackground = true;
            this.btPrev.Click += new System.EventHandler(this.Guna2Button1_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // textUserName
            // 
            resources.ApplyResources(this.textUserName, "textUserName");
            this.textUserName.Name = "textUserName";
            // 
            // textPassword
            // 
            resources.ApplyResources(this.textPassword, "textPassword");
            this.textPassword.Name = "textPassword";
            // 
            // textPassword2
            // 
            resources.ApplyResources(this.textPassword2, "textPassword2");
            this.textPassword2.Name = "textPassword2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            resources.ApplyResources(this.btSave, "btSave");
            this.btSave.ForeColor = System.Drawing.Color.Transparent;
            this.btSave.IndicateFocus = true;
            this.btSave.Name = "btSave";
            this.btSave.UseTransparentBackground = true;
            this.btSave.Click += new System.EventHandler(this.BtSave_Click);
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
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.ForeColor = System.Drawing.Color.Transparent;
            this.btClose.IndicateFocus = true;
            this.btClose.Name = "btClose";
            this.btClose.UseTransparentBackground = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // displayFilter1
            // 
            resources.ApplyResources(this.displayFilter1, "displayFilter1");
            this.displayFilter1.Name = "displayFilter1";
            this.displayFilter1.Person = null;
            this.displayFilter1.Load += new System.EventHandler(this.DisplayFilter1_Load);
            // 
            // AddEditUser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.labMode);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddEditUser";
            this.Load += new System.EventHandler(this.AddEditUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labMode;
        private DisplayFilter displayFilter1;
        private Guna.UI2.WinForms.Guna2Button btNext;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2Button btPrev;
        public Guna.UI2.WinForms.Guna2Button btSave;
        public Guna.UI2.WinForms.Guna2Button btClose;
        public System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox textUserName;
        public System.Windows.Forms.TextBox textPassword;
        public System.Windows.Forms.TextBox textPassword2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labUserID;
    }
}
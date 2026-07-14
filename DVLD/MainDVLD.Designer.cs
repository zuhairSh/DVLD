
namespace DVLD
{
    partial class MainDVLD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDVLD));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pebuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.singOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.pebuleMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationTypesToolStripMenuItem,
            this.testTypesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("applicationsToolStripMenuItem.Image")));
            this.applicationsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.applicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(140, 36);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // applicationTypesToolStripMenuItem
            // 
            this.applicationTypesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("applicationTypesToolStripMenuItem.Image")));
            this.applicationTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationTypesToolStripMenuItem.Name = "applicationTypesToolStripMenuItem";
            this.applicationTypesToolStripMenuItem.Size = new System.Drawing.Size(222, 38);
            this.applicationTypesToolStripMenuItem.Text = " Application Types";
            this.applicationTypesToolStripMenuItem.Click += new System.EventHandler(this.ApplicationTypesToolStripMenuItem_Click);
            // 
            // pebuleMenuItem
            // 
            this.pebuleMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pebuleMenuItem.Image")));
            this.pebuleMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pebuleMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pebuleMenuItem.Name = "pebuleMenuItem";
            this.pebuleMenuItem.Size = new System.Drawing.Size(100, 36);
            this.pebuleMenuItem.Text = "People";
            this.pebuleMenuItem.Click += new System.EventHandler(this.PebuleMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(92, 36);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.singOutToolStripMenuItem});
            this.accountSettingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("accountSettingToolStripMenuItem.Image")));
            this.accountSettingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(165, 36);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            // 
            // currentToolStripMenuItem
            // 
            this.currentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentToolStripMenuItem.Image")));
            this.currentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            this.currentToolStripMenuItem.Size = new System.Drawing.Size(217, 38);
            this.currentToolStripMenuItem.Text = "Current User Info";
            this.currentToolStripMenuItem.Click += new System.EventHandler(this.CurrentToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(217, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // singOutToolStripMenuItem
            // 
            this.singOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("singOutToolStripMenuItem.Image")));
            this.singOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.singOutToolStripMenuItem.Name = "singOutToolStripMenuItem";
            this.singOutToolStripMenuItem.Size = new System.Drawing.Size(217, 38);
            this.singOutToolStripMenuItem.Text = "Sing out";
            this.singOutToolStripMenuItem.Click += new System.EventHandler(this.SingOutToolStripMenuItem_Click);
            // 
            // testTypesToolStripMenuItem
            // 
            this.testTypesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testTypesToolStripMenuItem.Image")));
            this.testTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.testTypesToolStripMenuItem.Name = "testTypesToolStripMenuItem";
            this.testTypesToolStripMenuItem.Size = new System.Drawing.Size(222, 38);
            this.testTypesToolStripMenuItem.Text = "Test Types";
            this.testTypesToolStripMenuItem.Click += new System.EventHandler(this.TestTypesToolStripMenuItem_Click);
            // 
            // MainDVLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1132, 585);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "MainDVLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "MainDVLD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainDVLD_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pebuleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem singOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testTypesToolStripMenuItem;
    }
}


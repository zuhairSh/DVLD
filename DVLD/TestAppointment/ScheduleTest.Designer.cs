
namespace DVLD.TestAppointment
{
    partial class ScheduleTest
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
            this.scheduleTest1 = new DVLD.MyContors.ScheduleTest();
            this.SuspendLayout();
            // 
            // scheduleTest1
            // 
            this.scheduleTest1.Location = new System.Drawing.Point(12, -1);
            this.scheduleTest1.Name = "scheduleTest1";
            this.scheduleTest1.Size = new System.Drawing.Size(550, 584);
            this.scheduleTest1.TabIndex = 0;
            this.scheduleTest1.TestTypeID = BusinessDVLDLayer.clsTestType.enTestType.VisionTest;
            this.scheduleTest1.Load += new System.EventHandler(this.ScheduleTest1_Load);
            // 
            // ScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 586);
            this.Controls.Add(this.scheduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleTest";
            this.Load += new System.EventHandler(this.ScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyContors.ScheduleTest scheduleTest1;
    }
}
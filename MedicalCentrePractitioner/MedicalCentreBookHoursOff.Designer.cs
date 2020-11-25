namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentreBookHoursOff
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
            this.labelBooTimeOff = new System.Windows.Forms.Label();
            this.labelBookingDate = new System.Windows.Forms.Label();
            this.monthCalendarBookingDate = new System.Windows.Forms.MonthCalendar();
            this.labelBookingTime = new System.Windows.Forms.Label();
            this.listBoxTime = new System.Windows.Forms.ListBox();
            this.buttonBookTimeOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBooTimeOff
            // 
            this.labelBooTimeOff.AutoSize = true;
            this.labelBooTimeOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBooTimeOff.Location = new System.Drawing.Point(32, 23);
            this.labelBooTimeOff.Name = "labelBooTimeOff";
            this.labelBooTimeOff.Size = new System.Drawing.Size(88, 13);
            this.labelBooTimeOff.TabIndex = 0;
            this.labelBooTimeOff.Text = "Book Time Off";
            // 
            // labelBookingDate
            // 
            this.labelBookingDate.AutoSize = true;
            this.labelBookingDate.Location = new System.Drawing.Point(32, 63);
            this.labelBookingDate.Name = "labelBookingDate";
            this.labelBookingDate.Size = new System.Drawing.Size(164, 13);
            this.labelBookingDate.TabIndex = 1;
            this.labelBookingDate.Text = "Please Select the Booking Date: ";
            // 
            // monthCalendarBookingDate
            // 
            this.monthCalendarBookingDate.Location = new System.Drawing.Point(35, 90);
            this.monthCalendarBookingDate.Name = "monthCalendarBookingDate";
            this.monthCalendarBookingDate.TabIndex = 2;
            // 
            // labelBookingTime
            // 
            this.labelBookingTime.AutoSize = true;
            this.labelBookingTime.Location = new System.Drawing.Point(281, 63);
            this.labelBookingTime.Name = "labelBookingTime";
            this.labelBookingTime.Size = new System.Drawing.Size(164, 13);
            this.labelBookingTime.TabIndex = 3;
            this.labelBookingTime.Text = "Please Select the Booking Time: ";
            // 
            // listBoxTime
            // 
            this.listBoxTime.FormattingEnabled = true;
            this.listBoxTime.Location = new System.Drawing.Point(324, 90);
            this.listBoxTime.Name = "listBoxTime";
            this.listBoxTime.Size = new System.Drawing.Size(88, 160);
            this.listBoxTime.TabIndex = 4;
            // 
            // buttonBookTimeOff
            // 
            this.buttonBookTimeOff.Location = new System.Drawing.Point(35, 287);
            this.buttonBookTimeOff.Name = "buttonBookTimeOff";
            this.buttonBookTimeOff.Size = new System.Drawing.Size(377, 48);
            this.buttonBookTimeOff.TabIndex = 5;
            this.buttonBookTimeOff.Text = "Book Time Off";
            this.buttonBookTimeOff.UseVisualStyleBackColor = true;
            // 
            // MedicalCentreBookHoursOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 369);
            this.Controls.Add(this.buttonBookTimeOff);
            this.Controls.Add(this.listBoxTime);
            this.Controls.Add(this.labelBookingTime);
            this.Controls.Add(this.monthCalendarBookingDate);
            this.Controls.Add(this.labelBookingDate);
            this.Controls.Add(this.labelBooTimeOff);
            this.Name = "MedicalCentreBookHoursOff";
            this.Text = "MedicalCentreBookHoursOff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBooTimeOff;
        private System.Windows.Forms.Label labelBookingDate;
        private System.Windows.Forms.MonthCalendar monthCalendarBookingDate;
        private System.Windows.Forms.Label labelBookingTime;
        private System.Windows.Forms.ListBox listBoxTime;
        private System.Windows.Forms.Button buttonBookTimeOff;
    }
}
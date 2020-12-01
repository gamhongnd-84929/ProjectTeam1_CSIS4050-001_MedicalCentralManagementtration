namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentreBookAppointment
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
            this.labelBookAppointment = new System.Windows.Forms.Label();
            this.listBoxServices = new System.Windows.Forms.ListBox();
            this.labelServices = new System.Windows.Forms.Label();
            this.labelDoctors = new System.Windows.Forms.Label();
            this.monthCalendarBooking = new System.Windows.Forms.MonthCalendar();
            this.labelBookingDate = new System.Windows.Forms.Label();
            this.listBoxTime = new System.Windows.Forms.ListBox();
            this.labelBookingTime = new System.Windows.Forms.Label();
            this.labelTotalPriceText = new System.Windows.Forms.Label();
            this.labelPriceAmount = new System.Windows.Forms.Label();
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.labelBookingSummary = new System.Windows.Forms.Label();
            this.labelSelectType = new System.Windows.Forms.Label();
            this.comboBoxPractitionerTypes = new System.Windows.Forms.ComboBox();
            this.dataGridViewPractitioners = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPractitioners)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBookAppointment
            // 
            this.labelBookAppointment.AutoSize = true;
            this.labelBookAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBookAppointment.Location = new System.Drawing.Point(38, 23);
            this.labelBookAppointment.Name = "labelBookAppointment";
            this.labelBookAppointment.Size = new System.Drawing.Size(146, 18);
            this.labelBookAppointment.TabIndex = 0;
            this.labelBookAppointment.Text = "Book Appointment";
            // 
            // listBoxServices
            // 
            this.listBoxServices.FormattingEnabled = true;
            this.listBoxServices.ItemHeight = 16;
            this.listBoxServices.Location = new System.Drawing.Point(41, 169);
            this.listBoxServices.Name = "listBoxServices";
            this.listBoxServices.Size = new System.Drawing.Size(177, 212);
            this.listBoxServices.TabIndex = 1;
            // 
            // labelServices
            // 
            this.labelServices.AutoSize = true;
            this.labelServices.Location = new System.Drawing.Point(41, 128);
            this.labelServices.Name = "labelServices";
            this.labelServices.Size = new System.Drawing.Size(180, 17);
            this.labelServices.TabIndex = 2;
            this.labelServices.Text = "Please Select the Services:";
            // 
            // labelDoctors
            // 
            this.labelDoctors.AutoSize = true;
            this.labelDoctors.Location = new System.Drawing.Point(285, 119);
            this.labelDoctors.Name = "labelDoctors";
            this.labelDoctors.Size = new System.Drawing.Size(198, 17);
            this.labelDoctors.TabIndex = 4;
            this.labelDoctors.Text = "Please Select the Practitioner:";
            // 
            // monthCalendarBooking
            // 
            this.monthCalendarBooking.Location = new System.Drawing.Point(41, 448);
            this.monthCalendarBooking.Name = "monthCalendarBooking";
            this.monthCalendarBooking.TabIndex = 5;
            // 
            // labelBookingDate
            // 
            this.labelBookingDate.AutoSize = true;
            this.labelBookingDate.Location = new System.Drawing.Point(41, 406);
            this.labelBookingDate.Name = "labelBookingDate";
            this.labelBookingDate.Size = new System.Drawing.Size(211, 17);
            this.labelBookingDate.TabIndex = 6;
            this.labelBookingDate.Text = "Please Select the Booking Date:";
            // 
            // listBoxTime
            // 
            this.listBoxTime.FormattingEnabled = true;
            this.listBoxTime.ItemHeight = 16;
            this.listBoxTime.Location = new System.Drawing.Point(497, 448);
            this.listBoxTime.Name = "listBoxTime";
            this.listBoxTime.Size = new System.Drawing.Size(118, 196);
            this.listBoxTime.TabIndex = 7;
            // 
            // labelBookingTime
            // 
            this.labelBookingTime.AutoSize = true;
            this.labelBookingTime.Location = new System.Drawing.Point(494, 406);
            this.labelBookingTime.Name = "labelBookingTime";
            this.labelBookingTime.Size = new System.Drawing.Size(212, 17);
            this.labelBookingTime.TabIndex = 8;
            this.labelBookingTime.Text = "Please Select the Booking Time:";
            // 
            // labelTotalPriceText
            // 
            this.labelTotalPriceText.AutoSize = true;
            this.labelTotalPriceText.Location = new System.Drawing.Point(38, 719);
            this.labelTotalPriceText.Name = "labelTotalPriceText";
            this.labelTotalPriceText.Size = new System.Drawing.Size(180, 17);
            this.labelTotalPriceText.TabIndex = 9;
            this.labelTotalPriceText.Text = "Total Price for the Booking:";
            // 
            // labelPriceAmount
            // 
            this.labelPriceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPriceAmount.Location = new System.Drawing.Point(242, 712);
            this.labelPriceAmount.Name = "labelPriceAmount";
            this.labelPriceAmount.Size = new System.Drawing.Size(95, 24);
            this.labelPriceAmount.TabIndex = 10;
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(753, 668);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(247, 107);
            this.buttonCreateBooking.TabIndex = 11;
            this.buttonCreateBooking.Text = "Create the Booking";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            // 
            // labelBookingSummary
            // 
            this.labelBookingSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBookingSummary.Location = new System.Drawing.Point(380, 668);
            this.labelBookingSummary.Name = "labelBookingSummary";
            this.labelBookingSummary.Size = new System.Drawing.Size(348, 204);
            this.labelBookingSummary.TabIndex = 12;
            // 
            // labelSelectType
            // 
            this.labelSelectType.AutoSize = true;
            this.labelSelectType.Location = new System.Drawing.Point(41, 69);
            this.labelSelectType.Name = "labelSelectType";
            this.labelSelectType.Size = new System.Drawing.Size(226, 17);
            this.labelSelectType.TabIndex = 13;
            this.labelSelectType.Text = "Please Select Type of Practitioner:";
            // 
            // comboBoxPractitionerTypes
            // 
            this.comboBoxPractitionerTypes.FormattingEnabled = true;
            this.comboBoxPractitionerTypes.Location = new System.Drawing.Point(312, 66);
            this.comboBoxPractitionerTypes.Name = "comboBoxPractitionerTypes";
            this.comboBoxPractitionerTypes.Size = new System.Drawing.Size(291, 24);
            this.comboBoxPractitionerTypes.TabIndex = 14;
            // 
            // dataGridViewPractitioners
            // 
            this.dataGridViewPractitioners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPractitioners.Location = new System.Drawing.Point(288, 169);
            this.dataGridViewPractitioners.Name = "dataGridViewPractitioners";
            this.dataGridViewPractitioners.RowHeadersWidth = 51;
            this.dataGridViewPractitioners.RowTemplate.Height = 24;
            this.dataGridViewPractitioners.Size = new System.Drawing.Size(712, 212);
            this.dataGridViewPractitioners.TabIndex = 15;
            // 
            // MedicalCentreBookAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 891);
            this.Controls.Add(this.dataGridViewPractitioners);
            this.Controls.Add(this.comboBoxPractitionerTypes);
            this.Controls.Add(this.labelSelectType);
            this.Controls.Add(this.labelBookingSummary);
            this.Controls.Add(this.buttonCreateBooking);
            this.Controls.Add(this.labelPriceAmount);
            this.Controls.Add(this.labelTotalPriceText);
            this.Controls.Add(this.labelBookingTime);
            this.Controls.Add(this.listBoxTime);
            this.Controls.Add(this.labelBookingDate);
            this.Controls.Add(this.monthCalendarBooking);
            this.Controls.Add(this.labelDoctors);
            this.Controls.Add(this.labelServices);
            this.Controls.Add(this.listBoxServices);
            this.Controls.Add(this.labelBookAppointment);
            this.Name = "MedicalCentreBookAppointment";
            this.Text = "MedicalCentre: Book Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPractitioners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBookAppointment;
        private System.Windows.Forms.ListBox listBoxServices;
        private System.Windows.Forms.Label labelServices;
        private System.Windows.Forms.Label labelDoctors;
        private System.Windows.Forms.MonthCalendar monthCalendarBooking;
        private System.Windows.Forms.Label labelBookingDate;
        private System.Windows.Forms.ListBox listBoxTime;
        private System.Windows.Forms.Label labelBookingTime;
        private System.Windows.Forms.Label labelTotalPriceText;
        private System.Windows.Forms.Label labelPriceAmount;
        private System.Windows.Forms.Button buttonCreateBooking;
        private System.Windows.Forms.Label labelBookingSummary;
        private System.Windows.Forms.Label labelSelectType;
        private System.Windows.Forms.ComboBox comboBoxPractitionerTypes;
        private System.Windows.Forms.DataGridView dataGridViewPractitioners;
    }
}
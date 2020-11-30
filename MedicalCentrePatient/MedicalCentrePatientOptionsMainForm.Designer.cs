namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentrePatientOptionsMainForm
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
            this.labelPatientName = new System.Windows.Forms.Label();
            this.dataGridViewPatientBookings = new System.Windows.Forms.DataGridView();
            this.dataGridViewPatientPayments = new System.Windows.Forms.DataGridView();
            this.buttonUpdateInformation = new System.Windows.Forms.Button();
            this.labelPatientBookings = new System.Windows.Forms.Label();
            this.labelPatientPayments = new System.Windows.Forms.Label();
            this.buttonBookAppointment = new System.Windows.Forms.Button();
            this.buttonMakePayment = new System.Windows.Forms.Button();
            this.buttonCancelBooking = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatientBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatientPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPatientName
            // 
            this.labelPatientName.AutoSize = true;
            this.labelPatientName.Location = new System.Drawing.Point(788, 9);
            this.labelPatientName.Name = "labelPatientName";
            this.labelPatientName.Size = new System.Drawing.Size(101, 17);
            this.labelPatientName.TabIndex = 0;
            this.labelPatientName.Text = "Patient Name: ";
            // 
            // dataGridViewPatientBookings
            // 
            this.dataGridViewPatientBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatientBookings.Location = new System.Drawing.Point(66, 65);
            this.dataGridViewPatientBookings.Name = "dataGridViewPatientBookings";
            this.dataGridViewPatientBookings.RowHeadersWidth = 51;
            this.dataGridViewPatientBookings.RowTemplate.Height = 24;
            this.dataGridViewPatientBookings.Size = new System.Drawing.Size(716, 199);
            this.dataGridViewPatientBookings.TabIndex = 1;
            // 
            // dataGridViewPatientPayments
            // 
            this.dataGridViewPatientPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatientPayments.Location = new System.Drawing.Point(66, 316);
            this.dataGridViewPatientPayments.Name = "dataGridViewPatientPayments";
            this.dataGridViewPatientPayments.RowHeadersWidth = 51;
            this.dataGridViewPatientPayments.RowTemplate.Height = 24;
            this.dataGridViewPatientPayments.Size = new System.Drawing.Size(716, 196);
            this.dataGridViewPatientPayments.TabIndex = 2;
            // 
            // buttonUpdateInformation
            // 
            this.buttonUpdateInformation.Location = new System.Drawing.Point(823, 65);
            this.buttonUpdateInformation.Name = "buttonUpdateInformation";
            this.buttonUpdateInformation.Size = new System.Drawing.Size(142, 68);
            this.buttonUpdateInformation.TabIndex = 3;
            this.buttonUpdateInformation.Text = "Update Patient\'s Information";
            this.buttonUpdateInformation.UseVisualStyleBackColor = true;
            // 
            // labelPatientBookings
            // 
            this.labelPatientBookings.AutoSize = true;
            this.labelPatientBookings.Location = new System.Drawing.Point(66, 35);
            this.labelPatientBookings.Name = "labelPatientBookings";
            this.labelPatientBookings.Size = new System.Drawing.Size(124, 17);
            this.labelPatientBookings.TabIndex = 4;
            this.labelPatientBookings.Text = "Patient\'s Bookings";
            // 
            // labelPatientPayments
            // 
            this.labelPatientPayments.AutoSize = true;
            this.labelPatientPayments.Location = new System.Drawing.Point(66, 282);
            this.labelPatientPayments.Name = "labelPatientPayments";
            this.labelPatientPayments.Size = new System.Drawing.Size(128, 17);
            this.labelPatientPayments.TabIndex = 5;
            this.labelPatientPayments.Text = "Patient\'s Payments";
            // 
            // buttonBookAppointment
            // 
            this.buttonBookAppointment.Location = new System.Drawing.Point(823, 316);
            this.buttonBookAppointment.Name = "buttonBookAppointment";
            this.buttonBookAppointment.Size = new System.Drawing.Size(142, 68);
            this.buttonBookAppointment.TabIndex = 6;
            this.buttonBookAppointment.Text = "Book Appointment for Patient";
            this.buttonBookAppointment.UseVisualStyleBackColor = true;
            // 
            // buttonMakePayment
            // 
            this.buttonMakePayment.Location = new System.Drawing.Point(823, 444);
            this.buttonMakePayment.Name = "buttonMakePayment";
            this.buttonMakePayment.Size = new System.Drawing.Size(142, 68);
            this.buttonMakePayment.TabIndex = 7;
            this.buttonMakePayment.Text = "Make Payment for Appointment";
            this.buttonMakePayment.UseVisualStyleBackColor = true;
            // 
            // buttonCancelBooking
            // 
            this.buttonCancelBooking.Location = new System.Drawing.Point(823, 196);
            this.buttonCancelBooking.Name = "buttonCancelBooking";
            this.buttonCancelBooking.Size = new System.Drawing.Size(142, 68);
            this.buttonCancelBooking.TabIndex = 8;
            this.buttonCancelBooking.Text = "Cancel Patient\'s Booking";
            this.buttonCancelBooking.UseVisualStyleBackColor = true;
            // 
            // MedicalCentrePatientOptionsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 533);
            this.Controls.Add(this.buttonCancelBooking);
            this.Controls.Add(this.buttonMakePayment);
            this.Controls.Add(this.buttonBookAppointment);
            this.Controls.Add(this.labelPatientPayments);
            this.Controls.Add(this.labelPatientBookings);
            this.Controls.Add(this.buttonUpdateInformation);
            this.Controls.Add(this.dataGridViewPatientPayments);
            this.Controls.Add(this.dataGridViewPatientBookings);
            this.Controls.Add(this.labelPatientName);
            this.Name = "MedicalCentrePatientOptionsMainForm";
            this.Text = "Medical Centre: Patient\'s Options";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatientBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatientPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPatientName;
        private System.Windows.Forms.DataGridView dataGridViewPatientBookings;
        private System.Windows.Forms.DataGridView dataGridViewPatientPayments;
        private System.Windows.Forms.Button buttonUpdateInformation;
        private System.Windows.Forms.Label labelPatientBookings;
        private System.Windows.Forms.Label labelPatientPayments;
        private System.Windows.Forms.Button buttonBookAppointment;
        private System.Windows.Forms.Button buttonMakePayment;
        private System.Windows.Forms.Button buttonCancelBooking;
    }
}
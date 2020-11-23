namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentrePractitionerOptionsMainForm
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
            this.labelPractitionerBookings = new System.Windows.Forms.Label();
            this.dataGridViewPractitionerBookings = new System.Windows.Forms.DataGridView();
            this.labelPractitionerName = new System.Windows.Forms.Label();
            this.buttonUpdatePractitioner = new System.Windows.Forms.Button();
            this.buttonBookHoursOff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPractitionerBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPractitionerBookings
            // 
            this.labelPractitionerBookings.Location = new System.Drawing.Point(38, 30);
            this.labelPractitionerBookings.Name = "labelPractitionerBookings";
            this.labelPractitionerBookings.Size = new System.Drawing.Size(114, 15);
            this.labelPractitionerBookings.TabIndex = 0;
            this.labelPractitionerBookings.Text = "Practitioner\'s Bookings";
            // 
            // dataGridViewPractitionerBookings
            // 
            this.dataGridViewPractitionerBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPractitionerBookings.Location = new System.Drawing.Point(41, 61);
            this.dataGridViewPractitionerBookings.Name = "dataGridViewPractitionerBookings";
            this.dataGridViewPractitionerBookings.Size = new System.Drawing.Size(590, 241);
            this.dataGridViewPractitionerBookings.TabIndex = 1;
            // 
            // labelPractitionerName
            // 
            this.labelPractitionerName.AutoSize = true;
            this.labelPractitionerName.Location = new System.Drawing.Point(636, 9);
            this.labelPractitionerName.Name = "labelPractitionerName";
            this.labelPractitionerName.Size = new System.Drawing.Size(97, 13);
            this.labelPractitionerName.TabIndex = 2;
            this.labelPractitionerName.Text = "Practitioner Name: ";
            // 
            // buttonUpdatePractitioner
            // 
            this.buttonUpdatePractitioner.Location = new System.Drawing.Point(696, 94);
            this.buttonUpdatePractitioner.Name = "buttonUpdatePractitioner";
            this.buttonUpdatePractitioner.Size = new System.Drawing.Size(110, 65);
            this.buttonUpdatePractitioner.TabIndex = 3;
            this.buttonUpdatePractitioner.Text = "Update Practitioner\'s Information";
            this.buttonUpdatePractitioner.UseVisualStyleBackColor = true;
            // 
            // buttonBookHoursOff
            // 
            this.buttonBookHoursOff.Location = new System.Drawing.Point(696, 187);
            this.buttonBookHoursOff.Name = "buttonBookHoursOff";
            this.buttonBookHoursOff.Size = new System.Drawing.Size(110, 69);
            this.buttonBookHoursOff.TabIndex = 4;
            this.buttonBookHoursOff.Text = "Book Hours Off";
            this.buttonBookHoursOff.UseVisualStyleBackColor = true;
            // 
            // MedicalCentrePractitionerOptionsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 348);
            this.Controls.Add(this.buttonBookHoursOff);
            this.Controls.Add(this.buttonUpdatePractitioner);
            this.Controls.Add(this.labelPractitionerName);
            this.Controls.Add(this.dataGridViewPractitionerBookings);
            this.Controls.Add(this.labelPractitionerBookings);
            this.Name = "MedicalCentrePractitionerOptionsMainForm";
            this.Text = "MedicalCentrePractitionerOptionsMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPractitionerBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPractitionerBookings;
        private System.Windows.Forms.DataGridView dataGridViewPractitionerBookings;
        private System.Windows.Forms.Label labelPractitionerName;
        private System.Windows.Forms.Button buttonUpdatePractitioner;
        private System.Windows.Forms.Button buttonBookHoursOff;
    }
}
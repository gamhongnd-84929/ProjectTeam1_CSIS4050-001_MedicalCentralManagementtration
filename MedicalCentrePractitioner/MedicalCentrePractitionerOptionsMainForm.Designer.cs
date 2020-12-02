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
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.buttonUpdateComment = new System.Windows.Forms.Button();
            this.buttonCancelBooking = new System.Windows.Forms.Button();
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
            this.buttonUpdatePractitioner.Location = new System.Drawing.Point(696, 63);
            this.buttonUpdatePractitioner.Name = "buttonUpdatePractitioner";
            this.buttonUpdatePractitioner.Size = new System.Drawing.Size(110, 65);
            this.buttonUpdatePractitioner.TabIndex = 3;
            this.buttonUpdatePractitioner.Text = "Update Practitioner\'s Information";
            this.buttonUpdatePractitioner.UseVisualStyleBackColor = true;
            // 
            // buttonBookHoursOff
            // 
            this.buttonBookHoursOff.Location = new System.Drawing.Point(696, 143);
            this.buttonBookHoursOff.Name = "buttonBookHoursOff";
            this.buttonBookHoursOff.Size = new System.Drawing.Size(110, 69);
            this.buttonBookHoursOff.TabIndex = 4;
            this.buttonBookHoursOff.Text = "Book Hours Off";
            this.buttonBookHoursOff.UseVisualStyleBackColor = true;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(96, 323);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(535, 20);
            this.textBoxComment.TabIndex = 5;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(38, 326);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(57, 13);
            this.labelComment.TabIndex = 6;
            this.labelComment.Text = "Comment: ";
            // 
            // buttonUpdateComment
            // 
            this.buttonUpdateComment.Location = new System.Drawing.Point(650, 315);
            this.buttonUpdateComment.Name = "buttonUpdateComment";
            this.buttonUpdateComment.Size = new System.Drawing.Size(110, 34);
            this.buttonUpdateComment.TabIndex = 7;
            this.buttonUpdateComment.Text = "Update Comment";
            this.buttonUpdateComment.UseVisualStyleBackColor = true;
            // 
            // buttonCancelBooking
            // 
            this.buttonCancelBooking.Location = new System.Drawing.Point(696, 231);
            this.buttonCancelBooking.Name = "buttonCancelBooking";
            this.buttonCancelBooking.Size = new System.Drawing.Size(109, 70);
            this.buttonCancelBooking.TabIndex = 8;
            this.buttonCancelBooking.Text = "Cancel Booking";
            this.buttonCancelBooking.UseVisualStyleBackColor = true;
            // 
            // MedicalCentrePractitionerOptionsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 369);
            this.Controls.Add(this.buttonCancelBooking);
            this.Controls.Add(this.buttonUpdateComment);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.textBoxComment);
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
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Button buttonUpdateComment;
        private System.Windows.Forms.Button buttonCancelBooking;
    }
}
namespace MedicalCentreMainMenuFormApp
{
    partial class MedicalCentreAllRecordsForm
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
            this.dataGridViewPatients = new System.Windows.Forms.DataGridView();
            this.labelPatients = new System.Windows.Forms.Label();
            this.dataGridViewPractitioners = new System.Windows.Forms.DataGridView();
            this.labelPractitioners = new System.Windows.Forms.Label();
            this.buttonAddPatient = new System.Windows.Forms.Button();
            this.buttonPatientOptions = new System.Windows.Forms.Button();
            this.buttonAddPractitioner = new System.Windows.Forms.Button();
            this.buttonPractitionerOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPractitioners)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPatients
            // 
            this.dataGridViewPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatients.Location = new System.Drawing.Point(58, 60);
            this.dataGridViewPatients.Name = "dataGridViewPatients";
            this.dataGridViewPatients.RowHeadersWidth = 51;
            this.dataGridViewPatients.RowTemplate.Height = 24;
            this.dataGridViewPatients.Size = new System.Drawing.Size(914, 202);
            this.dataGridViewPatients.TabIndex = 0;
            // 
            // labelPatients
            // 
            this.labelPatients.AutoSize = true;
            this.labelPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPatients.Location = new System.Drawing.Point(58, 25);
            this.labelPatients.Name = "labelPatients";
            this.labelPatients.Size = new System.Drawing.Size(63, 20);
            this.labelPatients.TabIndex = 1;
            this.labelPatients.Text = "Patients";
            // 
            // dataGridViewPractitioners
            // 
            this.dataGridViewPractitioners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPractitioners.Location = new System.Drawing.Point(58, 345);
            this.dataGridViewPractitioners.Name = "dataGridViewPractitioners";
            this.dataGridViewPractitioners.RowHeadersWidth = 51;
            this.dataGridViewPractitioners.RowTemplate.Height = 24;
            this.dataGridViewPractitioners.Size = new System.Drawing.Size(914, 201);
            this.dataGridViewPractitioners.TabIndex = 2;
            // 
            // labelPractitioners
            // 
            this.labelPractitioners.AutoSize = true;
            this.labelPractitioners.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPractitioners.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPractitioners.Location = new System.Drawing.Point(58, 310);
            this.labelPractitioners.Name = "labelPractitioners";
            this.labelPractitioners.Size = new System.Drawing.Size(93, 20);
            this.labelPractitioners.TabIndex = 3;
            this.labelPractitioners.Text = "Practitioners";
            // 
            // buttonAddPatient
            // 
            this.buttonAddPatient.Location = new System.Drawing.Point(1031, 60);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(147, 68);
            this.buttonAddPatient.TabIndex = 4;
            this.buttonAddPatient.Text = "Register a New Patient";
            this.buttonAddPatient.UseVisualStyleBackColor = true;
            // 
            // buttonPatientOptions
            // 
            this.buttonPatientOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPatientOptions.Location = new System.Drawing.Point(1031, 194);
            this.buttonPatientOptions.Name = "buttonPatientOptions";
            this.buttonPatientOptions.Size = new System.Drawing.Size(147, 68);
            this.buttonPatientOptions.TabIndex = 5;
            this.buttonPatientOptions.Text = "View Patient\'s Options";
            this.buttonPatientOptions.UseVisualStyleBackColor = true;
            // 
            // buttonAddPractitioner
            // 
            this.buttonAddPractitioner.Location = new System.Drawing.Point(1031, 345);
            this.buttonAddPractitioner.Name = "buttonAddPractitioner";
            this.buttonAddPractitioner.Size = new System.Drawing.Size(147, 68);
            this.buttonAddPractitioner.TabIndex = 6;
            this.buttonAddPractitioner.Text = "Register a New Practitioner";
            this.buttonAddPractitioner.UseVisualStyleBackColor = true;
            // 
            // buttonPractitionerOptions
            // 
            this.buttonPractitionerOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPractitionerOptions.Location = new System.Drawing.Point(1031, 478);
            this.buttonPractitionerOptions.Name = "buttonPractitionerOptions";
            this.buttonPractitionerOptions.Size = new System.Drawing.Size(147, 68);
            this.buttonPractitionerOptions.TabIndex = 7;
            this.buttonPractitionerOptions.Text = "View Practitioner\'s Options";
            this.buttonPractitionerOptions.UseVisualStyleBackColor = true;
            // 
            // MedicalCentreAllRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 590);
            this.Controls.Add(this.buttonPractitionerOptions);
            this.Controls.Add(this.buttonAddPractitioner);
            this.Controls.Add(this.buttonPatientOptions);
            this.Controls.Add(this.buttonAddPatient);
            this.Controls.Add(this.labelPractitioners);
            this.Controls.Add(this.dataGridViewPractitioners);
            this.Controls.Add(this.labelPatients);
            this.Controls.Add(this.dataGridViewPatients);
            this.Name = "MedicalCentreAllRecordsForm";
            this.Text = "MedicalCentreRecordsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPractitioners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPatients;
        private System.Windows.Forms.Label labelPatients;
        private System.Windows.Forms.DataGridView dataGridViewPractitioners;
        private System.Windows.Forms.Label labelPractitioners;
        private System.Windows.Forms.Button buttonAddPatient;
        private System.Windows.Forms.Button buttonPatientOptions;
        private System.Windows.Forms.Button buttonAddPractitioner;
        private System.Windows.Forms.Button buttonPractitionerOptions;
    }
}
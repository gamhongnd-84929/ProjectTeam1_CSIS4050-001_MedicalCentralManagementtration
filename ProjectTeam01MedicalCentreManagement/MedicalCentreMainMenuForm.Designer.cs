namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentreMainMenuForm
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonRecords = new System.Windows.Forms.Button();
            this.buttonAdministration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(126, 78);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(417, 52);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to the Medical Centre!\r\nPlease select one of the following options:";
            // 
            // buttonRecords
            // 
            this.buttonRecords.Location = new System.Drawing.Point(235, 190);
            this.buttonRecords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRecords.Name = "buttonRecords";
            this.buttonRecords.Size = new System.Drawing.Size(144, 82);
            this.buttonRecords.TabIndex = 1;
            this.buttonRecords.Text = "Client Management";
            this.buttonRecords.UseVisualStyleBackColor = true;
            // 
            // buttonAdministration
            // 
            this.buttonAdministration.Location = new System.Drawing.Point(235, 340);
            this.buttonAdministration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAdministration.Name = "buttonAdministration";
            this.buttonAdministration.Size = new System.Drawing.Size(144, 88);
            this.buttonAdministration.TabIndex = 2;
            this.buttonAdministration.Text = "Administration";
            this.buttonAdministration.UseVisualStyleBackColor = true;

            // 
            // MedicalCentreMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 592);
            this.Controls.Add(this.buttonAdministration);
            this.Controls.Add(this.buttonRecords);
            this.Controls.Add(this.labelWelcome);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MedicalCentreMainMenuForm";
            this.Text = "MedicalCentreMainMenuForm";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonRecords;
        private System.Windows.Forms.Button buttonAdministration;
    }
}


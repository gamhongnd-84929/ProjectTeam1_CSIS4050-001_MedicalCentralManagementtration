namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentreAdministrationForm
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
            this.buttonBackupDatabase = new System.Windows.Forms.Button();
            this.buttonRestoreDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBackupDatabase
            // 
            this.buttonBackupDatabase.Location = new System.Drawing.Point(186, 111);
            this.buttonBackupDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBackupDatabase.Name = "buttonBackupDatabase";
            this.buttonBackupDatabase.Size = new System.Drawing.Size(179, 95);
            this.buttonBackupDatabase.TabIndex = 0;
            this.buttonBackupDatabase.Text = "Backup Database";
            this.buttonBackupDatabase.UseVisualStyleBackColor = true;
            // 
            // buttonRestoreDatabase
            // 
            this.buttonRestoreDatabase.Location = new System.Drawing.Point(186, 287);
            this.buttonRestoreDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRestoreDatabase.Name = "buttonRestoreDatabase";
            this.buttonRestoreDatabase.Size = new System.Drawing.Size(179, 95);
            this.buttonRestoreDatabase.TabIndex = 1;
            this.buttonRestoreDatabase.Text = "Restore Database";
            this.buttonRestoreDatabase.UseVisualStyleBackColor = true;
            // 
            // MedicalCentreAdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 552);
            this.Controls.Add(this.buttonRestoreDatabase);
            this.Controls.Add(this.buttonBackupDatabase);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MedicalCentreAdministrationForm";
            this.Text = "MedicalCentreAdministration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBackupDatabase;
        private System.Windows.Forms.Button buttonRestoreDatabase;
    }
}
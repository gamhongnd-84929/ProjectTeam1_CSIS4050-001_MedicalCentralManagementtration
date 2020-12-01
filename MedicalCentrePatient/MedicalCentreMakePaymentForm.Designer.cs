namespace ProjectTeam01MedicalCentreManagement
{
    partial class MedicalCentreMakePaymentForm
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
            this.labelMakePayment = new System.Windows.Forms.Label();
            this.dataGridViewBookings = new System.Windows.Forms.DataGridView();
            this.comboBoxPaymentType = new System.Windows.Forms.ComboBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelTotalAmountNumber = new System.Windows.Forms.Label();
            this.labelPaymentType = new System.Windows.Forms.Label();
            this.buttonMakePayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMakePayment
            // 
            this.labelMakePayment.AutoSize = true;
            this.labelMakePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMakePayment.Location = new System.Drawing.Point(28, 28);
            this.labelMakePayment.Name = "labelMakePayment";
            this.labelMakePayment.Size = new System.Drawing.Size(379, 18);
            this.labelMakePayment.TabIndex = 0;
            this.labelMakePayment.Text = "Please Select One Booking to Make Payment on:";
            // 
            // dataGridViewBookings
            // 
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookings.Location = new System.Drawing.Point(31, 63);
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            this.dataGridViewBookings.RowHeadersWidth = 51;
            this.dataGridViewBookings.RowTemplate.Height = 24;
            this.dataGridViewBookings.Size = new System.Drawing.Size(632, 168);
            this.dataGridViewBookings.TabIndex = 1;
            // 
            // comboBoxPaymentType
            // 
            this.comboBoxPaymentType.FormattingEnabled = true;
            this.comboBoxPaymentType.Location = new System.Drawing.Point(376, 314);
            this.comboBoxPaymentType.Name = "comboBoxPaymentType";
            this.comboBoxPaymentType.Size = new System.Drawing.Size(171, 24);
            this.comboBoxPaymentType.TabIndex = 2;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(117, 257);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(160, 17);
            this.labelAmount.TabIndex = 3;
            this.labelAmount.Text = "Total Amount to Pay:";
            // 
            // labelTotalAmountNumber
            // 
            this.labelTotalAmountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTotalAmountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmountNumber.Location = new System.Drawing.Point(435, 256);
            this.labelTotalAmountNumber.Name = "labelTotalAmountNumber";
            this.labelTotalAmountNumber.Size = new System.Drawing.Size(112, 28);
            this.labelTotalAmountNumber.TabIndex = 4;
            // 
            // labelPaymentType
            // 
            this.labelPaymentType.AutoSize = true;
            this.labelPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentType.Location = new System.Drawing.Point(117, 314);
            this.labelPaymentType.Name = "labelPaymentType";
            this.labelPaymentType.Size = new System.Drawing.Size(220, 17);
            this.labelPaymentType.TabIndex = 5;
            this.labelPaymentType.Text = "Please Select Payment Type:";
            // 
            // buttonMakePayment
            // 
            this.buttonMakePayment.Location = new System.Drawing.Point(281, 376);
            this.buttonMakePayment.Name = "buttonMakePayment";
            this.buttonMakePayment.Size = new System.Drawing.Size(121, 47);
            this.buttonMakePayment.TabIndex = 6;
            this.buttonMakePayment.Text = "Make Payment";
            this.buttonMakePayment.UseVisualStyleBackColor = true;
            // 
            // MedicalCentreMakePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 454);
            this.Controls.Add(this.buttonMakePayment);
            this.Controls.Add(this.labelPaymentType);
            this.Controls.Add(this.labelTotalAmountNumber);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.comboBoxPaymentType);
            this.Controls.Add(this.dataGridViewBookings);
            this.Controls.Add(this.labelMakePayment);
            this.Name = "MedicalCentreMakePaymentForm";
            this.Text = "MedicalCentre: Make Payment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMakePayment;
        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.ComboBox comboBoxPaymentType;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelTotalAmountNumber;
        private System.Windows.Forms.Label labelPaymentType;
        private System.Windows.Forms.Button buttonMakePayment;
    }
}
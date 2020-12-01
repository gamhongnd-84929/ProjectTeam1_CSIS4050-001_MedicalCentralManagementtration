using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;
using MedicalCentreValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreMakePaymentForm : Form
    {
        public MedicalCentreMakePaymentForm(int patientID)
        {
            // initial configuration onload
            Load += MakePaymentForm_Load;
            InitializeComponent();
            // get customer's unpaid bookings
            GetUnpaidBookings(patientID);
            // calculate payment total based on the booking selected
            dataGridViewBookings.SelectionChanged += CalculatePaymentTotal;
            // complete payment on button click
            buttonMakePayment.Click += (s, e) => CompletePayment(patientID);
        }

        /// <summary>
        /// Set up initial cofiguration for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakePaymentForm_Load(object sender, EventArgs e)
        {
            // clear all payment types
            comboBoxPaymentType.Items.Clear();
            // prevent user editing payment options
            comboBoxPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            // load to control possible payment options
            comboBoxPaymentType.DataSource = Controller<MedicalCentreManagementEntities, Payment_Types>.GetEntities();
        }

        /// <summary>
        /// Set up the datagridview with the unpaid bookings
        /// </summary>
        /// <param name="patientID"> id of the customer whose bookings are searched </param>
        private void GetUnpaidBookings(int patientID)
        {
            dataGridViewBookings.ColumnCount = 5;
            // Set the column header names.
            dataGridViewBookings.Columns[0].Name = "Booking ID";
            dataGridViewBookings.Columns[1].Name = "Practitioner Last Name";
            dataGridViewBookings.Columns[2].Name = "Booking Time";
            dataGridViewBookings.Columns[3].Name = "Booking Date";
            dataGridViewBookings.Columns[4].Name = "Booking Price";

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                Customer customer = context.Customers.Find(patientID);
                // loop through all bookings
                foreach (Booking booking in customer.Bookings)
                {
                    // if status is not paid - add
                    if (booking.BookingStatus == "Not Paid")
                    {
                        string[] rowAdd = { booking.BookingID.ToString(), context.Users.Find(booking.Practitioner.UserID).LastName, booking.Time, booking.Date, booking.BookingPrice.ToString("C2") };
                        // add to display
                        dataGridViewBookings.Rows.Add(rowAdd);
                    }

                }

            }
            // set all properties
            dataGridViewBookings.AllowUserToAddRows = false;
            dataGridViewBookings.AllowUserToDeleteRows = false;
            dataGridViewBookings.ReadOnly = true;
            dataGridViewBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Calculate payment total based on selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatePaymentTotal(object sender, EventArgs e)
        {
            // get how many rows are selected
            var rowsCount = dataGridViewBookings.SelectedRows.Count;

            // if more than 1 or none- error
            if (rowsCount > 1 || rowsCount == 0)
            {
                labelTotalAmountNumber.Text = "";
                MessageBox.Show("");
                return;
            }

            decimal totalAmount = decimal.Parse(Regex.Replace((string)dataGridViewBookings.SelectedRows[0].Cells[4].Value, @"[^\d.]", ""));

            labelTotalAmountNumber.Text = totalAmount.ToString("C2");
        }
        private void CompletePayment(int patientID)
        {
            if (dataGridViewBookings.SelectedRows.Count != 1)
            {
                MessageBox.Show("One Booking needs to be selected to complete payment");
                return;
            }
            Payment newPayment = new Payment
            {
                CustomerID = patientID,
                TotalAmountPaid = decimal.Parse(Regex.Replace(labelTotalAmountNumber.Text, @"[^\d.]", "")),
                BookingID = Convert.ToInt32(dataGridViewBookings.SelectedRows[0].Cells[0].Value),
                PaymentTypeID = (comboBoxPaymentType.SelectedItem as Payment_Types).PaymentTypeID,
                PaymentStatus = "Approved",
                Date = DateTime.Now.ToString("MM-dd-yyyy"),
                Time = DateTime.Now.ToString("HH:mm"),

            };

            // validate payment 
            if (newPayment.InfoIsInvalid())
            {
                MessageBox.Show("Please fill payment information");
                return;
            }




            if (Controller<MedicalCentreManagementEntities, Payment>.AddEntity(newPayment) == null)
            {
                MessageBox.Show("Payment was not added to the database!");
                return;
            }
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.Bookings.Find(newPayment.BookingID).BookingStatus = "Paid";
                context.SaveChanges();
            }
            this.DialogResult = DialogResult.OK;
            Close();

        }

     




    }
}

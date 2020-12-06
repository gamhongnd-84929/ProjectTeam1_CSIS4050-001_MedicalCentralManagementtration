using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentrePatientOptionsMainForm : Form
    {
        public MedicalCentrePatientOptionsMainForm(int customerID)
        {

            InitializeComponent();
            // set up form controls
            InitializeFormInformation(customerID);
           
            // create and add to button click Child forms
            MedicalCentreUpdatePatient medicalCentreUpdatePatient = new MedicalCentreUpdatePatient(customerID);
            buttonUpdateInformation.Click += (s, e) => ChildPatientActionsForm(medicalCentreUpdatePatient, customerID);
            MedicalCentreBookAppointment bookAppointment = new MedicalCentreBookAppointment(customerID);
            buttonBookAppointment.Click += (s, e) => ChildPatientActionsForm(bookAppointment, customerID);

            // add event methods to other buttons
            buttonMakePayment.Click += (s, e) => IsNeededPayment(customerID);
            buttonCancelBooking.Click += (s, e) => CancelBooking(customerID);
        }

        /// <summary>
        /// Method to set up controls in a form
        /// </summary>
        /// <param name="customerID"> id of the customer to be used for setup</param>
        private void InitializeFormInformation(int customerID)
        {
            // call individual methods 
            GetGreeting(customerID);
            InitializePatientsBookings(dataGridViewPatientBookings, customerID);
            InitializePatientsPayments(dataGridViewPatientPayments, customerID);
            IsActiveCustomer(customerID);
        }

        /// <summary>
        /// Method to get personalized greeting for the customer
        /// </summary>
        /// <param name="customerID"> id of the customer</param>
        private void GetGreeting(int customerID)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // find customer in db
                var customer = context.Customers.Find(customerID);
                //find user in db
                var user = context.Users.Find(customer.UserID);
                // set label
                labelPatientName.Text = $"Patient Name: {user.LastName}, {user.FirstName}";
            }
        }

        /// <summary>
        /// Method to set up the Patients booking display
        /// </summary>
        /// <param name="datagridview"> datagridview to be populated </param>
        /// <param name="customerID"> id of the customer</param>
        private static void InitializePatientsBookings(DataGridView datagridview, int customerID)
        {
            datagridview.Rows.Clear();
            // set number of columns
            datagridview.ColumnCount = 7;
            // Set the column header names.
            datagridview.Columns[0].Name = "Booking ID";
            datagridview.Columns[1].Name = "Practitioner Last Name";
            datagridview.Columns[2].Name = "Booking Time";
            datagridview.Columns[3].Name = "Booking Date";
            datagridview.Columns[4].Name = "Practitioner Comment";
            datagridview.Columns[5].Name = "Booking Price";
            datagridview.Columns[6].Name = "Booking Status";

            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                Customer customer = context.Customers.Find(customerID);
                // loop through all bookings
                foreach (Booking booking in customer.Bookings)
                {
                    // get the needed information
                    string[] rowAdd = { booking.BookingID.ToString(), context.Users.Find(booking.Practitioner.UserID).LastName, booking.Time.ToString(), booking.Date?.ToString("yyyy-MM-dd"), booking.PractitionerComment, booking.BookingPrice.ToString("C2"), booking.BookingStatus.ToString() };
                    // add to display
                    datagridview.Rows.Add(rowAdd);
                }
            }
            // set all properties
            datagridview.AllowUserToAddRows = false;
            datagridview.AllowUserToDeleteRows = false;
            datagridview.ReadOnly = true;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Method to initialize and populate all of customer's payments
        /// </summary>
        /// <param name="datagridview"> datagridview to be populated </param>
        /// <param name="customerID"> id of the customer</param>
        private static void InitializePatientsPayments(DataGridView datagridview, int customerID)
        {
            datagridview.Rows.Clear();
            // set number of columns
            datagridview.ColumnCount = 5;
            // Set the column header names.

            datagridview.Columns[0].Name = "Payment Date";
            datagridview.Columns[1].Name = "Payment Time";
            datagridview.Columns[2].Name = "Payment Amount";
            datagridview.Columns[3].Name = "Payment Type";
            datagridview.Columns[4].Name = "Payment Status";

            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                Customer customer = context.Customers.Find(customerID);
                // loop through all bookings
                foreach (Payment payment in customer.Payments)
                {
                    // get the needed information
                    string[] rowAdd = { payment.Date?.ToString("yyyy-MM-dd"), payment.Time?.ToString("hh\\:mm"), payment.TotalAmountPaid?.ToString("C2"), payment.Payment_Types.ToString(), payment.PaymentStatus.ToString() };
                    // add to display
                    datagridview.Rows.Add(rowAdd);
                }
            }
            // set all properties
            datagridview.AllowUserToAddRows = false;
            datagridview.AllowUserToDeleteRows = false;
            datagridview.ReadOnly = true;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        /// <summary>
        /// Method to display a child form
        /// </summary>
        /// <param name="form"> form to be loaded</param>
        /// <param name="customerID"> customer id </param>
        private void ChildPatientActionsForm(Form form, int customerID)
        {
            // show child form
            var result = form.ShowDialog();
            // if okay was clicked on the child
            if (result == DialogResult.OK)
            {
                // reload controls
                InitializePatientsBookings(dataGridViewPatientBookings, customerID);
                InitializePatientsPayments(dataGridViewPatientPayments, customerID);
                GetGreeting(customerID);
                IsActiveCustomer(customerID);

            }
            // hide the child form
            form.Hide();

        }

        /// <summary>
        /// Method to figure out if customer has any outstanding payments and display form if needed
        /// </summary>
        /// <param name="customerID"></param>
        private void IsNeededPayment(int customerID)
        {
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // find customer
                Customer customer = context.Customers.Find(customerID);
                // loop through all bookings
                foreach (Booking booking in customer.Bookings)
                {
                    // if not paid- load form
                    if (booking.BookingStatus == BookingStatus.NOT_PAID)
                    {
                        ChildPatientActionsForm(new MedicalCentreMakePaymentForm(customerID), customerID);
                        return;
                    }
                }
                // if no not paid bookings- message
               MessageBox.Show("This Customer has no Unpaid Bookings!");

            }

        }

        /// <summary>
        /// Method to cancel customer's booking
        /// </summary>
        /// <param name="customerID"></param>
        private void CancelBooking(int customerID)
        {
            // make sure a booking is selected
            if (dataGridViewPatientBookings.SelectedRows.Count != 1)
            {
                MessageBox.Show("One Booking needs to be selected to perform cancellation");
                return;
            }
            // get bookings date and time
            string date = (string)dataGridViewPatientBookings.SelectedRows[0].Cells[3].Value;
            string time = (string)dataGridViewPatientBookings.SelectedRows[0].Cells[2].Value;
            // create date object
            DateTime bookingDate = DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm:ss",
                                             null);
            // if in the past (less than today)
            if (DateTime.Now > bookingDate)
            {
                // display error + return
                MessageBox.Show("Cannot Cancel past bookings!");
                return;
            }

            // if a booking is paid
            if ((string)dataGridViewPatientBookings.SelectedRows[0].Cells[6].Value == BookingStatus.PAID.ToString())
            {
                // using unit-of-work
                using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
                {
                    // get bookingId
                    int bookingID = Convert.ToInt32(dataGridViewPatientBookings.SelectedRows[0].Cells[0].Value);
                    // find the payment for this booking
                    var paymentToRefund = context.Payments.Where(p => p.BookingID == bookingID).ToList();
                    // set payment's status to Refunded
                    foreach (Payment payment in paymentToRefund)
                        payment.PaymentStatus = PaymentStatus.REFUNDED;
                    // save changes
                    context.SaveChanges();
                }
                // reload Payments view to show update
                InitializePatientsPayments(dataGridViewPatientPayments, customerID);
            }

            // whether or not booking is paid- change it to Cancelled
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // find booking by PK
                var bookingToChange = context.Bookings.Find(Convert.ToInt32(dataGridViewPatientBookings.SelectedRows[0].Cells[0].Value));
                // set new values
                bookingToChange.BookingStatus = BookingStatus.CANCELLED;
                bookingToChange.BookingPrice = 0.0m;
                bookingToChange.Date = null;
                bookingToChange.Time = null;
                //save changes
                context.SaveChanges();
            }
            //update booking view
            InitializePatientsBookings(dataGridViewPatientBookings, customerID);

        }

        /// <summary>
        /// Method to check if a customer is able to make bookings or if their account was suspended
        /// Suspended if any outstanding bills for 7 days!
        /// </summary>
        /// <param name="customerID"> id of the customer </param>
        private void IsActiveCustomer(int customerID)
        {
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // find customer
                Customer customer = context.Customers.Find(customerID);
                // loop through all bookings
                foreach (Booking booking in customer.Bookings)
                {
                    DateTime bookingDate = (DateTime)(booking.Date);
                   if (bookingDate.AddDays(7) < DateTime.Today.Date && booking.BookingStatus == BookingStatus.NOT_PAID)
                    {
                        MessageBox.Show("Your account is suspended due to outstanding balance! Please make a payment to be able to make appointments!");
                        buttonBookAppointment.Enabled = false;
                        return;
                    }
                }
                buttonBookAppointment.Enabled = true;

            }
        }
    }
}

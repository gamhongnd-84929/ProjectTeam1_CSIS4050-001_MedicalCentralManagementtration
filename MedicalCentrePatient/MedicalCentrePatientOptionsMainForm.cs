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
        public MedicalCentrePatientOptionsMainForm(int patientID)
        {

           
            InitializeComponent();
            GetGreeting(patientID);
            InitializePatientsBookings(dataGridViewPatientBookings, patientID);
            InitializePatientsPayments(dataGridViewPatientPayments, patientID);
            MedicalCentreUpdatePatient medicalCentreUpdatePatient = new MedicalCentreUpdatePatient(patientID);
            buttonUpdateInformation.Click += (s, e) => ChildPatientActionsForm(medicalCentreUpdatePatient,  patientID);

            MedicalCentreBookAppointment bookAppointment = new MedicalCentreBookAppointment(patientID);
            buttonBookAppointment.Click += (s, e) => ChildPatientActionsForm(bookAppointment, patientID);

            buttonMakePayment.Click += (s, e) => IsNeededPayment(patientID);

            buttonCancelBooking.Click += (s, e) => CancelBooking(patientID);
        }

        private void CancelBooking(int patientID)
        {
            if (dataGridViewPatientBookings.SelectedRows.Count != 1)
            {
                MessageBox.Show("One Booking needs to be selected to perform cancellation");
                return;
            }

            string date = (string)dataGridViewPatientBookings.SelectedRows[0].Cells[3].Value;
            string time = (string)dataGridViewPatientBookings.SelectedRows[0].Cells[2].Value;
           
            DateTime bookingDate = DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm",
                                             null);

            if (DateTime.Now > bookingDate)
            {
                MessageBox.Show("Cannot Cancel past bookings!");
                return;
            }

            if ((string)dataGridViewPatientBookings.SelectedRows[0].Cells[6].Value == "Paid")
            {
               

                using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
                {
                    var paymentToRefund = context.Payments.Where(p => p.BookingID == Convert.ToInt32(dataGridViewPatientBookings.SelectedRows[0].Cells[0].Value)).ToList();

                    foreach(Payment payment  in paymentToRefund)
                    payment.PaymentStatus = "Refunded";

                    context.SaveChanges();
                }
                InitializePatientsPayments(dataGridViewPatientPayments, patientID);
            }
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var bookingToChange = context.Bookings.Find(Convert.ToInt32(dataGridViewPatientBookings.SelectedRows[0].Cells[0].Value));

                bookingToChange.BookingStatus = "Cancelled";
                bookingToChange.BookingPrice = 0.0m;
                bookingToChange.Date = "N/A";
                bookingToChange.Time = "N/A";

                context.SaveChanges();
            }
            InitializePatientsBookings(dataGridViewPatientBookings, patientID);


        }

        private  void IsNeededPayment(int patientID)
        {
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
               
                Customer customer = context.Customers.Find(patientID);
                // loop through all bookings
                foreach (Booking booking in customer.Bookings)
                {
                    if (booking.BookingStatus == "Not Paid")
                    {
                        ChildPatientActionsForm(new MedicalCentreMakePaymentForm(patientID), patientID);
                        return;
                    }
                }
              
                MessageBox.Show("This Customer has no Unpaid Bookings!");

            }

        }

        private static void InitializePatientsBookings(DataGridView datagridview, int patientID)
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
                Customer customer = context.Customers.Find(patientID);
                // loop through all bookings
                foreach (Booking booking in customer.Bookings)
                {
                    // get the needed information
                    string[] rowAdd = { booking.BookingID.ToString(), context.Users.Find(booking.Practitioner.UserID).LastName, booking.Time, booking.Date, booking.PractitionerComment, booking.BookingPrice.ToString("C2"), booking.BookingStatus };
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

        private static void InitializePatientsPayments(DataGridView datagridview, int patientID)
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
                Customer customer = context.Customers.Find(patientID);
                // loop through all bookings
                foreach (Payment payment in customer.Payments)
                {
                    // get the needed information
                    string[] rowAdd = {  payment.Date, payment.Time, payment.TotalAmountPaid?.ToString("C2"), payment.Payment_Types.ToString(), payment.PaymentStatus };
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
        private void GetGreeting(int patientID)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var customer = context.Customers.Find(patientID);
                var user = context.Users.Find(customer.UserID);
                labelPatientName.Text = $"Patient Name: {user.LastName}, {user.FirstName}";
            }
        }

        private  void ChildPatientActionsForm(Form form, int patientID)
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                InitializePatientsBookings(dataGridViewPatientBookings, patientID);
                InitializePatientsPayments(dataGridViewPatientPayments, patientID);
                GetGreeting(patientID);

            }
            // hide the child form
            form.Hide();
            
        }
    }
}

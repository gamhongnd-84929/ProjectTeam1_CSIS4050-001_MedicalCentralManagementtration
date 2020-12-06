using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalCentreCodeFirstFromDB;
using EFControllerUtilities;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentrePractitionerOptionsMainForm : Form
    {
        public MedicalCentrePractitionerOptionsMainForm(int practitionerID)
        {
            this.Text = "Medical Centre: Practition's Options";
            InitializeComponent();

            GetGreeting(practitionerID);
            InitializePractitionersBookings(dataGridViewPractitionerBookings, practitionerID);

            MedicalCentreUpdatePractitioner medicalCentreUpdatePractitioner = new MedicalCentreUpdatePractitioner(practitionerID);
            buttonUpdatePractitioner.Click += (s, e) => ChildPatientActionsForm(medicalCentreUpdatePractitioner, practitionerID);

            MedicalCentreBookHoursOff medicalCentreBookHoursOff = new MedicalCentreBookHoursOff(practitionerID);
            buttonBookHoursOff.Click += (s, e) => ChildPatientActionsForm(medicalCentreBookHoursOff, practitionerID);

            dataGridViewPractitionerBookings.SelectionChanged += PrePopulateComment;
            buttonUpdateComment.Click += (s, e) => UpdateComment(practitionerID);
            buttonCancelBooking.Click += (s, e) => CancelBooking(practitionerID);
        }

        /// <summary>
        /// Method to cancel booking
        /// </summary>
        /// <param name="practitionerID"></param>
        private void CancelBooking(int practitionerID)
        {
            // make sure a booking is selected
            if (dataGridViewPractitionerBookings.SelectedRows.Count != 1)
            {
                MessageBox.Show("One Booking needs to be selected to perform cancellation");
                return;
            }

            // get booking date and time
            string date = (string)dataGridViewPractitionerBookings.SelectedRows[0].Cells[4].Value;
            string time = (string)dataGridViewPractitionerBookings.SelectedRows[0].Cells[3].Value;
            // create date object
            DateTime bookingDate = DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm", null);

            // if the date is in the past date display error message
            if (DateTime.Now > bookingDate)
            {
                MessageBox.Show("Cannot cancel past bookings!");
                return;
            }

            // get the bookingID
            int bookingID = Convert.ToInt32(dataGridViewPractitionerBookings.SelectedRows[0].Cells[0].Value);

            // if a booking is paid
            if ((string)dataGridViewPractitionerBookings.SelectedRows[0].Cells[6].Value == BookingStatus.PAID.ToString())
            {
                // using unit of work
                using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
                {
                    // find the payment for this booking
                    List<Payment> paymentToRefund = context.Payments.Where(p => p.BookingID == bookingID).ToList();
                    // set payment's status to Refunded
                    foreach (Payment payment in paymentToRefund)
                    {
                        payment.PaymentStatus = PaymentStatus.REFUNDED;
                    }
                    // save changes
                    context.SaveChanges();
                }
            }

            // whether the booking is paid or not - change it to Cancelled
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // find booking by PK
                Booking bookingToChange = context.Bookings.Find(bookingID);
                // set new values
                bookingToChange.BookingStatus = BookingStatus.CANCELLED;
                bookingToChange.BookingPrice = 0.0m;
                bookingToChange.Date = null;
                bookingToChange.Time = null;
                // save changes
                context.SaveChanges();
            }
            // update booking view
            InitializePractitionersBookings(dataGridViewPractitionerBookings, practitionerID);

        }

        /// <summary>
        /// Prepopulate comment section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrePopulateComment(object sender, EventArgs e)
        {
            if (dataGridViewPractitionerBookings.SelectedRows.Count <= 0) return;
            int bookingID = Convert.ToInt32(dataGridViewPractitionerBookings.SelectedRows[0].Cells[0].Value);
            var bookingToUpdate = Controller<MedicalCentreManagementEntities, Booking>.FindEntity(bookingID);

            // prepopulate comment field
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                textBoxComment.Text = bookingToUpdate.PractitionerComment;
            }
        }


        /// <summary>
        /// Get the current booking and update the practitioner's comment
        /// </summary>
        private void UpdateComment(int practitionerID)
        {
            if (dataGridViewPractitionerBookings.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select a Booking to Update a Comment");
            }
            else
            {
                if (textBoxComment.TextLength == 0)
                {
                    MessageBox.Show("Please type some comment");
                    return;
                }

                // get booing to be updated
                int bookingID = Convert.ToInt32(dataGridViewPractitionerBookings.SelectedRows[0].Cells[0].Value);
                var bookingToUpdate = Controller<MedicalCentreManagementEntities, Booking>.FindEntity(bookingID);

                // Updated the comment
                string newComment = textBoxComment.Text;
                bookingToUpdate.PractitionerComment = newComment;

                if (Controller<MedicalCentreManagementEntities, Booking>.UpdateEntity(bookingToUpdate) == false)
                {
                    MessageBox.Show("Cannot update User to database");
                    return;
                }


                // reload the datagridview
                InitializePractitionersBookings(dataGridViewPractitionerBookings, practitionerID);

            }
        }

        /// <summary>
        /// set datagridview properties, columns, and populate rows
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="practitionerID"></param>
        private void InitializePractitionersBookings(DataGridView dataGridView, int practitionerID)
        {
            dataGridView.Rows.Clear();
            // set number of columns
            dataGridView.ColumnCount = 7;
            // set the column header names
            dataGridView.Columns[0].Name = "Booking ID";
            dataGridView.Columns[1].Name = "Customer First Name";
            dataGridView.Columns[2].Name = "Customer Last Name";
            dataGridView.Columns[3].Name = "Booking Time";
            dataGridView.Columns[4].Name = "Booking Date";
            dataGridView.Columns[5].Name = "Practitioner Comment";
            dataGridView.Columns[6].Name = "Booking Status";

            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                Practitioner practitioner = context.Practitioners.Find(practitionerID);
                // loop through all bookings
                foreach (Booking booking in practitioner.Bookings)
                {
                    // get the needed information
                    string[] rowAdd = {
                        booking.BookingID.ToString(),
                        context.Users.Find(booking.Customer.UserID).FirstName,
                        context.Users.Find(booking.Customer.UserID).LastName,
                        booking.Time.ToString(),
                        booking.Date?.ToString("yyyy-MM-dd"),
                        booking.PractitionerComment,
                        booking.BookingStatus.ToString()
                    };
                    // add to display
                    dataGridView.Rows.Add(rowAdd);
                }
            }
            // set all properties
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// using passed practitionerID to get Practitioner's name for greeting
        /// </summary>
        /// <param name="practitionerID"></param>
        private void GetGreeting(int practitionerID)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var practitioner = context.Practitioners.Find(practitionerID);
                var user = context.Users.Find(practitioner.UserID);
                labelPractitionerName.Text = $"Practitioner Name: {user.LastName}, {user.FirstName}";
            }
        }

        /// <summary>
        /// Show, hide child from as well as update the practitioner bookings
        /// </summary>
        /// <param name="form"></param>
        /// <param name="practitionerID"></param>
        private void ChildPatientActionsForm(Form form, int practitionerID)
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                InitializePractitionersBookings(dataGridViewPractitionerBookings, practitionerID);
                GetGreeting(practitionerID);
            }
            // hide the child form
            form.Hide();

        }
    }
}

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

            this.Text = "Medical Centre: Patient's Options";
            InitializeComponent();
            
            GetGreeting(patientID);
            InitializePatientsBookings(dataGridViewPatientBookings, patientID);
            MedicalCentreUpdatePatient medicalCentreUpdatePatient = new MedicalCentreUpdatePatient(patientID);
            buttonUpdateInformation.Click += (s, e) => ChildPatientActionsForm(medicalCentreUpdatePatient,  patientID);

            MedicalCentreBookAppointment bookAppointment = new MedicalCentreBookAppointment(patientID);
            buttonBookAppointment.Click += (s, e) => ChildPatientActionsForm(bookAppointment, patientID);

        }

        private static void InitializePatientsBookings(DataGridView datagridview, int patientID)
        {
            datagridview.Rows.Clear();
            // set number of columns
            datagridview.ColumnCount = 7;
            // Set the column header names.
            datagridview.Columns[0].Name = "Practitioner ID";
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
                // loop through all courses
                foreach (Booking booking in customer.Bookings)
                {

                    // get the needed information
                    string[] rowAdd = { booking.PractitionerID.ToString(), context.Users.Find(booking.Practitioner.UserID).LastName, booking.Time, booking.Date, booking.PractitionerComment, booking.BookingPrice.ToString(), booking.BookingStatus };
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


        private void ChildPatientActionsForm(Form form, int patientID)
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                InitializePatientsBookings(dataGridViewPatientBookings, patientID);
                GetGreeting(patientID);

            }
            // hide the child form
            form.Hide();
            this.DialogResult = DialogResult.OK;
        }
    }
}

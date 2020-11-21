using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;
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
    public partial class MedicalCentreBookAppointment : Form
    {
        public MedicalCentreBookAppointment(int patientID)
        {
            this.Load += BookAppointmentForm_Load;
            InitializeComponent();
            monthCalendarBooking.MaxSelectionCount = 1;
            listBoxTime.Items.Clear();
            listBoxServices.SelectedIndexChanged += (s, e) => GetListOfPractitioners();
            listBoxPractitioners.SelectedIndexChanged += (s, e) => GetPractitionerAvailability();
            monthCalendarBooking.DateChanged += (s, e) => { if (listBoxPractitioners.SelectedIndex != -1) GetPractitionerAvailability(); };
            listBoxTime.SelectedIndexChanged += (s, e) => GetBookingInformation(patientID);
            buttonCreateBooking.Click += (s, e) => CreateBooking(patientID);
        }

        private void CreateBooking(int patientID)
        {
            Booking newBooking = new Booking
            {
                CustomerID = patientID,
                PractitionerID = (listBoxPractitioners.SelectedItem as Practitioner).PractitionerID,
                Date = monthCalendarBooking.SelectionRange.Start.ToShortDateString(),
                Time = listBoxTime.SelectedItem.ToString(),
                BookingPrice = decimal.Parse(Regex.Replace(labelPriceAmount.Text, @"[^\d.]", "")),
                BookingStatus = "Not Paid",
                PractitionerComment=""

            };
            newBooking.Services.Add(listBoxServices.SelectedItem as Service);
            if (Controller<MedicalCentreManagementEntities, Booking>.AddEntity(newBooking) == null)
            {
                MessageBox.Show("Cannot add booking to database");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void GetBookingInformation(int patientID)
        {
            Service service = listBoxServices.SelectedItem as Service;
            Practitioner practitioner = listBoxPractitioners.SelectedItem as Practitioner;
            string date = monthCalendarBooking.SelectionRange.Start.ToShortDateString();
            string time = listBoxTime.SelectedItem.ToString();
            labelBookingSummary.Text = $"Booking Information \n\nService: {service}\nPractitioner: {practitioner}\nBooking Date: {date}\nBooking Time: {time}\nMSP Coverage of Service:{(service.MSPCoverage * 100).ToString()}%";

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var customer = context.Customers.Find(patientID);
                decimal bookingPrice;
                if (customer.MSP != null)
                {

                    bookingPrice = (service.ServicePrice * (1 - service.MSPCoverage));
                }
                else
                {
                    bookingPrice = service.ServicePrice;
                }
                labelPriceAmount.Text = $"{bookingPrice:C2}";
            }
        }

        private void GetPractitionerAvailability()
        {
            LoadAllPossibleTimes();
            if (!(listBoxPractitioners.SelectedItem is Practitioner practitioner))
                return;
            if (monthCalendarBooking.SelectionRange.Start < monthCalendarBooking.TodayDate)
            {
                MessageBox.Show("Cannot book appointments before today's date!");
                return;
            }
            string dateRequested = monthCalendarBooking.SelectionRange.Start.ToShortDateString();
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var bookingsOnThatDate = context.Bookings.Select(b => b).Where(b => b.PractitionerID == practitioner.PractitionerID && b.Date == dateRequested).ToList();

                foreach (Booking b in bookingsOnThatDate)
                {
                    listBoxTime.Items.Remove(b.Time);
                }

            }
        }

        private void GetListOfPractitioners()
        {

            if (!(listBoxServices.SelectedItem is Service service))
                return;

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var listOfPractitioners = context.Practitioners.Select(p => p).Where(p => p.TypeID == service.PractitionerTypeID).ToList();
                listBoxPractitioners.DataSource = listOfPractitioners;

            }
        }

        private void BookAppointmentForm_Load(object sender, EventArgs e)
        {
            var services = Controller<MedicalCentreManagementEntities, Service>.GetEntitiesWithIncluded("Practitioner_Types");
            listBoxServices.DataSource = services;
            LoadAllPossibleTimes();
        }
        private void LoadAllPossibleTimes()
        {
            listBoxTime.Items.Clear();
            listBoxTime.Items.AddRange(new string[] { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00" });
        }


    }
}

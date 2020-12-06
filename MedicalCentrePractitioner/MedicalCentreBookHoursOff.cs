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
using MedicalCentreValidation;
using MedicalCentreUtilities;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreBookHoursOff : Form
    {
        public MedicalCentreBookHoursOff(int practitionerID)
        {
            InitializeComponent();
            monthCalendarBookingDate.MaxSelectionCount = 1;
            BaseFormMethods.ClearAllControls(this);
            monthCalendarBookingDate.DateChanged += (s, e) => GetPractitionerAvailability(practitionerID);
            buttonBookTimeOff.Click += (s, e) => BookTimeOff(practitionerID);
        }

        /// <summary>
        /// Book time off using empty customer for practitioner's time off booking
        /// </summary>
        /// <param name="practitionerID"></param>
        private void BookTimeOff(int practitionerID)
        {
            if (listBoxTime.SelectedItem == null)
            {
                MessageBox.Show("Please select a time");
                return;
            }

            Booking timeOffBooking = new Booking
            {
                CustomerID = 6,
                PractitionerID = practitionerID,
                Date = monthCalendarBookingDate.SelectionRange.Start,
                Time = (TimeSpan)listBoxTime.SelectedItem,
                BookingPrice = 0,
                BookingStatus = BookingStatus.TIME_OFF,
                PractitionerComment = ""
            };

            // Booking validation
            if (timeOffBooking.InfoIsInvalid())
            {
                MessageBox.Show("Booking information is invalid. Please check and try it again.");
                return;
            }

            if (Controller<MedicalCentreManagementEntities, Booking>.AddEntity(timeOffBooking) == null)
            {
                MessageBox.Show("Cannot add time off booking to database");
                return;
            }
            BaseFormMethods.ClearAllControls(this);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Get current practitioner's availability and remove not available time from the time listbox
        /// </summary>
        /// <param name="practitionerID"></param>
        private void GetPractitionerAvailability(int practitionerID)
        {

            if (monthCalendarBookingDate.SelectionRange.Start < monthCalendarBookingDate.TodayDate)
            {
                MessageBox.Show("Cannot book appointments before today's date!");
                return;
            }
            DateTime dateRequested = monthCalendarBookingDate.SelectionRange.Start;
            List<TimeSpan> times = new List<TimeSpan>();
            for (int hour = 9; hour <= 16; hour++)
            {
                TimeSpan appointmentTime = new TimeSpan(hour, 0, 0);
                // make sure that today's past time appointments are not shown!
                if (dateRequested != DateTime.Now.Date || appointmentTime > DateTime.Now.TimeOfDay)
                {
                    times.Add(appointmentTime);
                }
            }

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // get all bookings for that doctor on that date
                var bookingsOnThatDate = context.Bookings.Where(b => b.PractitionerID == practitionerID && b.Date == dateRequested).ToList();

                // remove from the list all times that match
                foreach (Booking b in bookingsOnThatDate)
                {
                    times.Remove((TimeSpan)b.Time);
                }
            }


            // add new range
            listBoxTime.DataSource = times;
        }

    }
}

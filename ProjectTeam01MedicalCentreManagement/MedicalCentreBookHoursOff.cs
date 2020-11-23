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
    public partial class MedicalCentreBookHoursOff : Form
    {
        public MedicalCentreBookHoursOff(int practitionerID)
        {
            InitializeComponent();
            monthCalendarBookingDate.MaxSelectionCount = 1;
            listBoxTime.Items.Clear();
            monthCalendarBookingDate.DateChanged += (s, e) => { GetPractitionerAvailability(practitionerID); };
            buttonBookTimeOff.Click += (s, e) => BookTimeOff(practitionerID);
        }

        /// <summary>
        /// Book time off using empty customer for practitioner's time off booking
        /// </summary>
        /// <param name="practitionerID"></param>
        private void BookTimeOff(int practitionerID)
        {
            Booking timeOffBooking = new Booking
            {
                CustomerID = 6,
                PractitionerID = practitionerID,
                Date = monthCalendarBookingDate.SelectionRange.Start.ToShortDateString(),
                Time = listBoxTime.SelectedItem.ToString(),
                BookingPrice = 0,
                BookingStatus = "Time Off",
                PractitionerComment = ""
            };

            if (Controller<MedicalCentreManagementEntities, Booking>.AddEntity(timeOffBooking) == null)
            {
                MessageBox.Show("Cannot add time off booking to database");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Get current practitioner's availability and remove not available time from the time listbox
        /// </summary>
        /// <param name="practitionerID"></param>
        private void GetPractitionerAvailability(int practitionerID)
        {
            LoadAllPossibleTimes();
            if (monthCalendarBookingDate.SelectionRange.Start < monthCalendarBookingDate.TodayDate)
            {
                MessageBox.Show("Cannot book appointments before today's date!");
                return;
            }
            string dateRequested = monthCalendarBookingDate.SelectionRange.Start.ToShortDateString();
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var bookingOnThatDate = context.Bookings.Select(b => b).Where(b => b.PractitionerID == practitionerID && b.Date == dateRequested).ToList();

                foreach (Booking b in bookingOnThatDate)
                {
                    listBoxTime.Items.Remove(b.Time);
                }
            }
        }

        /// <summary>
        /// Getting all the possible timesand add it to the time listbox
        /// </summary>
        private void LoadAllPossibleTimes()
        {
            listBoxTime.Items.Clear();
            listBoxTime.Items.AddRange(new string[] { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00" });
        }
    }
}

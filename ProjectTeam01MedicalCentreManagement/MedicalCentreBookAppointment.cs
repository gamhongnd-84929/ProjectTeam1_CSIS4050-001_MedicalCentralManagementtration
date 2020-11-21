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
    public partial class MedicalCentreBookAppointment : Form
    {
        public MedicalCentreBookAppointment(int patientID)
        {
            this.Load += BookAppointmentForm_Load;
            InitializeComponent();
            monthCalendarBooking.MaxSelectionCount = 1;
            listBoxServices.SelectedIndexChanged += (s, e) => GetListOfPractitioners();
            listBoxPractitioners.SelectedIndexChanged += (s, e) => GetPractitionerAvailability();
            monthCalendarBooking.DateChanged +=(s,e)=> { if (listBoxPractitioners.SelectedIndex != -1) GetPractitionerAvailability(); };
        }

        private void GetPractitionerAvailability()
        {
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
                var bookingsOnThatDate = context.Bookings.Select(b => b).Where(b => b.PractitionerID == practitioner.PractitionerID  && b.Date == dateRequested ).ToList();
                


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
            listBoxTime.Items.AddRange(new string[] {"09:00","10:00","11:00","12:00","13:00","14:00", "15:00","16:00" });
        }

  
    }
}

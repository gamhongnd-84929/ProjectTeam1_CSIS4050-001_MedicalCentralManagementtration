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
    public partial class MedicalCentreBookAppointment : Form
    {
        public MedicalCentreBookAppointment(int patientID)
        {
            this.Load += BookAppointmentForm_Load;
            InitializeComponent();
            comboBoxPractitionerTypes.SelectedIndexChanged += (s, e) => GetListOfPractitionersAndServices();
            monthCalendarBooking.DateChanged += (s, e) =>  GetPractitionerAvailability(); 
            listBoxTime.SelectedIndexChanged += (s, e) => GetBookingInformation(patientID);
            buttonCreateBooking.Click += (s, e) => CreateBooking(patientID);
            listBoxServices.SelectedIndexChanged += (s,e) => { if (dataGridViewPractitioners.SelectedRows.Count == 1 && listBoxTime.SelectedIndex != -1) GetBookingInformation(patientID); };
        }

        private void CreateBooking(int patientID)
        {
            if (dataGridViewPractitioners.SelectedRows.Count != 1 || listBoxServices.SelectedIndex == -1 || listBoxTime.SelectedIndex == -1)
            {
                MessageBox.Show("Booking information is missing or is invalid!");
                return;
            }
            Booking newBooking = new Booking
            {
                CustomerID = patientID,
                PractitionerID = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value),
                Date = monthCalendarBooking.SelectionRange.Start.ToShortDateString(),
                Time = listBoxTime.SelectedItem.ToString(),
                BookingPrice = decimal.Parse(Regex.Replace(labelPriceAmount.Text, @"[^\d.]", "")),
                BookingStatus = "Not Paid",
                PractitionerComment = ""

            };
            if (newBooking.InfoIsInvalid())
            {
                MessageBox.Show("Booking information is invalid!");
                return;
            }
            foreach (Service s in listBoxServices.SelectedItems)
            {
                newBooking.Services.Add(s);
            }
            
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
            int practitionerId = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value);
            string date = monthCalendarBooking.SelectionRange.Start.ToShortDateString();
            string time = listBoxTime.SelectedItem.ToString();
            

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                labelBookingSummary.Text = $"Booking Information \n\nPractitioner: {context.Practitioners.Find(practitionerId)}\nBooking Date: {date}\nBooking Time: {time} \n\nServices:";
                var customer = context.Customers.Find(patientID);
                decimal bookingPrice=0;
                foreach (Service s in listBoxServices.SelectedItems)
                {
                    if (customer.MSP != "")
                    {
                        labelBookingSummary.Text += $"\n{s} MSP Coverage: {s.MSPCoverage * 100}% ";
                        bookingPrice += (s.ServicePrice * (1 - s.MSPCoverage));
                    }
                    else
                    {
                        bookingPrice += s.ServicePrice;
                        labelBookingSummary.Text += $"\n{s} Price w/o MSP: {s.ServicePrice:C2} ";
                       
                    }
                }
                
                labelPriceAmount.Text = $"{bookingPrice:C2}";
            }
        }

        private void GetPractitionerAvailability()
        {
            if (dataGridViewPractitioners.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one Practitioner from the DataGridView before choosing a Date!");
                return;
            }
                if (monthCalendarBooking.SelectionRange.Start < monthCalendarBooking.TodayDate)
            {
                MessageBox.Show("Cannot book appointments before today's date!");
                return;
            }
            ResetBookingInformation();
            string dateRequested = monthCalendarBooking.SelectionRange.Start.ToShortDateString();
            LoadAllPossibleTimes();
            int selectedPractitionerId = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value);
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {

                var bookingsOnThatDate = context.Bookings.Where(b => b.PractitionerID == selectedPractitionerId && b.Date == dateRequested).ToList();

                foreach (Booking b in bookingsOnThatDate)
                {
                    listBoxTime.Items.Remove(b.Time);
                }

            }
        }

        private void GetListOfPractitionersAndServices()
        {
            ResetBookingInformation();
            listBoxTime.Items.Clear();
            int typeId = (comboBoxPractitionerTypes.SelectedItem as Practitioner_Types).TypeID;


            listBoxServices.DataSource = Controller<MedicalCentreManagementEntities, Service>.GetEntities().Where(s => s.PractitionerTypeID == typeId).Distinct().ToList();
            LoadPractitionersIntoDataGridView(dataGridViewPractitioners, typeId);



        }

        private void BookAppointmentForm_Load(object sender, EventArgs e)
        {
            // set number of columns
            dataGridViewPractitioners.ColumnCount = 7;
            // Set the column header names.
            dataGridViewPractitioners.Columns[0].Name = "Practitioner ID";
            dataGridViewPractitioners.Columns[1].Name = "First Name";
            dataGridViewPractitioners.Columns[2].Name = "Last Name";
            dataGridViewPractitioners.Columns[3].Name = "Address";
            dataGridViewPractitioners.Columns[4].Name = "City";
            dataGridViewPractitioners.Columns[5].Name = "Province";
            dataGridViewPractitioners.Columns[6].Name = "Phone Number";

            listBoxServices.SelectionMode = SelectionMode.MultiExtended;

            monthCalendarBooking.MaxSelectionCount = 1;

            listBoxTime.Items.Clear();
           
            comboBoxPractitionerTypes.DropDownStyle = ComboBoxStyle.DropDownList;

          comboBoxPractitionerTypes.DataSource = Controller<MedicalCentreManagementEntities, Practitioner_Types>.GetEntities();

            
       
        }
        private void LoadAllPossibleTimes()
        {
            listBoxTime.Items.Clear();
            listBoxTime.Items.AddRange(new string[] { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00" });
        }
        private static void LoadPractitionersIntoDataGridView(DataGridView datagridview, int typeId)
        {
            datagridview.Rows.Clear();
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var practitioners = context.Practitioners.Where(pr => pr.TypeID == typeId);
                // loop through all customers
                foreach (Practitioner practitioner in practitioners)
                {

                    // get the needed information
                    string[] rowAdd = { practitioner.PractitionerID.ToString(), practitioner.User.FirstName, practitioner.User.LastName, practitioner.User.Address, practitioner.User.City, practitioner.User.Province, practitioner.User.PhoneNumber };
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

        private void ResetBookingInformation()
        {
            labelBookingSummary.Text = "";
            labelPriceAmount.Text = "";

        }

    }
}

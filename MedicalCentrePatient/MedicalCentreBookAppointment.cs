using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;
using MedicalCentreUtilities;
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
        public MedicalCentreBookAppointment(int customerID)
        {
            // onload-initial congifuration
            Load += BookAppointmentForm_Load;
            InitializeComponent();
            // add all events to controls
            comboBoxPractitionerTypes.SelectedIndexChanged += (s, e) => GetListOfPractitionersAndServices();
            monthCalendarBooking.DateChanged += (s, e) => GetPractitionerAvailability();
            listBoxTime.SelectedIndexChanged += (s, e) => GetBookingInformation(customerID);
            buttonCreateBooking.Click += (s, e) => CreateBooking(customerID);
            dataGridViewPractitioners.SelectionChanged += (s, e) =>
            {
                if (dataGridViewPractitioners.SelectedRows.Count == 1) { GetPractitionerAvailability(); GetBookingInformation(customerID); };
            };
            // for services if selection changes and time + practitioner are selected- update totals
            listBoxServices.SelectedIndexChanged += (s, e) => { if (dataGridViewPractitioners.SelectedRows.Count == 1) GetBookingInformation(customerID); };
        }

        /// <summary>
        /// Set up initial configuration of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookAppointmentForm_Load(object sender, EventArgs e)
        {


            // set number of columns of the practitioners
            dataGridViewPractitioners.ColumnCount = 7;
            // Set the column header names.
            dataGridViewPractitioners.Columns[0].Name = "Practitioner ID";
            dataGridViewPractitioners.Columns[1].Name = "First Name";
            dataGridViewPractitioners.Columns[2].Name = "Last Name";
            dataGridViewPractitioners.Columns[3].Name = "Address";
            dataGridViewPractitioners.Columns[4].Name = "City";
            dataGridViewPractitioners.Columns[5].Name = "Province";
            dataGridViewPractitioners.Columns[6].Name = "Phone Number";

            // allow multiple service selections
            listBoxServices.SelectionMode = SelectionMode.MultiExtended;

            // make sure only 1 day can be selected on calendar
            monthCalendarBooking.MaxSelectionCount = 1;

            // make sure no times are displayed
            listBoxTime.DataSource = null;

            // make sure no selection is made
            dataGridViewPractitioners.ClearSelection();
            // prevent user inputting a custom practitioner type
            comboBoxPractitionerTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            // load types into the combobox
            comboBoxPractitionerTypes.DataSource = Controller<MedicalCentreManagementEntities, Practitioner_Types>.GetEntities();

            // clear labels
            ResetBookingInformation();
        }

        /// <summary>
        /// Method to display services and practitioners upon selection of type of doctor
        /// </summary>
        private void GetListOfPractitionersAndServices()
        {
            // make sure times are cleared
            listBoxTime.DataSource = null;
            // get id of the selected type
            int typeId = (comboBoxPractitionerTypes.SelectedItem as Practitioner_Types).TypeID;
            // get and display list of services that matches the type of practitioner
            listBoxServices.DataSource = Controller<MedicalCentreManagementEntities, Service>.GetEntities().Where(s => s.PractitionerTypeID == typeId).ToList();
            // load practitioners into datagridview
            LoadPractitionersIntoDataGridView(dataGridViewPractitioners, typeId);
            ResetBookingInformation(); // clear label
        }

        /// <summary>
        /// Method to load all practitioners of a certain type into a datagridview
        /// </summary>
        /// <param name="datagridview"> datagridview to be populated</param>
        /// <param name="typeId"> id of the type </param>
        private static void LoadPractitionersIntoDataGridView(DataGridView datagridview, int typeId)
        {
            // make sure rows are cleared
            datagridview.Rows.Clear();
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // get practitioners of that type
                var practitioners = context.Practitioners.Where(pr => pr.TypeID == typeId);
                // loop through all practitioners
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

        /// <summary>
        /// Get available times of a certain practitioner for a specific date
        /// </summary>
        private void GetPractitionerAvailability()
        {
            // make sure 1 practitioner is selected
            if (dataGridViewPractitioners.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one Practitioner from the DataGridView before choosing a Date!");
                return;
            }
            // make sure date selected is not in the past
            if (monthCalendarBooking.SelectionRange.Start < monthCalendarBooking.TodayDate)
            {
                MessageBox.Show("Cannot book appointments before today's date!");
                return;
            }

            // clear previous booking information
            ResetBookingInformation();

            // get the date requested from month control
            DateTime dateRequested = monthCalendarBooking.SelectionRange.Start;

            // get selected practitioner's id
            int selectedPractitionerId = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value);

            LoadAllAvailableTimes(dateRequested, selectedPractitionerId);


        }

        /// <summary>
        /// Get all available times for a doctor on a requested date
        /// </summary>
        /// <param name="dateRequested"> date requested </param>
        /// <param name="selectedPractitionerId"> id of the practitioner requested</param>
        private void LoadAllAvailableTimes(DateTime dateRequested, int selectedPractitionerId)
        {
            // create all times
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
            // using unit-of-work
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // get all bookings for that doctor on that date
                var bookingsOnThatDate = context.Bookings.Where(b => b.PractitionerID == selectedPractitionerId && b.Date == dateRequested).ToList();

                // remove from the list all times that match
                foreach (Booking b in bookingsOnThatDate)
                {
                    times.Remove((TimeSpan)b.Time);
                }
            }

            // add new range
            listBoxTime.DataSource = times;
        }

        /// <summary>
        /// Method to display all requested booking information
        /// </summary>
        /// <param name="customerID"> id of the patient requesting a booking</param>
        private void GetBookingInformation(int customerID)
        {

            // get the practitioner/date and time from controls
            int practitionerId = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value);
            string date = monthCalendarBooking.SelectionRange.Start.ToShortDateString();
            string time = listBoxTime.SelectedItem?.ToString();

            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // display booking info in form
                labelBookingSummary.Text = $"Booking Information \n\nPractitioner: {context.Practitioners.Find(practitionerId)}\nBooking Date: {date}\nBooking Time: {time} \n\nServices:";
                // find customer
                var customer = context.Customers.Find(customerID);
                decimal bookingPrice = 0; // initialize booking price
                // go through all services selected
                foreach (Service s in listBoxServices.SelectedItems)
                {
                    // if customer has MSP coverage
                    if (customer.MSP != "")
                    {
                        // display coverage of the service
                        labelBookingSummary.Text += $"\n{s} MSP Coverage: {s.MSPCoverage * 100}% ";
                        // add to bookingprice with discount
                        bookingPrice += (s.ServicePrice * (1 - s.MSPCoverage));
                    }
                    else // if no MSP
                    {
                        bookingPrice += s.ServicePrice;// just add to booking price
                        labelBookingSummary.Text += $"\n{s} Price w/o MSP: {s.ServicePrice:C2} ";

                    }
                }
                // display total price of the booking
                labelPriceAmount.Text = $"{bookingPrice:C2}";
            }
        }

        /// <summary>
        /// Method to create a booking for the customer
        /// </summary>
        /// <param name="customerID"> id of the customer creating a booking</param>
        private void CreateBooking(int customerID)
        {
            // if some controls were not selected- error
            if (dataGridViewPractitioners.SelectedRows.Count != 1 || listBoxServices.SelectedIndex == -1 || listBoxTime.SelectedIndex == -1)
            {
                MessageBox.Show("Booking information is missing or is invalid!");
                return;
            }
            // create new Booking object
            Booking newBooking = new Booking
            {
                CustomerID = customerID,
                PractitionerID = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value),
                Date = monthCalendarBooking.SelectionRange.Start,
                Time = (TimeSpan?)listBoxTime.SelectedItem,
                BookingPrice = decimal.Parse(Regex.Replace(labelPriceAmount.Text, @"[^\d.]", "")),
                BookingStatus = BookingStatus.NOT_PAID,
                PractitionerComment = ""
            };
            // add all selected services to the booking
            foreach (Service s in listBoxServices.SelectedItems)
            {
                newBooking.Services.Add(s);
            }

            // validate the new booking - error if not valid
            if (newBooking.InfoIsInvalid())
            {
                MessageBox.Show("Booking information is invalid!");
                return;
            }

            // try to add Booking
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // attach services to context to prevent creating new rows in the Services table!
                foreach (Service s in newBooking.Services)
                {
                    context.Services.Attach(s);
                }
                // try to add
                if (context.Bookings.Add(newBooking) == null)
                {
                    MessageBox.Show("Cannot add booking to database"); // error if didn't work
                    return;
                }
                context.SaveChanges(); // save changes
            }

            // clear calendar before quitting
            monthCalendarBooking.SelectionStart = DateTime.Now;

            // if add was successful- set result to OK and close form
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Method to reset Booking Information
        /// </summary>
        private void ResetBookingInformation()
        {
            // set both labels to empty
            labelBookingSummary.Text = "";
            labelPriceAmount.Text = "";

        }











    }
}

using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;
using MedicalCentreValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreUpdatePatient : Form
    {
        public MedicalCentreUpdatePatient(int customerID)
        {
            // title
            Text = "Medical Centre: Update Patient";
            InitializeComponent();
            // prepopulate data into controls
            PrePopulateFields(customerID);
            // on button click update patient
            buttonUpdatePatient.Click += (s, e) => UpdatePatient(customerID);
        }

        /// <summary>
        /// Method to prepopulate controls based on customer id
        /// </summary>
        /// <param name="customerID"> customer id </param>
        private void PrePopulateFields(int customerID)
        {
            // set up province combobox
            PopulateProvinceComboBox();
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // find customer in db
                var customer = context.Customers.Find(customerID);
                // find user in db
                var user = context.Users.Find(customer.UserID);

                // populate controls
                textBoxFirstName.Text = user.FirstName;
                textBoxLastName.Text = user.LastName;
                dateTimePickerBirthDate.Value = DateTime.ParseExact(user.Birthdate, "yyyy-mm-dd", CultureInfo.InvariantCulture);
                textBoxAddress.Text = user.Address;
                textBoxCity.Text = user.City;
                comboBoxProvince.SelectedIndex = comboBoxProvince.FindStringExact(user.Province);
                textBoxEmail.Text = user.Email;
                textBoxPhoneNumber.Text = user.PhoneNumber;
                textBoxMSP.Text = customer.MSP;
            }
        }

        /// <summary>
        /// Helper method to prepopulate all provinces to the combobox
        /// </summary>
        private void PopulateProvinceComboBox()
        {
            // make sure user cannot edit provinces
            comboBoxProvince.DropDownStyle = ComboBoxStyle.DropDownList;
            // add acceptable range of values
            comboBoxProvince.Items.AddRange(new string[] { "AB", "BC", "SK", "MB", "NL", "PE", "NS", "NB", "QB", "ON" });
        }

        /// <summary>
        /// Method to update customer's information
        /// </summary>
        /// <param name="customerID"> id of the customer to update</param>
        private void UpdatePatient(int customerID)
        {
            // get all fields from controls
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string birthdate = dateTimePickerBirthDate.Value.ToShortDateString();
            string address = textBoxAddress.Text;
            string city = textBoxCity.Text;
            string province = comboBoxProvince.GetItemText(comboBoxProvince.SelectedItem);
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
            string msp = textBoxMSP.Text;

            // find customer
            var customerToUpdate = Controller<MedicalCentreManagementEntities, Customer>.FindEntity(customerID);
            string oldMSP = customerToUpdate.MSP; // save MSP from DB

            // find user
            var userToUpdate = Controller<MedicalCentreManagementEntities, User>.FindEntity(customerToUpdate.UserID);

            // update user's fields
            userToUpdate.FirstName = firstName;
            userToUpdate.LastName = lastName;
            userToUpdate.Birthdate = birthdate;
            userToUpdate.Address = address;
            userToUpdate.City = city;
            userToUpdate.Province = province;
            userToUpdate.PhoneNumber = phoneNumber;
            userToUpdate.Email = email;

            // validate newly created user
            if (userToUpdate.InfoIsInvalid())
            {
                MessageBox.Show("Newly Inputted information is not valid!");
                return;
            }

            // try updating user to DB
            if (Controller<MedicalCentreManagementEntities, User>.UpdateEntity(userToUpdate) == false)
            {
                MessageBox.Show("Cannot update Customer to database");
                return;
            }
            //set customer's MSP
            customerToUpdate.MSP = msp;

            // if MSP was changed- run check!
            if (oldMSP != msp)
            {
                if (!customerToUpdate.IsValidCustomer())
                {
                    MessageBox.Show("MSP must be unique or blank!");
                    return;
                }
            }

            // try to update the customer
            if (Controller<MedicalCentreManagementEntities, Customer>.UpdateEntity(customerToUpdate) == false)
            {
                MessageBox.Show("Cannot update Customer to database");
                return;
            }

            // after successful update:
            // if Customer lost their MSP - adjust price for unpaid booking in the future!
            if (msp != oldMSP && msp == "")
            {
                using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
                {
                    // get list of unpaid bookings for the customer
                    var listOfUnpaidBookings = context.Bookings.Where(b => (b.CustomerID == customerID && b.BookingStatus == "Not Paid")).ToList();

                    // for each check if past or present
                    foreach (Booking booking in listOfUnpaidBookings)
                    {
                        DateTime bookingDate = DateTime.ParseExact(booking.Date + " " + booking.Time, "yyyy-MM-dd HH:mm",
                                         null);
                        // if in the future (greater than today)
                        if (DateTime.Now < bookingDate)
                        {
                            // recalculate new price
                            // by adding service prices
                            decimal newPrice = 0.0m;
                            foreach (Service s in booking.Services)
                            {
                                newPrice += s.ServicePrice;
                            }
                            booking.BookingPrice = newPrice;// set new price
                        }
                    }
                    // save changes
                    context.SaveChanges();
                }
            }
            // if everything is successful- set result to OK and close form
            DialogResult = DialogResult.OK;
            Close();
        }
    }

}

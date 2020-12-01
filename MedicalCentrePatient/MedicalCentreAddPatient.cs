using MedicalCentreCodeFirstFromDB;
using MedicalCentreValidation;
using System;
using System.Windows.Forms;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreAddPatient : Form
    {
        public MedicalCentreAddPatient()
        {
            // set title
            Text = "Medical Centre:Register New Patient";
            InitializeComponent();
            // populate the provinces
            PopulateProvinceComboBox();
            // add event to button
            buttonAddNewPatient.Click +=AddNewPatient;
        }

        /// <summary>
        /// Method to add a range of accepted province values to a combobox
        /// </summary>
        private void PopulateProvinceComboBox()
        {
            // set style to dropdown- so user cannot edit
            comboBoxProvince.DropDownStyle = ComboBoxStyle.DropDownList;
            // add items
            comboBoxProvince.Items.AddRange( new string[] { "AB", "BC", "SK","MB", "NL", "PE", "NS", "NB","QB","ON" });
        }

        /// <summary>
        /// Adding a new patient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewPatient(object sender, EventArgs e)
        {
            // get all values from input controls
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string birthdate = dateTimePickerBirthDate.Value.ToShortDateString();
            string address = textBoxAddress.Text;
            string city = textBoxCity.Text;
            string province = comboBoxProvince.GetItemText(comboBoxProvince.SelectedItem);
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
            string msp = textBoxMSP.Text;

            // build a new user object
            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Address = address,
                City = city,
                Province = province,
                PhoneNumber = phoneNumber,
                Email = email,
            };
            
            // validate user information
            if (newUser.InfoIsInvalid())
            {
                // error if invalid
                MessageBox.Show("Patient information need to filled!");
                return;
            }
            // using a unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // add to Users table and save changes
                User addedUser = context.Users.Add(newUser);
                context.SaveChanges();

                // make sure it was added
                if (addedUser == null)
                {
                    MessageBox.Show("User was not added into a database!");
                    return;
                }
                // create a new Customer
                Customer newCustomer = new Customer
                {
                    User = addedUser,
                    UserID = addedUser.UserID,
                    MSP = msp
                };

                // validate Customer information
                if (newCustomer.IsValidCustomer()){
                    MessageBox.Show("MSP must be unique or blank!");
                    return;
                }
                // add a new customer to DB
                context.Customers.Add(newCustomer);
                context.SaveChanges();// save changes

                // make sure it was added- error if not
                if (newCustomer == null)
                {
                    MessageBox.Show("Customer was not added into a database!");
                    return;
                }
            }
            // If successful- set result to OK and close form
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}

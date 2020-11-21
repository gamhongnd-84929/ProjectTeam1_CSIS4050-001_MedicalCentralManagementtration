using MedicalCentreCodeFirstFromDB;
using System;
using System.Windows.Forms;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreAddPatient : Form
    {
        public MedicalCentreAddPatient()
        {
            this.Text = "Medical Centre:Register New Patient";
            InitializeComponent();
            PopulateProvinceComboBox();
            buttonAddNewPatient.Click +=AddNewPatient;
        }

        private void PopulateProvinceComboBox()
        {
            comboBoxProvince.Items.AddRange( new string[] { "AB", "BC", "SK","MB", "NL", "PE", "NS", "NB","QB","ON" });
        }

        private void AddNewPatient(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string birthdate = dateTimePickerBirthDate.Value.ToShortDateString();
            string address = textBoxAddress.Text;
            string city = textBoxCity.Text;
            string province = comboBoxProvince.GetItemText(comboBoxProvince.SelectedItem);
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
            string msp = textBoxMSP.Text;

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

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                User addedUser = context.Users.Add(newUser);
                context.SaveChanges();

                Customer newCustomer = new Customer
                {
                    User = addedUser,
                    UserID = addedUser.UserID,
                };
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
 
            this.DialogResult = DialogResult.OK;
            Close();

        }
    }
}

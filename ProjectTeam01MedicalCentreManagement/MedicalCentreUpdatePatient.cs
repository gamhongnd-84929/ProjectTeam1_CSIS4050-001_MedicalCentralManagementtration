using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;
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
        public MedicalCentreUpdatePatient(int patientID)
        {
            this.Text = "Medical Centre: Update Patient";
            InitializeComponent();
            PrePopulateFields(patientID);
            buttonUpdatePatient.Click += (s, e) => UpdatePatient(patientID);
        }
        private void PopulateProvinceComboBox()
        {
            comboBoxProvince.Items.AddRange(new string[] { "AB", "BC", "SK", "MB", "NL", "PE", "NS", "NB", "QB", "ON" });
        }
        private void PrePopulateFields(int patientID)
        {
            PopulateProvinceComboBox();
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var customer = context.Customers.Find(patientID);
                var user = context.Users.Find(customer.UserID);
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

        private void UpdatePatient(int patientID)
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

            var customerToUpdate = Controller<MedicalCentreManagementEntities, Customer>.FindEntity(patientID);
            var userToUpdate = Controller<MedicalCentreManagementEntities, User>.FindEntity(customerToUpdate.UserID);
            userToUpdate.FirstName = firstName;
            userToUpdate.LastName = lastName;
            userToUpdate.Birthdate = birthdate;
            userToUpdate.Address = address;
            userToUpdate.City = city;
            userToUpdate.Province = province;
            userToUpdate.PhoneNumber = phoneNumber;
            userToUpdate.Email = email;

            customerToUpdate.MSP = msp;

            if (Controller<MedicalCentreManagementEntities, User>.UpdateEntity(userToUpdate) == false)
            {
                MessageBox.Show("Cannot update USer to database");
                return;
            }
            if (Controller<MedicalCentreManagementEntities, Customer>.UpdateEntity(customerToUpdate) == false)
            {
                MessageBox.Show("Cannot update Customer to database");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }

}

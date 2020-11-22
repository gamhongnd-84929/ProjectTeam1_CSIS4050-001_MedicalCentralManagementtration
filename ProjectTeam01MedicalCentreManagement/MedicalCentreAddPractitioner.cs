using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalCentreCodeFirstFromDB;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreAddPractitioner : Form
    {
        public MedicalCentreAddPractitioner()
        {
            this.Text = "Medical Centre: Register New Practitioner";
            InitializeComponent();
            PopulateProvinceComboBox();
            PopulatePractitionerTypeComboBox();
            buttonRegisterNewPractitioner.Click += AddNewPractitioner;
        }

        /// <summary>
        /// Gets practitioner type from context and populate the practitioner type combo box
        /// </summary>
        private void PopulatePractitionerTypeComboBox()
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                ArrayList practitionerTitles = new ArrayList();
                foreach (Practitioner_Types practitionerType in context.Practitioner_Types)
                {
                    practitionerTitles.Add(practitionerType.Title);
                }
                comboBoxPractitionerType.Items.AddRange(practitionerTitles.ToArray());                
            }
        }

        private void AddNewPractitioner(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string birthdate = dateTimePickerBirthDate.Value.ToShortDateString();
            string address = textBoxStreetAddress.Text;
            string city = textBoxCity.Text;
            string province = comboBoxProvince.GetItemText(comboBoxProvince.SelectedItem);
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
            string practitionalType = comboBoxPractitionerType.GetItemText(comboBoxPractitionerType.SelectedItem);

            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Address = address,
                City = city,
                Province = province,
                PhoneNumber = phoneNumber,
                Email = email
            };

            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                User addedUser = context.Users.Add(newUser);
                context.SaveChanges();

                Practitioner newPractitioner = new Practitioner
                {
                    //User = addedUser,
                };
            }
        }

        /// <summary>
        /// Populate province combo box
        /// </summary>
        private void PopulateProvinceComboBox()
        {
            comboBoxProvince.Items.AddRange(new string[] { "AB", "BC", "SK", "MB", "NL", "PE", "NS", "NB", "QB", "ON" });
        }
    }
}

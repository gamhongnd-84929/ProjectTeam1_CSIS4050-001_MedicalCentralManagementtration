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
using System.Collections;
using System.Globalization;
using MedicalCentreValidation;
using MedicalCentreUtilities;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreUpdatePractitioner : Form
    {
        public MedicalCentreUpdatePractitioner(int practitionerID)
        {
            this.Text = "Medical Centre: Update Practitioner";
            InitializeComponent();
            PrePopulateFields(practitionerID);
            buttonUpdatePractitioner.Click += (s, e) => UpdatePractitioner(practitionerID);
        }

        /// <summary>
        /// update practitioner information
        /// </summary>
        /// <param name="practitionerID"></param>
        private void UpdatePractitioner(int practitionerID)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
           DateTime birthdate = dateTimePickerBirthDate.Value;
            string address = textBoxStreetAddress.Text;
            string city = textBoxCity.Text;
            string province = comboBoxProvince.GetItemText(comboBoxProvince.SelectedItem);
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
            string practitionalType = comboBoxPractitionerType.GetItemText(comboBoxPractitionerType.SelectedItem);



            // check practitionalType is selected
            if (practitionalType == "")
            {
                MessageBox.Show("Please select a Pracitioner Type");
                return;
            }

            int typeId = (comboBoxPractitionerType.SelectedItem as Practitioner_Types).TypeID;

           var practitionerToUpdate = Controller<MedicalCentreManagementEntities, Practitioner>.FindEntity(practitionerID);
            var userToUpdate = Controller<MedicalCentreManagementEntities, User>.FindEntity(practitionerToUpdate.UserID);
            userToUpdate.FirstName = firstName;
            userToUpdate.LastName = lastName;
            userToUpdate.Birthdate = birthdate;
            userToUpdate.Address = address;
            userToUpdate.City = city;
            userToUpdate.Province = province;
            userToUpdate.PhoneNumber = phoneNumber;
            userToUpdate.Email = email;

            // validate user
            if (userToUpdate.InfoIsInvalid())
            {
                MessageBox.Show("Please provide practitioner's information");
                return;
            }

            // validate practitoner
            if (practitionerToUpdate.IsValidPractitioner())
            {
                MessageBox.Show("Practitioner must be picked from user");
                return;
            }

            practitionerToUpdate.TypeID = typeId;

            if(Controller<MedicalCentreManagementEntities, User>.UpdateEntity(userToUpdate) == false)
            {
                MessageBox.Show("Cannot update User to database");
                return;
            }
            if(Controller<MedicalCentreManagementEntities, Practitioner>.UpdateEntity(practitionerToUpdate) == false)
            {
                MessageBox.Show("Cannot update Practitioner to database");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }


        /// <summary>
        /// pre-populating practioner's information
        /// </summary>
        /// <param name="practitionerID"></param>
        private void PrePopulateFields(int practitionerID)
        {
            BaseFormMethods.PopulateProvinceComboBox(comboBoxProvince);
            PopulatePractitionerTypeComboBox();
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var practitioner = context.Practitioners.Find(practitionerID);
                var user = context.Users.Find(practitioner.UserID);
                textBoxFirstName.Text = user.FirstName;
                textBoxLastName.Text = user.LastName;
                dateTimePickerBirthDate.Value = (DateTime)user.Birthdate;
                textBoxStreetAddress.Text = user.Address;
                textBoxCity.Text = user.City;
                comboBoxProvince.SelectedIndex = comboBoxProvince.FindStringExact(user.Province);
                textBoxEmail.Text = user.Email;
                textBoxPhoneNumber.Text = user.PhoneNumber;
                comboBoxPractitionerType.SelectedIndex = comboBoxPractitionerType.FindStringExact(practitioner.Practitioner_Types.Title);
            }
        }

        /// <summary>
        /// Gets practitioner type from context and populate the practitioner type combo box
        /// </summary>
        private void PopulatePractitionerTypeComboBox()
        {
            comboBoxPractitionerType.DropDownStyle = ComboBoxStyle.DropDownList;

          comboBoxPractitionerType.DataSource = Controller<MedicalCentreManagementEntities, Practitioner_Types>.GetEntities();

        }

      
    }
}

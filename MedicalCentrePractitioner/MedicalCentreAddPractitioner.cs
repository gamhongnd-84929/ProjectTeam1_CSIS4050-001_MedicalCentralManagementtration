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
using System.Data.Entity;
using MedicalCentreValidation;
using EFControllerUtilities;

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
            comboBoxPractitionerType.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxPractitionerType.DataSource = Controller<MedicalCentreManagementEntities, Practitioner_Types>.GetEntities();

        }

        /// <summary>
        /// creates new user and practitioner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            int typeId = (comboBoxPractitionerType.SelectedItem as Practitioner_Types).TypeID;
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

            // validate user
            if (newUser.InfoIsInvalid())
            {
                MessageBox.Show("Please provide First Name and Last Name");
                return;
            }

            // check practitionalType is selected
            if (practitionalType == "")
            {
                MessageBox.Show("Please select a Pracitioner Type");
                return;
            }


            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                User addedUser = context.Users.Add(newUser);
                context.SaveChanges();
                // get selected practitioner type

                Practitioner newPractitioner = new Practitioner
                {

                    UserID = addedUser.UserID,
                    TypeID = typeId,
                
                };

                context.Practitioners.Add(newPractitioner);
                context.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            Close();
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

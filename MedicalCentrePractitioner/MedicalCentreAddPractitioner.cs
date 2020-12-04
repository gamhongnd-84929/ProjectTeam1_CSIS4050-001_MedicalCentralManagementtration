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
using MedicalCentreUtilities;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreAddPractitioner : Form
    {
        public MedicalCentreAddPractitioner()
        {
            this.Text = "Medical Centre: Register New Practitioner";
            InitializeComponent();
            BaseFormMethods.PopulateProvinceComboBox(comboBoxProvince);
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
            DateTime birthdate = dateTimePickerBirthDate.Value;
            string address = textBoxStreetAddress.Text;
            string city = textBoxCity.Text;
            string province = comboBoxProvince.GetItemText(comboBoxProvince.SelectedItem);
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
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
                MessageBox.Show("Please fill practitioner's information");
                return;
            }




            // check practitionalType is selected
            if (comboBoxPractitionerType.SelectedIndex == -1)
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

                // validate practitioner
                if (!newPractitioner.IsValidPractitioner())
                {
                    MessageBox.Show("Practitioner must picked from User");
                    return;
                }

                context.Practitioners.Add(newPractitioner);
                context.SaveChanges();
            }
            BaseFormMethods.ClearAllControls(this);
            this.DialogResult = DialogResult.OK;
            Close();
        }


    }
}

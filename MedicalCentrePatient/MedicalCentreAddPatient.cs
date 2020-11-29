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
            this.Text = "Medical Centre:Register New Patient";
            InitializeComponent();
            PopulateProvinceComboBox();

            buttonAddNewPatient.Click +=AddNewPatient;
        }

 
        private static void ClearControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox txtbox)
                {
                    txtbox.Text = string.Empty;
                }

                else if (control is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                }
                else if (control is ComboBox combobox)
                {
                    combobox.SelectedIndex = -1;
                }
            }
        }
        private void PopulateProvinceComboBox()
        {
            
            comboBoxProvince.Items.AddRange( new string[] { "AB", "BC", "SK","MB", "NL", "PE", "NS", "NB","QB","ON" });
            comboBoxProvince.DropDownStyle = ComboBoxStyle.DropDownList;
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

            if (!newUser.InfoIsInvalid())
            {
                using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
                {
                    User addedUser = context.Users.Add(newUser);
                    context.SaveChanges();

                    Customer newCustomer = new Customer
                    {
                        User = addedUser,
                        UserID = addedUser.UserID,
                        MSP = msp
                    };
                    if (newCustomer.IsValidCustomer())
                    {

                        context.Customers.Add(newCustomer);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("MSP must be Unique or blank!");
                        return;
                    }
                }
                ClearControls(this);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Fields are not Filled! Make sure First Name, Last Name, Phone Number and Email are inputted!");
            }
 
         

        }
    }
}

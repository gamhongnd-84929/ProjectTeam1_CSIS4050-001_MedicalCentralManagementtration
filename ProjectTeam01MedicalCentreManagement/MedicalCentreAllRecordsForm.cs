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

using ProjectTeam01MedicalCentreManagement;

namespace MedicalCentreMainMenuFormApp
{
    public partial class MedicalCentreAllRecordsForm : Form
    {
        public MedicalCentreAllRecordsForm()
        {

            InitializeComponent();
            // title
            Text = "Medical Centre: All Records";
            // initial configuration onload
            Load += (s, e) => MedicalCentreAllRecordsForm_Load();
            // create child forms
            MedicalCentreAddPatient addPatient = new MedicalCentreAddPatient();
            MedicalCentreAddPractitioner addPractitioner = new MedicalCentreAddPractitioner();

            // add events to buttons
            buttonAddPatient.Click += (s, e) => AddNewUserForm<Customer>(dataGridViewPatients, addPatient);
            buttonAddPractitioner.Click += (s, e) => AddNewUserForm<Practitioner>(dataGridViewPractitioners, addPractitioner);
            buttonPatientOptions.Click += (s, e) => AddingPatientOptionsForm();
            buttonPractitionerOptions.Click += (s, e) => AddingPractitionerOptionsForm();
        }

        /// <summary>
        /// Method to load practitioner options into a child form
        /// </summary>
        private void AddingPractitionerOptionsForm()
        {
            // check that one practitioner is checked- if not error message
            if (dataGridViewPractitioners.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select a Practitioner to View their Options");
                return;
            }
            // get the practitioner id 
            int practitionerIdToView = Convert.ToInt32(dataGridViewPractitioners.SelectedRows[0].Cells[0].Value);
            // load and show practitioners options form passing the id
            MedicalCentrePractitionerOptionsMainForm practitionerOptionsMainForm = new MedicalCentrePractitionerOptionsMainForm(practitionerIdToView);
            practitionerOptionsMainForm.ShowDialog();

            // reload the datagridview- once child is closed
            ReloadPractitionersRecordsView(dataGridViewPractitioners);
            dataGridViewPractitioners.Refresh();
            // hide the child form
            practitionerOptionsMainForm.Hide();

        }

        /// <summary>
        /// Method to load patient options into a child form
        /// </summary>
        private void AddingPatientOptionsForm()
        {
            // check that one patient is selected- error if not
            if (dataGridViewPatients.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select a Patient to View their Options");
                return;
            }
            // get the id of the patient selected
            int patientIdToView = Convert.ToInt32(dataGridViewPatients.SelectedRows[0].Cells[0].Value);
            // create a patient options child form and display    
            MedicalCentrePatientOptionsMainForm patientOptionsMainForm = new MedicalCentrePatientOptionsMainForm(patientIdToView);
            patientOptionsMainForm.ShowDialog();

            // reload the datagridview upon closing the child form
            ReloadPatientsRecordsView(dataGridViewPatients);
            dataGridViewPatients.Refresh();

            // hide the child form
            patientOptionsMainForm.Hide();

        }
        /// <summary>
        /// Method to display AddNewUser form
        /// Generic to be able to add many types of users
        /// </summary>
        /// <typeparam name="T"> generic </typeparam>
        /// <param name="dataGridView"> datagrid to reload upon closing child form</param>
        /// <param name="form"> form to load</param>
        private void AddNewUserForm<T>(DataGridView dataGridView, Form form) where T : class
        {
            // show the form 
            var result = form.ShowDialog();

            // if okay or cancel was clicked on the child
            if (result == DialogResult.OK || result == DialogResult.Cancel)
            {
                // reload the datagridview depending on the type of the generic
                if (typeof(T) == typeof(Customer))
                {
                    ReloadPatientsRecordsView(dataGridView);
                }
                if (typeof(T) == typeof(Practitioner))
                {
                    ReloadPractitionersRecordsView(dataGridView);
                }
                dataGridView.Refresh(); // refresh the datagridview
            }
            // hide the child form
            form.Hide();
        }

        /// <summary>
        /// Method to set up initial configuration of the form
        /// </summary>
        private void MedicalCentreAllRecordsForm_Load()
        {
            // initialize both datagridviews
            InitializePatientsRecordsView(dataGridViewPatients);
            InitializePractitionersRecordsView(dataGridViewPractitioners);
        }

        /// <summary>
        /// Set up the practitionersRecordsView columns and populate data into the view
        /// </summary>
        /// <param name="datagridview"> datagridview to be populated</param>
        private void InitializePractitionersRecordsView(DataGridView datagridview)
        {
            datagridview.Rows.Clear();
            // set number of columns
            datagridview.ColumnCount = 7;
            // set the column header names
            datagridview.Columns[0].Name = "Practitioner ID";
            datagridview.Columns[1].Name = "Type";
            datagridview.Columns[2].Name = "First Name";
            datagridview.Columns[3].Name = "Last Name";
            datagridview.Columns[4].Name = "City";
            datagridview.Columns[5].Name = "Province";
            datagridview.Columns[6].Name = "Email";
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // loop through all practitioners
                foreach (Practitioner practitioner in context.Practitioners)
                {
                    // get the needed information
                    string[] rowAdd = { practitioner.PractitionerID.ToString(), practitioner.Practitioner_Types.Title, practitioner.User.FirstName, practitioner.User.LastName, practitioner.User.City, practitioner.User.Province, practitioner.User.Email };
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
        /// Method to reload the data of the practitioners
        /// </summary>
        /// <param name="datagridview"> datagridview to be reloaded</param>
        private void ReloadPractitionersRecordsView(DataGridView datagridview)
        {
            // clear current data
            datagridview.Rows.Clear();
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // loop through all practitioners
                foreach (Practitioner practitioner in context.Practitioners)
                {
                    // get the needed information
                    string[] rowAdd = { practitioner.PractitionerID.ToString(), practitioner.Practitioner_Types.Title, practitioner.User.FirstName, practitioner.User.LastName, practitioner.User.City, practitioner.User.Province, practitioner.User.Email };
                    // add to display
                    datagridview.Rows.Add(rowAdd);
                }
            }
        }

        /// <summary>
        /// Set up patients records display
        /// </summary>
        /// <param name="datagridview">datagridview to be populated with patient records</param>
        private static void InitializePatientsRecordsView(DataGridView datagridview)
        {
            datagridview.Rows.Clear();
            // set number of columns
            datagridview.ColumnCount = 8;
            // Set the column header names.
            datagridview.Columns[0].Name = "Customer ID";
            datagridview.Columns[1].Name = "First Name";
            datagridview.Columns[2].Name = "Last Name";
            datagridview.Columns[3].Name = "Address";
            datagridview.Columns[4].Name = "City";
            datagridview.Columns[5].Name = "Province";
            datagridview.Columns[6].Name = "Email";
            datagridview.Columns[7].Name = "Phone Number";
            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // loop through all customers
                foreach (Customer customer in context.Customers)
                {
                    // do not add customer with id=6 (reserved for timeoff feature)
                    if (customer.CustomerID == 6) continue;
                    // get the needed information
                    string[] rowAdd = { customer.CustomerID.ToString(), customer.User.FirstName, customer.User.LastName, customer.User.Address, customer.User.City, customer.User.Province, customer.User.Email, customer.User.PhoneNumber };
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
        /// Method to reload customers data 
        /// </summary>
        /// <param name="datagridview"> datagridview to be reloaded </param>
        private void ReloadPatientsRecordsView(DataGridView datagridview)
        {
            datagridview.Rows.Clear(); // clear current rows
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                // loop through all customers
                foreach (Customer customer in context.Customers)
                {
                    // do not add customer with id=6 (reserved for timeoff feature)
                    if (customer.CustomerID == 6) continue;
                    // get the needed information
                    string[] rowAdd = { customer.CustomerID.ToString(), customer.User.FirstName, customer.User.LastName, customer.User.Address, customer.User.City, customer.User.Province, customer.User.Email, customer.User.PhoneNumber };
                    // add to display
                    datagridview.Rows.Add(rowAdd);
                }

            }
        }
    }


}

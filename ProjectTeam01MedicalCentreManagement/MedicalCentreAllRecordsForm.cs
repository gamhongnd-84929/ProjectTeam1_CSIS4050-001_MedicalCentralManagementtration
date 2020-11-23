using System;
using System.Windows.Forms;
using MedicalCentreCodeFirstFromDB;
using DataTableAccessLayer;
using ProjectTeam01MedicalCentreManagement;

namespace MedicalCentreMainMenuFormApp
{
    public partial class MedicalCentreAllRecordsForm : Form
    {
        // field to keep the access layer field
        
        public MedicalCentreAllRecordsForm()
        {
            this.Text = "Medical Centre All Records";
            InitializeComponent();
            this.Load += (s, e) => MedicalCentreAllRecordsForm_Load();
            // create child forms
            MedicalCentreAddPatient addPatient = new MedicalCentreAddPatient();

            MedicalCentreAddPractitioner addPractitioner = new MedicalCentreAddPractitioner();
            // add events to buttons
            buttonAddPatient.Click += (s, e) => AddNewUserForm<Customer>(dataGridViewPatients, addPatient);
            buttonAddPractitioner.Click += (s, e) => AddNewUserForm<Practitioner>(dataGridViewPractitioners, addPractitioner);
            buttonPatientOptions.Click += (s, e) => AddingPatientOptionsForm();
        }

        private void AddingPatientOptionsForm()
        {
            if (dataGridViewPatients.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select a Patient to View their Options");
            }
            else
            {
                int patientIdToView = Convert.ToInt32(dataGridViewPatients.SelectedRows[0].Cells[0].Value);
                MedicalCentrePatientOptionsMainForm patientOptionsMainForm = new MedicalCentrePatientOptionsMainForm(patientIdToView);
                var result = patientOptionsMainForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // reload the datagridview
                    InitializePatientsRecordsView(dataGridViewPatients);
                    dataGridViewPatients.Refresh();

                }
                // hide the child form
                patientOptionsMainForm.Hide();
            }
        }

        private void AddNewUserForm<T>(DataGridView dataGridView, Form form) where T : class
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Cancel)
            {
                // reload the datagridview
               if (typeof(T) == typeof( Customer))
                {
                    InitializePatientsRecordsView(dataGridView);
                }
                dataGridView.Refresh();

            }

            // hide the child form
            form.Hide();
        }

        private void MedicalCentreAllRecordsForm_Load()
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.SeedDatabase();
            }
            // common setup for datagridview controls

            InitializePatientsRecordsView(dataGridViewPatients);
            //InitializeDataGridView<Customer>(dataGridViewPatients, "Bookings", "Payments", "User");

        }

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
                // loop through all courses
                foreach (Customer customer in context.Customers)
                {

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
    }


}

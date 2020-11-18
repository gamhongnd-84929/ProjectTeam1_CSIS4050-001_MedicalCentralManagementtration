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
using ProjectTeam01MedicalCentreManagement;

namespace MedicalCentreMainMenuFormApp
{
    public partial class MedicalCentreAllRecordsForm : Form
    {
        public MedicalCentreAllRecordsForm()
        {
            this.Text = "Medical Centre All Records";
            InitializeComponent();
            //this.Load += (s, e) => MedicalCentreAllRecordsForm_Load();
            // create child forms
            MedicalCentreAddPatient addPatient = new MedicalCentreAddPatient();
            MedicalCentreAddPractitioner addPractitioner = new MedicalCentreAddPractitioner();
            // add events to buttons
            buttonAddPatient.Click += (s, e) => AddNewUserForm<Customer>(dataGridViewPatients, addPatient);
            buttonAddPractitioner.Click += (s, e) => AddNewUserForm<Practitioner>(dataGridViewPractitioners, addPractitioner);

        }

        private void AddNewUserForm<T>(DataGridView dataGridView, Form form) where T:class
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // reload the datagridview
                dataGridView.DataSource = Controller<MedicalCentreManagementEntities, T>.SetBindingList();
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

            InitializeDataGridView<Practitioner>(dataGridViewPractitioners);
            InitializeDataGridView<Customer>(dataGridViewPatients);
            
        }

        private void InitializeDataGridView<T>(DataGridView gridView, params string[] columnsToHide) where T : class
        {
            // Allow users to add/delete rows, and fill out columns to the entire width of the control

            gridView.AllowUserToAddRows = false;

            gridView.AllowUserToDeleteRows = true;
            gridView.ReadOnly = true;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // set the handler used to delete an item. Note use of generics.

           // gridView.UserDeletingRow += (s, e) => DeletingRow<T>(s as DataGridView, e);

           
            gridView.DataSource = Controller<MedicalCentreManagementEntities, T>.SetBindingList();


            foreach (string column in columnsToHide)
                gridView.Columns[column].Visible = false;
        }
    }

  
}

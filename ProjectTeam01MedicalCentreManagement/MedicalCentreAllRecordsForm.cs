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

namespace MedicalCentreMainMenuFormApp
{
    public partial class MedicalCentreAllRecordsForm : Form
    {
        public MedicalCentreAllRecordsForm()
        {
            this.Text = " Medical Centre All Records";
            InitializeComponent();
            this.Load += (s, e) => MedicalCentreAllRecordsForm_Load();
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

            // probably not needed, but just in case we have some issues

           
            gridView.DataSource = Controller<MedicalCentreManagementEntities, T>.SetBindingList();


            foreach (string column in columnsToHide)
                gridView.Columns[column].Visible = false;
        }
    }

  
}

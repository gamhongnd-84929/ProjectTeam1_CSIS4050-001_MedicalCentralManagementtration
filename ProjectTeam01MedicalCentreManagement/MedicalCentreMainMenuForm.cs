using MedicalCentreCodeFirstFromDB;
using MedicalCentreMainMenuFormApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreMainMenuForm : Form
    {
        public MedicalCentreMainMenuForm()
        {
            Text = "Medical Centre: Main Menu";
            InitializeComponent();
            Load += (s, e) => MedicalCentreMainForm_Load();

            MedicalCentreAllRecordsForm allRecordsForm = new MedicalCentreAllRecordsForm();
            buttonRecords.Click += (s, e) => AllRecordsForm(allRecordsForm);

            // Administration 
            MedicalCentreAdministrationForm medicalCentreAdministration = new MedicalCentreAdministrationForm();
            buttonAdministration.Click += (s, e) => AdministrationForm(medicalCentreAdministration);
        }
        private void MedicalCentreMainForm_Load()
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.SeedDatabase();
            }

        }
        private void AllRecordsForm(Form form)
        {
            // if okay was clicked on the child
            form.ShowDialog();
            // hide the child form
            form.Hide();
        }

        private void AdministrationForm(Form form)
        {
            // show child form
            form.ShowDialog();
            // hide child form
            form.Hide();
        }
    }
}

using MedicalCentreCodeFirstFromDB;
using MedicalCentreMainMenuFormApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
           
            // title
            Text = "Medical Centre: Main Menu";
            InitializeComponent();
            // onload event
            Load += (s, e) => MedicalCentreMainForm_Load();
            // create client management form and add to button click
            MedicalCentreAllRecordsForm allRecordsForm = new MedicalCentreAllRecordsForm();
            buttonRecords.Click += (s, e) => LoadChildForm(allRecordsForm);

            // Administration form and add to button click
            MedicalCentreAdministrationForm medicalCentreAdministration = new MedicalCentreAdministrationForm();
            buttonAdministration.Click += (s, e) => LoadChildForm(medicalCentreAdministration);
        }
        /// <summary>
        /// On load event of seeding the database
        /// </summary>
        private void MedicalCentreMainForm_Load()
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.SeedDatabase();
            }

        }
        /// <summary>
        /// Method to load any child form 
        /// </summary>
        /// <param name="form"> form to be loaded </param>
        private void LoadChildForm(Form form)
        {
            // if okay was clicked on the child
            form.ShowDialog();
            // hide the child form
            form.Hide();
        }

    }
}

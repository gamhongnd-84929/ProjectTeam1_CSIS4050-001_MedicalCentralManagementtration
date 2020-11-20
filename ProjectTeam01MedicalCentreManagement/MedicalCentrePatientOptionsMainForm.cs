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
    public partial class MedicalCentrePatientOptionsMainForm : Form
    {
        public MedicalCentrePatientOptionsMainForm( int patientID)
        {
            
            this.Text = "Medical Centre: Patient's Options";
            InitializeComponent();

            MedicalCentreUpdatePatient medicalCentreUpdatePatient = new MedicalCentreUpdatePatient(patientID);
            buttonUpdateInformation.Click += (s, e) => UpdateUserForm(medicalCentreUpdatePatient);


        }
        private void UpdateUserForm( Form form) 
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // reload the datagridview
             

            }
            // hide the child form
            form.Hide();
        }
    }
}

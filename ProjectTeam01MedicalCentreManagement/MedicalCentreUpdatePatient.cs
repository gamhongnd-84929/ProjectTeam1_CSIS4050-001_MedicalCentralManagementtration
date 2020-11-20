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
    public partial class MedicalCentreUpdatePatient : Form
    {
        public MedicalCentreUpdatePatient(int patientID)
        {
            this.Text = "Medical Centre: Update Patient";
            InitializeComponent();
        }
    }
}

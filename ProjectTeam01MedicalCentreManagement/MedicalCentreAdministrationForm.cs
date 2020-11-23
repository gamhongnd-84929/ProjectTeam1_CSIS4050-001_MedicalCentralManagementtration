using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTableAccessLayer;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentreAdministrationForm : Form
    {
        // field to keep the access layer field
        private SQLDataTableAccessLayer medicalCentreDB;
        public MedicalCentreAdministrationForm()
        {
            InitializeComponent();

            medicalCentreDB = new SQLDataTableAccessLayer();
            DataSet medicalCenterDataSet = new DataSet() 
            { 
                // must be name for backup purpose
                DataSetName = "MedicalCentreDataSet"
            };

            // set the connectionString from App.config
            string connectingString = medicalCentreDB.GetConnectionString("MedicalCentreManagementConnection");
            medicalCentreDB.OpenConnection(connectingString);
            // Register the event handler for database backup to xml
            buttonBackupDatabase.Click += (s, e) => medicalCentreDB.BackupDataSetToXML(medicalCenterDataSet);
            buttonRestoreDatabase.Click += (s, e) => medicalCentreDB.RestoreDataSetFromBackup(medicalCenterDataSet);

            // Ensure that the connection to the db is closed
            this.FormClosing += (s, e) => medicalCentreDB.CloseConnection();


        }

       
    }
}

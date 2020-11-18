﻿using MedicalCentreMainMenuFormApp;
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
            this.Text = "Medical Centre Main Menu";
            InitializeComponent();
            MedicalCentreAllRecordsForm allRecordsForm = new MedicalCentreAllRecordsForm();
           
            buttonRecords.Click += (s, e) => AllRecordsForm(allRecordsForm);
        }

        private void AllRecordsForm(Form form) 
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            // hide the child form
            form.Hide();
        }
    }
}
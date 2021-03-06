﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalCentreCodeFirstFromDB;

namespace ProjectTeam01MedicalCentreManagement
{
    public partial class MedicalCentrePractitionerOptionsMainForm : Form
    {
        public MedicalCentrePractitionerOptionsMainForm(int practitionerID)
        {
            this.Text = "Medical Centre: Practition's Options";
            InitializeComponent();

            GetGreeting(practitionerID);
            InitializePractitionersBookings(dataGridViewPractitionerBookings, practitionerID);

            MedicalCentreUpdatePractitioner medicalCentreUpdatePractitioner = new MedicalCentreUpdatePractitioner(practitionerID);
            buttonUpdatePractitioner.Click += (s, e) => ChildPatientActionsForm(medicalCentreUpdatePractitioner, practitionerID);

            MedicalCentreBookHoursOff medicalCentreBookHoursOff = new MedicalCentreBookHoursOff(practitionerID);
            buttonBookHoursOff.Click += (s, e) => ChildPatientActionsForm(medicalCentreBookHoursOff, practitionerID);

        }

        /// <summary>
        /// set datagridview properties, columns, and populate rows
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="practitionerID"></param>
        private void InitializePractitionersBookings(DataGridView dataGridView, int practitionerID)
        {
            dataGridView.Rows.Clear();
            // set number of columns
            dataGridView.ColumnCount = 7;
            // set the column header names
            dataGridView.Columns[0].Name = "Customner ID";
            dataGridView.Columns[1].Name = "Customer First Name";
            dataGridView.Columns[2].Name = "Customer Last Name";
            dataGridView.Columns[3].Name = "Booking Time";
            dataGridView.Columns[4].Name = "Booking Date";
            dataGridView.Columns[5].Name = "Practitioner Comment";
            dataGridView.Columns[6].Name = "Booking Status";

            // using unit-of-work context
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                Practitioner practitioner = context.Practitioners.Find(practitionerID);
                // loop through all bookings
                foreach (Booking booking in practitioner.Bookings)
                {
                    // get the needed information
                    string[] rowAdd = {
                        booking.CustomerID.ToString(),
                        context.Users.Find(booking.Customer.UserID).FirstName,
                        context.Users.Find(booking.Customer.UserID).LastName,
                        booking.Time,
                        booking.Date,
                        booking.PractitionerComment,
                        booking.BookingStatus
                    };
                    // add to display
                    dataGridView.Rows.Add(rowAdd);
                }
            }
            // set all properties
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// using passed practitionerID to get Practitioner's name for greeting
        /// </summary>
        /// <param name="practitionerID"></param>
        private void GetGreeting(int practitionerID)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                var practitioner = context.Practitioners.Find(practitionerID);
                var user = context.Users.Find(practitioner.UserID);
                labelPractitionerName.Text = $"Practitioner Name: {user.LastName}, {user.FirstName}";
            }
        }

        /// <summary>
        /// Show, hide child from as well as update the practitioner bookings
        /// </summary>
        /// <param name="form"></param>
        /// <param name="practitionerID"></param>
        private void ChildPatientActionsForm(Form form, int practitionerID)
        {
            // if okay was clicked on the child
            var result = form.ShowDialog();
            if(result == DialogResult.OK)
            {
                InitializePractitionersBookings(dataGridViewPractitionerBookings, practitionerID);
                GetGreeting(practitionerID);
            }
            // hide the child form
            form.Hide();
            this.DialogResult = DialogResult.OK;
        }
    }
}

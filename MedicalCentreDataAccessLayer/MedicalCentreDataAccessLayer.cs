using DataTableAccessLayer;
using MedicalCentreCodeFirstFromDB;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace MedicalCentreDataAccessLayer
{
    public class MedicalCentreDataAccessLayer : SQLDataTableAccessLayer
    {
        // insert practitioner
        public void InsertUser(User user)
        {
            // need to allow id to be inserted, so set identity_insert to be on
            SetIdentityInsert("Users", true);
            string insertCommand = "INSERT INTO Users(UserID, FirstName, Birthdate, LastName, Address, City, Province, PostalCode, PhoneNumber, Email) VALUES" +
                $"('{user.UserID}', '{user.FirstName}', '{user.Birthdate}', '{user.LastName}', '{user.Address}', '{user.City}', '{user.Province}', '{user.PostalCode}', '{user.PhoneNumber}', '{user.Email}')";

            Debug.WriteLine("InsertUser: " + insertCommand);

            // execute using our connection 
            using (SqlCommand sqlCommand = new SqlCommand(insertCommand, sqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failure: " + sqlCommand.CommandText, ex);
                    throw error;
                }
            }


            // now set identity_insert back to off

            SetIdentityInsert("Users", false);
        }

        // insert practitioner
        public void InsertPractitioner(Practitioner practitioner)
        {
            // need to allow id to be inserted, so set identity_insert to be on
            SetIdentityInsert("Practitioners", true);
            string insertCommand = "INSERT INTO Practitioners(PractitionerID, UserID, TypeID) VALUES" +
                $"('{practitioner.PractitionerID}', '{practitioner.UserID}', '{practitioner.TypeID}')";

            Debug.WriteLine("InsertPractitioner: " + insertCommand);

            // execute using our connection 
            using (SqlCommand sqlCommand = new SqlCommand(insertCommand, sqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failure: " + sqlCommand.CommandText, ex);
                    throw error;
                }
            }


            // now set identity_insert back to off

            SetIdentityInsert("Practitioners", false);
        }

        // insert Customer
        // insert practitioner
        public void InsertCustomer(Customer customer)
        {
            // need to allow id to be inserted, so set identity_insert to be on
            SetIdentityInsert("Customers", true);
            string insertCommand = "INSERT INTO Customers(CustomerID, UserID, MSP) VALUES" +
                $"('{customer.CustomerID}', '{customer.UserID}', '{customer.MSP}')";

            Debug.WriteLine("InsertCustomer: " + insertCommand);

            // execute using our connection 
            using (SqlCommand sqlCommand = new SqlCommand(insertCommand, sqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failure: " + sqlCommand.CommandText, ex);
                    throw error;
                }
            }


            // now set identity_insert back to off

            SetIdentityInsert("Customers", false);
        }
    }
}

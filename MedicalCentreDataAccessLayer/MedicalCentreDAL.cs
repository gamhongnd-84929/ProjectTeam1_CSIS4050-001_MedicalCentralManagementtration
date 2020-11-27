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
    public class MedicalCentreDAL : SQLDataTableAccessLayer
    {
        // insert User
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

        // insert Booking
        public void InsertBooking(Booking booking)
        {
            // need to allow id to be inserted, so set identity_insert to be on
            SetIdentityInsert("Bookings", true);
            string insertCommand = "INSERT INTO Bookings(BookingID, CustomerID, PractitionerID, Time, Date, PractitionerComment, BookingPrice, BookingStatus) VALUES" +
                $"('{booking.BookingID}', '{booking.CustomerID}', '{booking.PractitionerID}', '{booking.Time}', '{booking.Date}', '{booking.PractitionerComment}', '{booking.BookingPrice}', '{booking.BookingStatus}')";

            Debug.WriteLine("InsertBooking: " + insertCommand);

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

            SetIdentityInsert("Bookings", false);
        }


        // Delete user
        public void DeleteUser(int id)
        {
            // Get ID of User to delete, then do so.
            string deleteCommand = $"DELETE FROM Users WHERE UserID = '{id}'";

            Debug.WriteLine("DeleteUser: " + deleteCommand);

            using (SqlCommand sqlCommand = new SqlCommand(deleteCommand, sqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That User is on Bookings!", ex);
                    throw error;
                }
            }
        }

        // Delete booking
        public void DeleteBooing(int bookingID)
        {
            // Get ID of User to delete, then do so.
            string deleteCommand = $"DELETE FROM Bookings WHERE BookingID = '{bookingID}'";

            Debug.WriteLine("DeleteBooking: " + deleteCommand);

            using (SqlCommand sqlCommand = new SqlCommand(deleteCommand, sqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That Booing is invalid", ex);
                    throw error;
                }
            }
        }

        // Update User
        public void UpdateUser(int id, string firstName, string birthdate, string lastName, string address, string city, string province, string postalCode, string phoneNumber, string email)
        {
            // Get ID of User to modify and new user's information.
            string updateCommand = $"UPDATE Users SET FirstName = '{firstName}', Birthdate = '{birthdate}', LastName = '{lastName}', Address = '{address}', City = '{city}', Province = '{province}', PostalCode = '{postalCode}', PhoneNumber = '{phoneNumber}', Email = '{email}' WHERE UserID = '{id}'";

            Debug.WriteLine("UpdateUser: " + updateCommand);

            using (SqlCommand sqlCommand = new SqlCommand(updateCommand, sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }

        // Update Booking
        public void UpdateBooking(int id, int customerId, int practitionerId, string time, string date, string practitionerComment, double bookingPrice, string bookingStatus)
        {
            // Get ID of booking to modify and new booking's information.
            string updateCommand = $"UPDATE Booking SET CustomerID = '{customerId}', Birthdate = '{practitionerId}', LastName = '{time}', Address = '{date}', City = '{practitionerComment}', Province = '{bookingPrice}', PostalCode = '{bookingStatus}'  WHERE UserID = '{id}'";

            Debug.WriteLine("UpdateBooking: " + updateCommand);

            using (SqlCommand sqlCommand = new SqlCommand(updateCommand, sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentreCodeFirstFromDB
{
    public static class SeedDatabaseExtensionMethods
    {
        public static void SeedDatabase(this MedicalCentreManagementEntities context)
        {
            // set up database log to write to output window in VS
            context.Database.Log = (s => Debug.Write(s));

            if (context.Database.Exists())
            {
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
                    $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                context.Database.Delete();
                context.Database.Create();
            }
            else
            {
                context.Database.Create();
            }

            //context.Database.Delete();
            //context.Database.Create();

            context.SaveChanges();

            context.Users.Load();
            context.Customers.Load();
            context.Practitioners.Load();
            context.Practitioner_Types.Load();
            context.Services.Load();
            context.Bookings.Load();

            List<Practitioner_Types> types = new List<Practitioner_Types>(){
                new Practitioner_Types {Title = "Dermatologist"},
                new Practitioner_Types{Title = "Neurologist"},
                new Practitioner_Types{Title = "Cardiologist"},
                new Practitioner_Types{Title = "Ophthalmologist"},

            };
            context.Practitioner_Types.AddRange(types);
            context.SaveChanges();

            List<Service> services = new List<Service>
            {
                new Service{ ServiceName= "Skin Tag Removal", ServiceDescription="Removing any skin growth", PractitionerTypeID =1, ServicePrice=100, MSPCoverage = 0.4m},
                new Service{ ServiceName= "Neuro Exam", ServiceDescription="Performing Neuro Exam", PractitionerTypeID =2 ,ServicePrice=500, MSPCoverage =0.40m},
                new Service{ ServiceName= "Skin Exam", ServiceDescription="Examining any Skin Conditions", PractitionerTypeID =1 ,ServicePrice=800,MSPCoverage = 0.6m},
                new Service{ ServiceName= "Cholesterol Exam", ServiceDescription="Test cholesterol in blood", PractitionerTypeID =3, ServicePrice= 300, MSPCoverage=0.8m},
                new Service{ ServiceName= "Eye Exam", ServiceDescription="Test eye vision", PractitionerTypeID = 1, ServicePrice = 200, MSPCoverage = 0.7m}
            };
            context.Services.AddRange(services);
            context.SaveChanges();

            // ID 1-5 : patient, ID 5-10 : Doctor
            List<User> users = new List<User>()
            {
                new User { FirstName= "Jane", LastName = "Doe", Birthdate = "1994-08-20", Address = "100 1st", City="Vancouver",Province="BC",PostalCode="V3V 1G1", Email = "janedoe@email.com", PhoneNumber = "778-898-1111"},
                new User { FirstName= "John", LastName = "Doe", Birthdate = "1980-07-07", Address = "200 2nd", City="Burnaby",Province="BC",PostalCode="V3F 9L1", Email = "johndoe@email.com", PhoneNumber = "778-454-4339"},
                new User { FirstName= "Anna", LastName = "Liu", Birthdate = "1990-01-11", Address = "300 3rd", City="New Westsminters",Province="BC", PostalCode="V3L 0A2", Email = "annaliu@email.com", PhoneNumber = "604-252-3000"},
                new User { FirstName= "Jenny", LastName = "Dang", Birthdate = "1992-11-20", Address = "400 4rd", City="Surey",Province="BC", PostalCode="V2L 1J2", Email = "jennydang@email.com", PhoneNumber = "604-787-1122"},
                new User { FirstName= "Ivan", LastName = "Huynh", Birthdate = "1998-12-30", Address = "500 5rd", City="Vancouver",Province="BC", PostalCode="V5H 1K2", Email = "ivanhuynh@email.com", PhoneNumber = "236-989-3355"},
                new User { FirstName= "Doctor1", LastName = "Billings", Birthdate="1980-12-28", Address = "600 6nd", City="Burnaby",Province="BC",PostalCode="V3F 6L1", Email = "doctor1@email.com", PhoneNumber = "236-989-3245"},
                new User { FirstName= "Doctor2", LastName = "Yamaha", Birthdate="1973-11-20", Address = "700 7nd", City="Burnaby",Province="BC",PostalCode="V3F 5L9", Email = "doctor2@email.com", PhoneNumber = "250-647-8228"},
                new User { FirstName= "Doctor3", LastName = "Fred", Birthdate="1964-12-05", Address = "800 8nd", City="Burnaby",Province="BC",PostalCode="V5M 8F1", Email = "doctor3@email.com", PhoneNumber = "250-678-4112"},
                new User { FirstName= "Doctor4", LastName = "James", Birthdate="1977-08-21", Address = "900 9nd", City="Surey",Province="BC",PostalCode="V2Y 1L2", Email = "doctor4@email.com", PhoneNumber = "778-353-1100"},
                new User { FirstName= "Doctor5", LastName = "Martin", Birthdate="1985-09-10", Address = "101 11st", City="Vancouver",Province="BC",PostalCode="V5K 9Y1", Email = "doctor5@email.com", PhoneNumber = "604-491-2255"},
                new User { FirstName= "TimeOff", LastName = "TimeOff", Birthdate=null, Address = "", City="",Province="",PostalCode="", Email = "", PhoneNumber = ""},
            };

            context.Users.AddRange(users);
            context.SaveChanges();


            List<Customer> customers = new List<Customer>()
            {
                new Customer { UserID =1, MSP = "9876111222"},
                new Customer { UserID =2, MSP = "9876222333"},
                new Customer { UserID =3, MSP = "9876333444"},
                new Customer { UserID =5, MSP = "9876444555"},
                new Customer { UserID =4, MSP = "9876555666"},
                new Customer { UserID =11, MSP = ""}
            };
            List<Practitioner> practitioners = new List<Practitioner>()
            {
                new Practitioner {UserID=6, TypeID = 1},
                new Practitioner {UserID =7, TypeID =2},
                new Practitioner {UserID=10, TypeID =4},
                new Practitioner {UserID =9, TypeID =3},
                new Practitioner {UserID=8, TypeID = 1},
                
            };
            context.Customers.AddRange(customers);
            context.Practitioners.AddRange(practitioners);

            context.SaveChanges();

            List<Booking> bookings = new List<Booking>()
            {
                new Booking {CustomerID =1, PractitionerID = 1, Time= "13:00", Date = "2020-11-30", BookingPrice=250,BookingStatus="Not Paid"},
                new Booking {CustomerID =1, PractitionerID = 2, Time= "13:00", Date = "2020-11-30", BookingPrice=250,BookingStatus="Not Paid"},
                new Booking {CustomerID =2, PractitionerID = 2, Time= "10:00", Date = "2020-12-01", BookingPrice=200,BookingStatus="Not Paid"},
                new Booking {CustomerID =2, PractitionerID = 3, Time= "13:00", Date = "2020-11-30", BookingPrice=250,BookingStatus="Not Paid"},
                new Booking {CustomerID =3, PractitionerID = 3, Time= "10:00", Date = "2020-11-01", BookingPrice=300,BookingStatus="Paid"},
                new Booking {CustomerID =3, PractitionerID = 4, Time= "14:00", Date = "2020-11-01", BookingPrice=300,BookingStatus="Paid"},
                new Booking {CustomerID =4, PractitionerID = 4, Time= "10:00", Date = "2020-11-03", BookingPrice=200,BookingStatus="Paid"},
                new Booking {CustomerID =4, PractitionerID = 5, Time= "14:00", Date = "2020-11-03", BookingPrice=200,BookingStatus="Paid"},
                new Booking {CustomerID =5, PractitionerID = 5, Time= "12:00", Date = "2020-12-01", BookingPrice=400,BookingStatus="Not Paid"},
                new Booking {CustomerID =5, PractitionerID = 4, Time= "14:00", Date = "2020-12-01", BookingPrice=400,BookingStatus="Not Paid"},
                new Booking {CustomerID =6, PractitionerID = 5, Time= "11:00", Date = "2020-12-15", BookingPrice=500,BookingStatus="Not Paid"},
                new Booking {CustomerID =6, PractitionerID = 1, Time= "13:00", Date = "2020-12-15", BookingPrice=500,BookingStatus="Not Paid"},
            };
            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            List<Payment_Types> paymentTypes = new List<Payment_Types>
            {
                new Payment_Types{ PaymentType = "Credit Card",PaymentTypeDetail="VISA"},
                new Payment_Types{ PaymentType = "Credit Card",PaymentTypeDetail="Mastercard"},
                new Payment_Types{ PaymentType = "Debit Card",PaymentTypeDetail="RBC"},
                new Payment_Types{ PaymentType = "Debit Card",PaymentTypeDetail="TD"},
                new Payment_Types{ PaymentType = "Debit Card",PaymentTypeDetail="ScotiaBank"}
            };
            context.Payment_Types.AddRange(paymentTypes);
            context.SaveChanges();

            List<Payment> payments = new List<Payment>
            {

                new Payment { BookingID=5, CustomerID=3,Date = "2020-11-20",Time = "11:35",TotalAmountPaid= 300, PaymentTypeID = 1, PaymentStatus="Approved"},
                new Payment { BookingID=6, CustomerID=3,Date = "2020-11-20",Time = "11:35",TotalAmountPaid= 300, PaymentTypeID = 1, PaymentStatus="Approved"},
                new Payment { BookingID=7, CustomerID=4,Date = "2020-11-25",Time = "11:00",TotalAmountPaid= 200, PaymentTypeID = 1, PaymentStatus="Approved"},
                new Payment { BookingID=8, CustomerID=4,Date = "2020-11-25",Time = "11:00",TotalAmountPaid= 200, PaymentTypeID = 1, PaymentStatus="Approved"},

            };
            context.Payments.AddRange(payments);
            context.SaveChanges();
        }
    }
}

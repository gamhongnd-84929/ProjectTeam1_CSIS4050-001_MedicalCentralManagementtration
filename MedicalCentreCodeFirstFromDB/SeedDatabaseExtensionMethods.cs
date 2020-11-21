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

            context.Database.Delete();
            context.Database.Create();

            context.SaveChanges();

            context.Users.Load();
            context.Customers.Load();
            context.Practitioners.Load();
            context.Practitioner_Types.Load();
            context.Services.Load();
            context.Bookings.Load();

            List<Practitioner_Types> types = new List<Practitioner_Types>(){
                new Practitioner_Types {Title = "Dermatologist"},
                new Practitioner_Types{Title = "Neurologist"}
            };
            context.Practitioner_Types.AddRange(types);
            context.SaveChanges();

            List<Service> services = new List<Service>
            {
                new Service{ ServiceName= "Skin Tag Removal", ServiceDescription="Removing any skin growth", PractitionerTypeID =1, ServicePrice=100, MSPCoverage = 0.4m},
                new Service{ ServiceName= "Neuro Exam", ServiceDescription="Performing Neuro Exam", PractitionerTypeID =2 ,ServicePrice=500, MSPCoverage =0.40m},
                new Service{ ServiceName= "Skin Exam", ServiceDescription="Examining any Skin Conditions", PractitionerTypeID =1 ,ServicePrice=800,MSPCoverage = 0.6m},
            };
            context.Services.AddRange(services);
            context.SaveChanges();
            List<User> users = new List<User>()
            {
                new User { FirstName= "Jane", LastName = "Doe", Birthdate = "1994-08-20", Address = "100 1st", City="Vancouver",Province="BC",PostalCode="V3V 1G1", Email = "janedoe@email.com", PhoneNumber = "111-111-1111"},
                new User { FirstName= "John", LastName = "Doe", Birthdate = "1980-07-07", Address = "200 2nd", City="Burnaby",Province="BC",PostalCode="V3F 9L1", Email = "johndoe@email.com", PhoneNumber = "222-222-2222"},
                new User { FirstName= "Doctor1", LastName = "Billings", Birthdate="1999-12-28", Address = "200 2nd", City="Burnaby",Province="BC",PostalCode="V3F 9L1", Email = "doctor@email.com", PhoneNumber = "222-222-2222"},
                new User { FirstName= "Doctor2", LastName = "Yamaha", Birthdate="1999-12-28", Address = "200 2nd", City="Burnaby",Province="BC",PostalCode="V3F 9L1", Email = "doctor@email.com", PhoneNumber = "222-222-2222"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();


            List<Customer> customers = new List<Customer>()
            {
                new Customer { UserID =1, MSP = "123456789"},
                new Customer { UserID =2, MSP = "000000000"},
            };
            List<Practitioner> practitioners = new List<Practitioner>()
            {
                new Practitioner {UserID=3, TypeID = 1},
                new Practitioner {UserID =4, TypeID =2}
            };
            context.Customers.AddRange(customers);
            context.Practitioners.AddRange(practitioners);

            context.SaveChanges();

            List<Booking> bookings = new List<Booking>()
            {
                new Booking {CustomerID =1, PractitionerID = 1, Time= "13:00", Date = "2020-11-30", BookingPrice=250,BookingStatus="Not Paid"}
            };
            context.Bookings.AddRange(bookings);
            context.SaveChanges();

        }
    }
}

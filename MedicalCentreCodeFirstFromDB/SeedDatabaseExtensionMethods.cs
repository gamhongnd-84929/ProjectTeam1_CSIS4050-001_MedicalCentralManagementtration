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

            List<User> users = new List<User>()
            {
                new User { FirstName= "Jane", LastName = "Doe", Address = "100 1st", City="Vancouver",Province="BC",PostalCode="V3V 1G1", Email = "janedoe@email.com", PhoneNumber = "111-111-1111"},
                new User { FirstName= "John", LastName = "Doe", Address = "200 2nd", City="Burnaby",Province="BC",PostalCode="V3F 9L1", Email = "johndoe@email.com", PhoneNumber = "222-222-2222"},

            };

            context.Users.AddRange(users);
            context.SaveChanges();


            List<Customer> customers = new List<Customer>()
            {
                new Customer { UserID =1, MSP = "123456789"},
                new Customer { UserID =2, MSP = "000000000"},
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();



        }
    }
}

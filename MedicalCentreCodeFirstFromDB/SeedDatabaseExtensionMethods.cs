using System;
using System.Collections.Generic;
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

    
            List<UserType> userTypes = new List<UserType>()
            {
                new UserType { UserTypeTitle = "Administrator", UserTypeDescription = "Backup/Reset database and request password changes" },
                new UserType { UserTypeTitle = "Practitioner", UserTypeDescription = "Providing the services" },
                new UserType { UserTypeTitle = "Patient", UserTypeDescription = "Requesting/Booking the services" },

            };

            context.UserTypes.AddRange(userTypes);
            context.SaveChanges();

            List<LoginInfo> loginInfos = new List<LoginInfo>()
            {
                new LoginInfo { UserName = "admin1", Password = "admin1", NeedsChanged = 0, UserTypeID = 1 },
                new LoginInfo { UserName = "admin2", Password = "admin2", NeedsChanged = 0, UserTypeID = 1 },
                new LoginInfo { UserName = "practitioner1", Password = "practitioner1", NeedsChanged = 0, UserTypeID = 2 },
                new LoginInfo { UserName = "practitioner2", Password = "practitioner2", NeedsChanged = 0, UserTypeID = 2 },
                new LoginInfo { UserName = "practitioner3", Password = "practitioner3", NeedsChanged = 0, UserTypeID = 2 },
                new LoginInfo { UserName = "practitioner4", Password = "practitioner4", NeedsChanged = 0, UserTypeID = 2 },
                new LoginInfo { UserName = "customer1", Password = "customer1", NeedsChanged = 0, UserTypeID = 3 },
                new LoginInfo { UserName = "customer2", Password = "customer2", NeedsChanged = 0, UserTypeID = 3 },
                new LoginInfo { UserName = "customer3", Password = "customer3", NeedsChanged = 0, UserTypeID = 3 },

            };

            context.LoginInfoes.AddRange(loginInfos);
            context.SaveChanges();


        }
    }
}

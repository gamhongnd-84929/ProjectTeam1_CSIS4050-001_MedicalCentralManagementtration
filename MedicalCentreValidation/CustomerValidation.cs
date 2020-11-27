using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentreCodeFirstFromDB;

namespace MedicalCentreValidation
{
    public static class CustomerValidation
    {
        public static bool IsValidUserId(this Customer customer)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.Database.Log = (s => Debug.Write(s));
                return context.Users.Any(u => u.UserID == customer.CustomerID);
            };
        }

        public static bool IsValidCustomer(this Customer customer)
        {
            return customer.IsValidUserId();
        }
    }
}

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
    

        public static bool IsValidCustomer(this Customer customer)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                
                return context.Users.Any(u => u.UserID == customer.UserID);
            };
        }
    }
}

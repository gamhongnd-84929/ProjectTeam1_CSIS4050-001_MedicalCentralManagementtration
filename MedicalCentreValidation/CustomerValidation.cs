using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFControllerUtilities;
using MedicalCentreCodeFirstFromDB;

namespace MedicalCentreValidation
{
    public static class CustomerValidation
    {
    

        public static bool IsValidCustomer(this Customer customer)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                
                return (context.Users.Any(u => u.UserID == customer.UserID) && IsValidMSP(customer));
            };
        }

        public static bool IsValidMSP(this Customer customer)
        {
            // if controller can find any entity with same number and department
            if (Controller<MedicalCentreManagementEntities, Customer>.AnyExists(c => (c.MSP == customer.MSP) && (c.MSP != "")))
            {
                return false;
            }
            return true;
        }
    }
}

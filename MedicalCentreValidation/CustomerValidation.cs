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
    
        /// <summary>
        /// Method to ensure customer is valid
        /// </summary>
        /// <param name="customer"></param>
        /// <returns> TRUE if VALID</returns>
        public static bool IsValidCustomer(this Customer customer)
        {
            // Make sure such User exists and MSP is valid
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                return (context.Users.Any(u => u.UserID == customer.UserID) && IsValidMSP(customer));
            };
        }

        /// <summary>
        /// Private helper method to make sure MSP is valid
        /// Can be either blank or has to be unique
        /// </summary>
        /// <param name="customer"> customer object to be validated </param>
        /// <returns>TRUE if VALID</returns>
        private static bool IsValidMSP(this Customer customer)
        {
            if (Controller<MedicalCentreManagementEntities, Customer>.AnyExists(c => (c.MSP == customer.MSP) && (c.MSP != "")))
            {
                return false;
            }
            return true;
        }
    }
}

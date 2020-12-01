using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentreCodeFirstFromDB;

namespace MedicalCentreValidation
{
    public static class PractitionerValidation
    {
   
        /// <summary>
        /// Method to validate a practitioner object
        /// </summary>
        /// <param name="practitioner"> object to be validated</param>
        /// <returns> TRUE if VALID </returns>
        public static bool IsValidPractitioner(this Practitioner practitioner)
        {
            // make sure that userID and PractitionerTypeID exist
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {    
                return (context.Users.Any(u => u.UserID == practitioner.UserID) && context.Practitioner_Types.Any(u => u.TypeID == practitioner.TypeID));
            };
        }
    }
}

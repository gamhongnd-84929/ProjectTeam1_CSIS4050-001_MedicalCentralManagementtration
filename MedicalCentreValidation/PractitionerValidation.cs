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
   
        public static bool IsValidPractitioner(this Practitioner practitioner)
        {
            
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                
                return (context.Users.Any(u => u.UserID == practitioner.UserID) && context.Practitioner_Types.Any(u => u.TypeID == practitioner.TypeID));
            };
        }
    }
}

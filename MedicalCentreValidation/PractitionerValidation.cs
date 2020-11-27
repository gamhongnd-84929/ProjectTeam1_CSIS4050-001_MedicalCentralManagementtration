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
        public static bool IsValidUserID(this Practitioner pratitioner)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.Database.Log = (s => Debug.Write(s));
                return context.Users.Any(u => u.UserID == pratitioner.UserID);
            };
        }

        public static bool IsValidPractitioner(this Practitioner pratitioner)
        {
            return pratitioner.IsValidUserID();
        }
    }
}

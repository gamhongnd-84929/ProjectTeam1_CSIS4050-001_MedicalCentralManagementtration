using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentreCodeFirstFromDB;

namespace MedicalCentreValidation
{
    public static class UserValidation
    {
        public static bool InfoIsInvalid(this User user)
        {
            return (user.FirstName == "" || user.LastName == "");
        }
    }
}
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
        /// <summary>
        /// Method to validate user information
        /// </summary>
        /// <param name="user"> user object to be validated</param>
        /// <returns> TRUE if INVALID </returns>
        public static bool InfoIsInvalid(this User user)
        {
            // make sure name and contact information is filled!
            return (user.FirstName == null || user.FirstName.Trim().Length == 0 ||
                    user.LastName == null || user.LastName.Trim().Length == 0 ||
                    user.PhoneNumber == null || user.PhoneNumber.Trim().Length == 0 ||
                    user.Email == null || user.Email.Trim().Length == 0 || user.Birthdate> DateTime.Now);
        }
    }
}
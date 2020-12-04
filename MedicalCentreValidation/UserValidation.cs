using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            return ( !IsNameValid(user.FirstName) || !IsNameValid(user.LastName)||
                   !IsPhoneNumberValid(user.PhoneNumber) ||
                    !IsEmailValid(user.Email)|| user.Birthdate> DateTime.Now);
        }

        /// <summary>
        /// Checking name to consist of accepted characters
        /// </summary>
        /// <param name="name"> name to be validated </param>
        /// <returns> TRUE if VALID </returns>
        private static bool IsNameValid(string name)
        {
            return name != null && name.Trim().Length != 0 &&  Regex.IsMatch(name, "^[-a-zA-Z' ]+$");
        }

        /// <summary>
        /// Checking phone to consist of accepted characters
        /// </summary>
        /// <param name="phoneNumber"> phone number to be validated </param>
        /// <returns> TRUE if VALID </returns>
        private static bool IsPhoneNumberValid (string phoneNumber)
        {
            return phoneNumber != null && phoneNumber.Trim().Length != 0 && Regex.IsMatch(phoneNumber, "^[( ]?[0-9]{3}[)]?[- ]?[0-9]{3}[- ]?[0-9]{4}$");
    
        }

        /// <summary>
        /// Checking phone to consist of accepted characters in order
        /// </summary>
        /// <param name="email"> email to be validated </param>
        /// <returns> TRUE if VALID </returns>
        private static bool IsEmailValid (string email)
        {
            return email != null && email.Trim().Length != 0 && Regex.IsMatch(email, "^[-a-zA-z0-9_]*[@]{1}[a-zA-z.]*[a-z]$");
        }
    }
}
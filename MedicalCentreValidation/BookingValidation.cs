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
    public static class BookingValidation
    {
        /// <summary>
        /// Method to validate booking information
        /// </summary>
        /// <param name="booking"> Booking object to be validated </param>
        /// <returns> True if INVALID</returns>
        public static bool InfoIsInvalid(this Booking booking)
        {
            // make sure fields are filled and such customer, services and practitioner exist!
            return (!booking.IsValidCustomerId() || !booking.IsValidPractitionerID() || !booking.IsValidServices() || booking.Time < new TimeSpan(9,0,0)|| booking.Time > new TimeSpan(16,0,0)
                || booking.Date < DateTime.Now.Date || booking.BookingPrice < 0 || booking.BookingStatus == BookingStatus.NOT_VALID);
        }

        /// <summary>
        /// Private helper method to ensure that such customer exists in the DB
        /// </summary>
        /// <param name="booking"> Booking object to be validated </param>
        /// <returns></returns>
        private static bool IsValidCustomerId(this Booking booking)
        {
            if (Controller<MedicalCentreManagementEntities, Customer>.AnyExists(c => c.CustomerID == booking.CustomerID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Private helper method to ensure that such practitioner exists in the DB
        /// </summary>
        /// <param name="booking"> Booking object to be validated </param>
        /// <returns></returns>
        private static bool IsValidPractitionerID(this Booking booking)
        {
            if (Controller<MedicalCentreManagementEntities, Practitioner>.AnyExists(p => p.PractitionerID == booking.PractitionerID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Private helper method to ensure that services exist in the DB
        /// </summary>
        /// <param name="booking"> Booking object to be validated </param>
        /// <returns></returns>
        private static bool IsValidServices(this Booking booking)
        {
            // go trhough all services in booking
            foreach (Service service in booking.Services)
            {
                // if one of the services does not exist- return false
                if (!Controller<MedicalCentreManagementEntities, Service>.AnyExists(s => s.ServiceID == service.ServiceID))
                {
                    return false;
                }

            }// if all exist-valid!
            return true;
        }

    }
}

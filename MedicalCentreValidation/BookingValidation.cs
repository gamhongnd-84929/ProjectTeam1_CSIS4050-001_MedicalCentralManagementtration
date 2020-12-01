﻿using System;
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
        public static bool InfoIsInvalid (this Booking booking)
        {
            return (booking.IsValidCustomerId() || booking.PractitionerID == 0 || booking.Time == ""
                || booking.Date == "" || booking.BookingPrice < 0 || booking.BookingStatus == "");
        }

        public static bool IsValidCustomerId(this Booking booking)
        {
            if (Controller<MedicalCentreManagementEntities, Customer>.AnyExists(c => c.CustomerID == booking.CustomerID))
            {
                return false;
            }
            return true;
        }

       
    }
}

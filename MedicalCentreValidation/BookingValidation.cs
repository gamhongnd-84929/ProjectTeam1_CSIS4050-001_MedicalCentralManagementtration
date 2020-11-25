using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentreCodeFirstFromDB;

namespace MedicalCentreValidation
{
    public static class BookingValidation
    {
        public static bool InfoIsInvalid (this Booking booking)
        {
            return (booking.CustomerID == 0 || booking.PractitionerID == 0 || booking.Time == ""
                || booking.Date == "" || booking.BookingPrice < 0 || booking.BookingStatus == "");
        }
    }
}

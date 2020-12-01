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
    public static class PaymentValidation
    {
        public static bool IsValidCustomerId(this Payment payment)
        {
            if (Controller<MedicalCentreManagementEntities, Customer>.AnyExists(c => c.CustomerID == payment.CustomerID))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidBookingId(this Payment payment)
        {
            if (Controller<MedicalCentreManagementEntities, Booking>.AnyExists(b => b.BookingID == payment.BookingID))
            {
                return false;
            }
            return true;
        }

        public static bool InfoIsInvalid(this Payment payment)
        {
            return (payment.IsValidCustomerId() || payment.IsValidBookingId() || payment.PaymentTypeID <= 0 ||
                    payment.Time == "" || payment.Date == "" || payment.TotalAmountPaid == 0 || payment.PaymentStatus == "");
        }

        
    }
}

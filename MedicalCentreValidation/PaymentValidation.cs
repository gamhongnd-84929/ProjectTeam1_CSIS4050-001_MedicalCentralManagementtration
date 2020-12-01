using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentreCodeFirstFromDB;

namespace MedicalCentreValidation
{
    public static class PaymentValidation
    {
        public static bool IsValidCustomerId(this Payment payment)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.Database.Log = (s => Debug.Write(s));
                return context.Customers.Any(c => c.CustomerID == payment.CustomerID);
            }
        }

        public static bool IsValidBookingId(this Payment payment)
        {
            using (MedicalCentreManagementEntities context = new MedicalCentreManagementEntities())
            {
                context.Database.Log = (s => Debug.Write(s));
                return context.Bookings.Any(b => b.BookingID == payment.BookingID);
            }
        }

        public static bool InfoIsInvalid(this Payment payment)
        {
            return (payment.IsValidCustomerId() || payment.IsValidBookingId() || payment.PaymentTypeID <= 0 ||
                    payment.Time == "" || payment.Date == "" || payment.TotalAmountPaid == 0 || payment.PaymentStatus == "");
        }

        
    }
}

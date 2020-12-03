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
        /// <summary>
        /// Private helper method to make sure that such customer exists in db
        /// </summary>
        /// <param name="payment"> payment object to be validated</param>
        /// <returns></returns>
        private static bool IsValidCustomerId(this Payment payment)
        {
            if (Controller<MedicalCentreManagementEntities, Customer>.AnyExists(c => c.CustomerID == payment.CustomerID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Private helper method to make sure that such booking exists in db
        /// </summary>
        /// <param name="payment">payment object to be validated</param>
        /// <returns></returns>
        private static bool IsValidBookingId(this Payment payment)
        {
            if (Controller<MedicalCentreManagementEntities, Booking>.AnyExists(b => b.BookingID == payment.BookingID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Private helper method to make sure that such payment type exists in db
        /// </summary>
        /// <param name="payment">payment object to be validated</param>
        /// <returns></returns>
        private static bool IsValidPaymentTypeId(this Payment payment)
        {
            if (Controller<MedicalCentreManagementEntities, Payment_Types>.AnyExists(b => b.PaymentTypeID == payment.PaymentTypeID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to validate a payment object
        /// </summary>
        /// <param name="payment">payment object to be validated</param>
        /// <returns> True if INVALID </returns>
        public static bool InfoIsInvalid(this Payment payment)
        {
            // make sure that all fields are filled and CustomerID,BookingID and PaymentTypeID exist!
            return (!payment.IsValidCustomerId() || !payment.IsValidBookingId() || !payment.IsValidPaymentTypeId()||
                     payment.Date > DateTime.Now || payment.TotalAmountPaid == 0 || payment.PaymentStatus == PaymentStatus.NOT_VALID);
        }

        
    }
}

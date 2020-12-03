using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentreCodeFirstFromDB
{

    // Set of enums used for BookingStatuses throughout the application
    public enum BookingStatus { NOT_PAID = 1, PAID = 2, CANCELLED = 3, NOT_VALID = 4, TIME_OFF = 5 };

    // Set of enums used for PaymentStatuses throughout the application
    public enum PaymentStatus { APPROVED = 1, DECLINED = 2, REFUNDED = 3, NOT_VALID = 4 };

}

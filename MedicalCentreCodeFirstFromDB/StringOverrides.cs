using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentreCodeFirstFromDB
{
    partial class Service
    {
        public override string ToString()
        {
            return ServiceName;
        }
    }

    partial class Practitioner
    {
        public override string ToString()
        {
            return User.LastName + ", " + User.FirstName;
        }
    }
    partial class Practitioner_Types
    {
        public override string ToString()
        {
            return Title;
        }
    }

    partial class Payment_Types
    {
        public override string ToString()
        {
            return PaymentType + ": " + PaymentTypeDetail;
        }
    }
}

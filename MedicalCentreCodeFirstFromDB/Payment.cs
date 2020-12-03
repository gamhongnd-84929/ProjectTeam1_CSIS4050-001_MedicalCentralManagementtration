namespace MedicalCentreCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            Customers = new HashSet<Customer>();
        }

        public int PaymentID { get; set; }

        public int CustomerID { get; set; }

        public int BookingID { get; set; }

        public int PaymentTypeID { get; set; }

        public TimeSpan? Time { get; set; }

        public DateTime? Date { get; set; }

        public decimal? TotalAmountPaid { get; set; }

        [EnumDataType(typeof(PaymentStatus))]
        public PaymentStatus PaymentStatus { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Payment_Types Payment_Types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

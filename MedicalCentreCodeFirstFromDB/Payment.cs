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
         
        }

        public int PaymentID { get; set; }

        public int CustomerID { get; set; }

        public int BookingID { get; set; }

        public int PaymentTypeID { get; set; }

        public TimeSpan? Time { get; set; }

        [StringLength(10)]
        public string Date { get; set; }

        public decimal? TotalAmountPaid { get; set; }

        [StringLength(50)]
        public string PaymentStatus { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Payment_Type Payment_Types { get; set; }

       
    }
}

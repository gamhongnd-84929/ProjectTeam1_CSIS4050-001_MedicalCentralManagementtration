namespace MedicalCentreCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            Payments = new HashSet<Payment>();
            Services = new HashSet<Service>();
            Customers = new HashSet<Customer>();
        }

        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int PractitionerID { get; set; }

        public TimeSpan? Time { get; set; }

     
        public DateTime? Date { get; set; }

        [Column(TypeName = "text")]
        public string PractitionerComment { get; set; }

        public decimal BookingPrice { get; set; }

        [EnumDataType(typeof(BookingStatus))]
        public BookingStatus BookingStatus { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Practitioner Practitioner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

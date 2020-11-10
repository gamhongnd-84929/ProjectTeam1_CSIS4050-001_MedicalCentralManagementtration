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

            Services = new HashSet<Service>();
          
        }

        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int PractitionerID { get; set; }

        public TimeSpan Time { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "text")]
        public string DoctorComment { get; set; }

        public decimal BookingPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string BookingStatus { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Practitioner Practitioner { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }

    }
}

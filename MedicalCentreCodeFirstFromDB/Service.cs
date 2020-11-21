namespace MedicalCentreCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ServiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }

        [StringLength(50)]
        public string ServiceDescription { get; set; }

        public decimal ServicePrice { get; set; }

        public int PractitionerTypeID { get; set; }

        public decimal MSPCoverage { get; set; }

        public virtual Practitioner_Types Practitioner_Types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

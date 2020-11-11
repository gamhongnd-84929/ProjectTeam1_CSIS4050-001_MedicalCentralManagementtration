namespace MedicalCentreCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserType")]
    public partial class UserType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserType()
        {
            LoginInfoes = new HashSet<LoginInfo>();
        }

        public int UserTypeID { get; set; }

        [Column("UserTypeTitle")]
        [Required]
        [StringLength(50)]
        public string UserTypeTitle { get; set; }

        [StringLength(100)]
        public string UserTypeDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoginInfo> LoginInfoes { get; set; }
    }
}

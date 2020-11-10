namespace MedicalCentreCodeFirstFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MedicalCentreManagementEntities : DbContext
    {
        public MedicalCentreManagementEntities()
            : base("name=MedicalCentreManagementConnection")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LoginInfo> LoginInfoes { get; set; }
        public virtual DbSet<Payment_Type> Payment_Types { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Practitioner_Type> Practitioner_Types { get; set; }
        public virtual DbSet<Practitioner> Practitioners { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

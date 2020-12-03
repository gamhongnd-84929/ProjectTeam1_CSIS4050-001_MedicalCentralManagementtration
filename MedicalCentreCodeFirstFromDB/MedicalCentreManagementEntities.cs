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

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
     
        public virtual DbSet<Payment_Types> Payment_Types { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Practitioner_Types> Practitioner_Types { get; set; }
        public virtual DbSet<Practitioner> Practitioners { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }
  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         // Database.SetInitializer<MedicalCentreManagementEntities>(null);

            modelBuilder.Entity<Booking>()
                .Property(e => e.PractitionerComment)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingStatus);

            modelBuilder.Entity<Booking>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Booking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Booking>()
                .HasMany(e => e.Services)
                .WithMany(e => e.Bookings)
                .Map(m => m.ToTable("Booking_Services").MapLeftKey("BookingID").MapRightKey("ServiceID"));

            
            modelBuilder.Entity<Customer>()
                .Property(e => e.MSP)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);

           
            modelBuilder.Entity<Payment_Types>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Types>()
                .Property(e => e.PaymentTypeDetail)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_Types>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Payment_Types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Date);
           

            modelBuilder.Entity<Payment>()
                .Property(e => e.TotalAmountPaid)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaymentStatus);

            modelBuilder.Entity<Practitioner_Types>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Practitioner_Types>()
                .HasMany(e => e.Practitioners)
                .WithRequired(e => e.Practitioner_Types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Practitioner_Types>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Practitioner_Types)
                .HasForeignKey(e => e.PractitionerTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Practitioner>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Practitioner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServicePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Service>()
                .Property(e => e.MSPCoverage)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Practitioners)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

        }
    }
}

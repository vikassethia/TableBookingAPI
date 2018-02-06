namespace DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TableBookingModel : DbContext
    {
        public TableBookingModel()
            : base("name=TableBookingConnString")
        {
        }

        public virtual DbSet<bookedtable> bookedtables { get; set; }
        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<tableinfo> tableinfoes { get; set; }
        public virtual DbSet<tableshape> tableshapes { get; set; }
        public virtual DbSet<userrole> userroles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<archivedbooking> archivedbookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bookedtable>()
                .Property(e => e.BookingId)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.BookingId)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .Property(e => e.BookedBy)
                .IsUnicode(false);

            modelBuilder.Entity<booking>()
                .HasMany(e => e.bookedtables)
                .WithRequired(e => e.booking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tableinfo>()
                .HasMany(e => e.bookedtables)
                .WithRequired(e => e.tableinfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tableshape>()
                .Property(e => e.ShapeName)
                .IsUnicode(false);

            modelBuilder.Entity<userrole>()
                .Property(e => e.UserRoleName)
                .IsUnicode(false);

            modelBuilder.Entity<userrole>()
                .HasMany(e => e.users)
                .WithRequired(e => e.userrole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Salt)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.BookingId)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.BookedBy)
                .IsUnicode(false);

            modelBuilder.Entity<archivedbooking>()
                .Property(e => e.bookedtables)
                .IsUnicode(false);           
        }
    }
}

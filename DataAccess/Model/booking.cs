namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("booking")]
    public partial class booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public booking()
        {
            bookedtables = new HashSet<bookedtable>();
        }

        [StringLength(64)]
        public string BookingId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public int NumberOfGuests { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        public DateTime BookingDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public string CustomerId { get; set; }

        [StringLength(64)]
        public string BookedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookedtable> bookedtables { get; set; }

        [Column(TypeName = "bit")]
        public bool HasArrived { get; set; }

        public virtual customer customer { get; set; }
    }
}

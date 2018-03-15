namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("archivedbooking")]
    public partial class archivedbooking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public archivedbooking()
        {
           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        [StringLength(50)]
        public string Bookedtables { get; set; }

        [Column(TypeName = "bit")]
        public bool HasArrived { get; set; }
    }
}

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        public customer()
        {
            users = new HashSet<user>();
            tableinfoes = new HashSet<tableinfo>();
            bookings = new HashSet<booking>();
        }

        [StringLength(64)]
        public string CustomerId { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(255)]
        public string DisplayName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
      
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        public DateTime AddeddOn { get; set; }

        public virtual ICollection<user> users { get; set; }

        public virtual ICollection<tableinfo> tableinfoes { get; set; }

        public virtual ICollection<booking> bookings { get; set; }
    }
}

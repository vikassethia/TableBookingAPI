namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tablebooking.bookedtable")]
    public partial class bookedtable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string BookingId { get; set; }

        public int TableNumber { get; set; }

        public virtual booking booking { get; set; }

        public virtual tableinfo tableinfo { get; set; }
    }
}

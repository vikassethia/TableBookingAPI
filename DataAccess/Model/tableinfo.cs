namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tableinfo")]
    public partial class tableinfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tableinfo()
        {
            bookedtables = new HashSet<bookedtable>();
        }

        [Key]
        public int TableId { get; set; }
                
        public int TableNumber { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        public int Capacity { get; set; }

        public int? ShapeId { get; set; }

        public double? Xposition { get; set; }

        public double? Yposition { get; set; }

        public string CustomerId { get; set; }

        [Column(TypeName = "bit")]
        public bool IsBookable { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookedtable> bookedtables { get; set; }

        public virtual tableshape tableshape { get; set; }

        public virtual customer customer { get; set; }
    }
}

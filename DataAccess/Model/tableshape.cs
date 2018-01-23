namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tablebooking.tableshape")]
    public partial class tableshape
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tableshape()
        {
            tableinfoes = new HashSet<tableinfo>();
        }

        [Key]
        public int ShapeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShapeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tableinfo> tableinfoes { get; set; }
    }
}

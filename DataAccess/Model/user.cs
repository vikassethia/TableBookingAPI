namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tablebooking.users")]
    public partial class user
    {
        [StringLength(64)]
        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(255)]
        public string Salt { get; set; }

        public int UserRoleID { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        public DateTime AddeddOn { get; set; }

        public virtual userrole userrole { get; set; }
    }
}

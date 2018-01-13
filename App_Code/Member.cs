namespace WCFHosting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        [Required]
        [StringLength(30)]
        public string MemberName { get; set; }

        [Key]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(24)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}

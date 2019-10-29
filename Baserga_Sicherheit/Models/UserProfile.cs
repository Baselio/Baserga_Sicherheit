namespace Baserga_Sicherheit.Models
{
    using Baserga_Sicherheit.Controllers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Key]
        [RegularExpression("^[A-Za-z0-9]+(?:[ _-][A-Za-z0-9]+)*$")]
        [Column(Order = 1)]
        [StringLength(50)]
        [UsernameValidation]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        [PasswortValidation]
        public string Password { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsActive { get; set; }
    }
}

namespace SocialNetwork.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string FirstName { get; set; }

        [StringLength(150)]
        public string MiddleName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [StringLength(150)]
        public string Photo { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime RegisteredDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuanatosSoft.Api.Data.Entities
{
    [Table("Restaurant", Schema = "Business")]
    public partial class Restaurant
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string MainImageUrl { get; set; }
    }
}

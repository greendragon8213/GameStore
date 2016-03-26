using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GameStore.Data.Entities
{
    [Table("PlatformTypes")]
    public class PlatformType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Type { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}

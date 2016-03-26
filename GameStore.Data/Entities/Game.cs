using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("Games")]
    public class Game
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(8)]
        public string Key { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }//ToDo
        public virtual ICollection<Genre> Genres { get; set; }//ToDo
        public virtual ICollection<PlatformType> PlatformTypes { get; set; } //ToDo
    }
}

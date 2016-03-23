using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Entities
{
    public class Game
    {
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

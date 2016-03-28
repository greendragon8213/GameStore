using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class GameWebModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Key { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        public ICollection<CommentWebModel> Comments { get; set; }
        public virtual ICollection<GenreWebModel> Genres { get; set; }
        public ICollection<PlatformTypeWebModel> PlatformTypes { get; set; }
    }
}
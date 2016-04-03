using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class GameWebModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Key is required!")]
        [StringLength(32)]
        public string Key { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descr. is required!")]
        [StringLength(128)]
        public string Description { get; set; }

        public ICollection<CommentWebModel> Comments { get; set; }
        public virtual ICollection<GenreWebModel> Genres { get; set; }
        public ICollection<PlatformTypeWebModel> PlatformTypes { get; set; }
    }
}
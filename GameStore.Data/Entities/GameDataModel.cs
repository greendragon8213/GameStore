using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("Games")]
    public class GameDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        [Required]
        [StringLength(8)]
        public string Key { get; set; }

        public virtual ICollection<CommentDataModel> Comments { get; set; }
        public virtual ICollection<GenreDataModel> Genres { get; set; }
        public virtual ICollection<PlatformTypeDataModel> PlatformTypes { get; set; } 

        public GameDataModel()
        {
            Comments = new Collection<CommentDataModel>();
            Genres = new Collection<GenreDataModel>();
            PlatformTypes = new Collection<PlatformTypeDataModel>();
        }
    }
}

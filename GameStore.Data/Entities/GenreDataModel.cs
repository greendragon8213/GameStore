using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("Genres")]
    public class GenreDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [ForeignKey("ParentGenre")]
        public int? ParentGenreId { get; set; }
        public virtual GenreDataModel ParentGenre { get; set; }
        public virtual ICollection<GameDataModel> Games { get; set; }
        public virtual ICollection<GenreDataModel> ChildGenres { get; set; }

        public GenreDataModel()
        {
            Games = new Collection<GameDataModel>();
        }
    }
}

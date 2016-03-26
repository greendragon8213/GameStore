using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GameStore.Data.Entities
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
        public virtual Genre ParentGenre { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Genre> ChildGenres { get; set; }
    }
}

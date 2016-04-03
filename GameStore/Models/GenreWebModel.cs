using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class GenreWebModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(32)]
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
        
        public virtual ICollection<GenreWebModel> ChildGenres { get; set; }
    }
}
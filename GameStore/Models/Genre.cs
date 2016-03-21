using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }

    }
}
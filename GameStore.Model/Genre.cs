using System.ComponentModel.DataAnnotations;

namespace GameStore.Model
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }

    }
}
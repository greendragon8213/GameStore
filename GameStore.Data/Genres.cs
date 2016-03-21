namespace GameStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Genres
    {
        public Genres()
        {
            GameToGanre = new HashSet<GameToGanre>();
            Genres1 = new HashSet<Genres>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }

        public virtual ICollection<GameToGanre> GameToGanre { get; set; }

        public virtual ICollection<Genres> Genres1 { get; set; }

        public virtual Genres Genres2 { get; set; }
    }
}

namespace GameStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        public Games()
        {
            Comments = new HashSet<Comments>();
            GameToGanre = new HashSet<GameToGanre>();
            GameToPlatformType = new HashSet<GameToPlatformType>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Key { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<GameToGanre> GameToGanre { get; set; }

        public virtual ICollection<GameToPlatformType> GameToPlatformType { get; set; }
    }
}

namespace GameStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlatformTypes
    {
        public PlatformTypes()
        {
            GameToPlatformType = new HashSet<GameToPlatformType>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        public virtual ICollection<GameToPlatformType> GameToPlatformType { get; set; }
    }
}

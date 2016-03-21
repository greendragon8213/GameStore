namespace GameStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameToPlatformType")]
    public partial class GameToPlatformType
    {
        public int Id { get; set; }

        public int? GameId { get; set; }

        public int? PlatformTypeId { get; set; }

        public virtual Games Games { get; set; }

        public virtual PlatformTypes PlatformTypes { get; set; }
    }
}

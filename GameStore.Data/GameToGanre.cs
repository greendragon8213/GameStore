namespace GameStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameToGanre")]
    public partial class GameToGanre
    {
        public int Id { get; set; }

        public int? GameId { get; set; }

        public int? GenreId { get; set; }

        public virtual Games Games { get; set; }

        public virtual Genres Genres { get; set; }
    }
}

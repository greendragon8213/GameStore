using System.Collections.Generic;

namespace GameStore.BusinesLogic.BLModels
{
    public class GameBLModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public decimal Price { get; set; }

        public short? UnitsInStock { get; set; }

        public bool Discontinued { get; set; }

        public virtual PublisherBLModel Publisher { get; set; }

        public virtual ICollection<CommentBLModel> Comments { get; set; }

        public virtual ICollection<GenreBLModel> Genres { get; set; }

        public virtual ICollection<PlatformTypeBLModel> PlatformTypes { get; set; }
    }
}

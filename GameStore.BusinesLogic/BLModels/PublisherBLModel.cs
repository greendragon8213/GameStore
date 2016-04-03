using System.Collections.Generic;

namespace GameStore.BusinesLogic.BLModels
{
    public class PublisherBLModel
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public virtual ICollection<GameBLModel> Games { get; set; }
    }
}

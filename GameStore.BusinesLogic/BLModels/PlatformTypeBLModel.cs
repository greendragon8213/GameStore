using System.Collections.Generic;

namespace GameStore.BusinesLogic.BLModels
{
    public class PlatformTypeBLModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<GameBLModel> Games { get; set; }
    }
}

using System.Collections.Generic;

namespace GameStore.BusinesLogic.BLModels
{
    public class GenreBLModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentGenreId { get; set; }

        public ICollection<GameBLModel> Games { get; set; }

        public GenreBLModel ParentGenre { get; set; }

        public ICollection<GenreBLModel> ChildGenres { get; set; }
    }
}

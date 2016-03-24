using System.Collections.Generic;
using GameStore.Data.Entities;

namespace GameStore.Data.Abstract
{
    public interface IGameRepository
    {
        Entities.Game GetById(int id);
        IEnumerable<Entities.Game> GetAll();
        void Remove(int id);
        void Create(Model.Game game);
        void Update(Model.Game game);
    }
}

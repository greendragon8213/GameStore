using GameStore.Data.Entities;

namespace GameStore.Data.Abstract
{
    public interface IGameRepository
    {
        //Games GetById(int gameId);
        void Update(Game game);
    }
}

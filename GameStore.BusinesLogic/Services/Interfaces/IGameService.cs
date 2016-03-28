using System.Collections.Generic;
using GameStore.BusinesLogic.BLModels;

namespace GameStore.BusinesLogic.Services.Interfaces
{
    public interface IGameService
    {
        IEnumerable<GameBLModel> GetAllGames();
        IEnumerable<GameBLModel> GetAllByGenre(int genreId);
        IEnumerable<GameBLModel> GetAllByPlatform(int platformId);
        GameBLModel GetById(int gameId);
        void Update(GameBLModel game);
        void Create(GameBLModel game);
        void Remove(int gameId);
    }
}

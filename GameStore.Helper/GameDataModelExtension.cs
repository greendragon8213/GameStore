using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BusinesLogic.BLModels;
using GameStore.Data.Entities;

namespace GameStore.Helper
{
    public static class GameDataModelExtension
    {
        public static GameBLModel ToGameBLModel(this GameDataModel gameDataModel)
        {
            var resultGenres = new List<GenreBLModel>();
            foreach (var item in gameDataModel.Genres)
            {
                resultGenres.Add(item.ToGenreBLModel());
            }
            GameBLModel resultModel = new GameBLModel()
            {
                Description = gameDataModel.Description,
                Name = gameDataModel.Name,
                Id = gameDataModel.Id,
                Key = gameDataModel.Key,
                Genres = resultGenres,
                //ToDo other fields
            };

            return resultModel;
        }
    }
}

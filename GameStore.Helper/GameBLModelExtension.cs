using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BusinesLogic.BLModels;
using GameStore.Data.Entities;
using GameStore.Models;

namespace GameStore.Helper
{
    public static class GameBLModelExtension
    {
        public static GameDataModel ToGameDataModel(this GameBLModel gameBlModel)
        {
            var resultGenres = new List<GenreDataModel>();
            foreach (var item in gameBlModel.Genres)
            {
                resultGenres.Add(item.ToGenreDataModel());
            }
            GameDataModel resultModel = new GameDataModel()
            {
                Description = gameBlModel.Description,
                Name = gameBlModel.Name,
                Id = gameBlModel.Id,
                Key = gameBlModel.Key,
                Genres = resultGenres,
                //ToDo other fields
            };

            return resultModel;
        }

        public static GameWebModel ToGameWebModel(this GameBLModel gameBlModel)
        {
            var resultGenres = new List<GenreWebModel>();
            foreach (var item in gameBlModel.Genres)
            {
                resultGenres.Add(item.ToGenreWebModel());
            }
            GameWebModel resultModel = new GameWebModel()
            {
                Description = gameBlModel.Description,
                Name = gameBlModel.Name,
                Id = gameBlModel.Id,
                Key = gameBlModel.Key,
                Genres = resultGenres,
                //ToDo other fields
            };

            return resultModel;
        }
    }
}

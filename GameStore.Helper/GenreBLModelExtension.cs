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
    public static class GenreBLModelExtension
    {
        public static GenreDataModel ToGenreDataModel(this GenreBLModel genreBlModel)
        {
            GenreDataModel resultModel = new GenreDataModel()
            {
                Id = genreBlModel.Id,
                Name = genreBlModel.Name,
                ParentGenreId = genreBlModel.ParentGenreId
            };

            return resultModel;
        }

        public static GenreWebModel ToGenreWebModel(this GenreBLModel genreBlModel)
        {
            GenreWebModel resultModel = new GenreWebModel()
            {
                Id = genreBlModel.Id,
                Name = genreBlModel.Name,
                ParentGenreId = genreBlModel.ParentGenreId
            };

            return resultModel;
        }
    }
}

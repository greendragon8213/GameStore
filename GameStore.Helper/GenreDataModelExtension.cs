using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BusinesLogic.BLModels;
using GameStore.Data.Entities;

namespace GameStore.Helper
{
    public static class GenreDataModelExtension
    {
        public static GenreBLModel ToGenreBLModel(this GenreDataModel genreDataModel)
        {
            GenreBLModel resultModel = new GenreBLModel()
            {
                Id = genreDataModel.Id,
                Name = genreDataModel.Name,
                ParentGenreId = genreDataModel.ParentGenreId
            };

            return resultModel;
        }
    }
}

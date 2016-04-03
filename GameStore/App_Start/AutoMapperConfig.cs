using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.Data.Entities;
using GameStore.Models;

namespace GameStore.App_Start
{
    public static class AutoMapperConfig
    {

        public static void CreateAllMaps()
        {
            #region BL <=> Web Models
            Mapper.CreateMap<GameWebModel, GameBLModel>();
            Mapper.CreateMap<GenreWebModel, GenreBLModel>();
            Mapper.CreateMap<CommentWebModel, CommentBLModel>();
            Mapper.CreateMap<PlatformTypeWebModel, PlatformTypeBLModel>();

            Mapper.CreateMap<PublisherWebModel, PublisherBLModel>();
            Mapper.CreateMap<OrderWebModel, OrderBLModel>();
            Mapper.CreateMap<OrderDetailsWebModel, OrderDetailsBLModel>();

            Mapper.CreateMap<GameBLModel, GameWebModel>();
            Mapper.CreateMap<GenreBLModel, GenreWebModel>();
            Mapper.CreateMap<CommentBLModel, CommentWebModel>();
            Mapper.CreateMap<PlatformTypeBLModel, PlatformTypeWebModel>();

            Mapper.CreateMap<PublisherBLModel, PublisherWebModel>();
            Mapper.CreateMap<OrderBLModel, OrderWebModel>();
            Mapper.CreateMap<OrderDetailsBLModel, OrderDetailsWebModel>();
            #endregion

            #region Data <=> BL Models
            Mapper.CreateMap<GameDataModel, GameBLModel>();
            Mapper.CreateMap<GenreDataModel, GenreBLModel>();
            Mapper.CreateMap<CommentDataModel, CommentBLModel>();
            Mapper.CreateMap<PlatformTypeDataModel, PlatformTypeBLModel>();

            Mapper.CreateMap<PublisherDataModel, PublisherBLModel>();
            Mapper.CreateMap<OrderDataModel, OrderBLModel>();
            Mapper.CreateMap<OrderDetailsDataModel, OrderDetailsBLModel>();

            Mapper.CreateMap<GameBLModel, GameDataModel>();
            Mapper.CreateMap<GenreBLModel, GenreDataModel>();
            Mapper.CreateMap<CommentBLModel, CommentDataModel>();
            Mapper.CreateMap<PlatformTypeBLModel, PlatformTypeDataModel>();

            Mapper.CreateMap<PublisherBLModel, PublisherDataModel>();
            Mapper.CreateMap<OrderBLModel, OrderDataModel>();
            Mapper.CreateMap<OrderDetailsBLModel, OrderDetailsDataModel>();
            #endregion
        }
    }
}
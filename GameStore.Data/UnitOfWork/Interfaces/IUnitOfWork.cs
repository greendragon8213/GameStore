using GameStore.Data.Abstract;
using GameStore.Data.Entities;

namespace GameStore.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<CommentDataModel> CommentRepository { get; }
        IBaseRepository<GameDataModel> GameRepository { get; }
        IBaseRepository<GenreDataModel> GenreRepository { get; }
        IBaseRepository<PublisherDataModel> PublisherRepository { get; }
        IBaseRepository<OrderDataModel> OrderRepository { get; }
        IBaseRepository<OrderDetailsDataModel> OrderDetailsRepository { get; }
        IBaseRepository<PlatformTypeDataModel> PlatformRepository { get; }
        void Save();
    }
}

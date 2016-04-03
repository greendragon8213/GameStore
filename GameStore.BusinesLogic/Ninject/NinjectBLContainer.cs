using GameStore.BusinesLogic.Services;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Data.UnitOfWork;
using GameStore.Data.UnitOfWork.Interfaces;
using Ninject.Modules;

namespace GameStore.BusinesLogic.Ninject
{
    public class NinjectBLContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IGameService>().To<GameService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IPublisherService>().To<PublisherService>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}

using System.Data.Entity;
using GameStore.Data.Abstract;
using GameStore.Data.Concrete;
using Ninject.Modules;

namespace GameStore.Data.Ninject
{
    public class NinjectDataContainer : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<DbContext>().To<GameStoreDbContext>();
        }
    }
}

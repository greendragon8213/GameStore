using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GameStore.Data.Entities;

namespace GameStore.Data.Concrete
{
    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext()
        { 
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 120; //2 minutes
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }
    }
}

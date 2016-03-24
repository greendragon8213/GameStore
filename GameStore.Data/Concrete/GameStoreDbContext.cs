using System.Data.Entity;
using GameStore.Data.Entities;

namespace GameStore.Data.Concrete
{
    public class GameStoreDbContext : DbContext
    {
        ////public GameStoreDbContext() :
        ////    base("")//ToDp Add "имя строки подключения из файла конфигурации App.config"
        ////{ }
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
    }
}

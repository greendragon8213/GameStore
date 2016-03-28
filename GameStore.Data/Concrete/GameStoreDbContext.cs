using System.Data.Entity;
using GameStore.Data.Entities;

namespace GameStore.Data.Concrete
{
    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext() : base("DbConnection")
        {
        }

        public DbSet<GameDataModel> Games { get; set; }

        public DbSet<CommentDataModel> Comments { get; set; }

        public DbSet<GenreDataModel> Genres { get; set; }

        public DbSet<PlatformTypeDataModel> PlatformTypes { get; set; }
    }
}

namespace GameStore.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameStoreDataContext : DbContext
    {
        public GameStoreDataContext()
            : base("name=GameStoreDataContext")
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<GameToGanre> GameToGanre { get; set; }
        public virtual DbSet<GameToPlatformType> GameToPlatformType { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<PlatformTypes> PlatformTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .HasMany(e => e.Comments1)
                .WithOptional(e => e.Comments2)
                .HasForeignKey(e => e.ParentCommentId);

            modelBuilder.Entity<Games>()
                .Property(e => e.Key)
                .IsUnicode(false);

            modelBuilder.Entity<Games>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Games>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Games>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Games)
                .HasForeignKey(e => e.GameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Games>()
                .HasMany(e => e.GameToGanre)
                .WithOptional(e => e.Games)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<Games>()
                .HasMany(e => e.GameToPlatformType)
                .WithOptional(e => e.Games)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<Genres>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Genres>()
                .HasMany(e => e.GameToGanre)
                .WithOptional(e => e.Genres)
                .HasForeignKey(e => e.GenreId);

            modelBuilder.Entity<Genres>()
                .HasMany(e => e.Genres1)
                .WithOptional(e => e.Genres2)
                .HasForeignKey(e => e.ParentGenreId);

            modelBuilder.Entity<PlatformTypes>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PlatformTypes>()
                .HasMany(e => e.GameToPlatformType)
                .WithOptional(e => e.PlatformTypes)
                .HasForeignKey(e => e.PlatformTypeId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Data.Concrete;
using GameStore.Data.Entities;

namespace GameStore.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<GameStoreDbContext>
    {
        public DbInitializer()
        {
            var context = new GameStoreDbContext();

            // we should call Seed method only for the first time db initialization
            if (context.Games.Count() == 0
                || context.Comments.Count() == 0
                || context.Genres.Count() == 0
                || context.PlatformTypes.Count() == 0)
            {
                Seed(context);
            }
        }
        protected override void Seed(GameStoreDbContext context)
        {
            #region Adding Genres 
            var genres = new List<GenreDataModel>
            {
                new GenreDataModel { Name = "Strategy" },
                new GenreDataModel { Name = "Puzzle" },
                 new GenreDataModel { Name = "SomeName" }
            };
            genres.ForEach(g => context.Genres.Add(g));
            context.SaveChanges();
            #endregion

            #region Adding Platforms 
            var platforms = new List<PlatformTypeDataModel>
            {
                new PlatformTypeDataModel { Type = "Mobile" },
                new PlatformTypeDataModel { Type = "Browser" },
                new PlatformTypeDataModel { Type = "PC" }
            };
            platforms.ForEach(p => context.PlatformTypes.Add(p));
            context.SaveChanges();
            #endregion

            #region Adding Games 
            var games = new List<GameDataModel>
            {
                new GameDataModel{ Name="Divine Divinity", Description="Divinity Description", Genres=new[]{context.Genres.Find(1) }, PlatformTypes= new[]{context.PlatformTypes.Find(1)}, Key="ui"},
                new GameDataModel{ Name="Divinity: Dragon Commander", Description="Divinity Description", Genres=new[]{context.Genres.Find(2) }, PlatformTypes= new[]{context.PlatformTypes.Find(1)}, Key="uiui"},
                new GameDataModel{ Name="Dark Souls II Season Pass", Description="Divinity Description", Genres=new[]{context.Genres.Find(1) }, PlatformTypes= new[]{context.PlatformTypes.Find(2)}, Key="fdfgh"},
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();
            #endregion

            #region Adding Comments
            var comment1 = new CommentDataModel { Name = "Is it a good game?",GameId = 2, Body = "Who played this game, please answer.", Game = context.Games.Find(2), CreationDate = DateTime.Now};
            var comment2 = new CommentDataModel { Name = "qqq", GameId = 1, Body = "comment body hhhhhh", Game = context.Games.Find(1), CreationDate = DateTime.Now };
            var comment3 = new CommentDataModel { Name = "wtt", GameId = 2, Body = "hohoohohohoho?", ParentComment = comment2, CreationDate = DateTime.Now };

            var comments = new List<CommentDataModel>
            {
                comment1,
                new CommentDataModel{ Name="Answer_to_1",GameId = 2, Body="I did not", ParentComment=comment1, CreationDate = DateTime.Now},
                new CommentDataModel{ Name="Answer_to_2", GameId = 2, Body="Great game", ParentComment = comment1, CreationDate = DateTime.Now},
                comment2,
                comment3,
                new CommentDataModel { Name = "rrr", GameId = 2, Body = "bbbbbbbbbb", ParentComment = comment3, CreationDate = DateTime.Now }
            };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
            #endregion

        }
    }
}

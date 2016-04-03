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
            //Seed(context);
        }
        protected override void Seed(GameStoreDbContext context)
        {
            //For MVC Task2
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

            #region Adding Publishers

            var publishers = new List<PublisherDataModel>
            {
                new PublisherDataModel
                {
                    CompanyName = "MyCompany1",
                    Description = "This is descr",
                    HomePage = "HomePage",
                },
                new PublisherDataModel
                {
                    CompanyName = "MyCompany2",
                    Description = "This is descr2",
                    HomePage = "HomePage2",
                },
                new PublisherDataModel
                {
                    CompanyName = "MyCompany3",
                    Description = "descr!!!!3",
                    HomePage = "HomePage3",
                }
            };
            publishers.ForEach(p => context.Publishers.Add(p));
            context.SaveChanges();
            #endregion

            #region Adding Games
            var games = new List<GameDataModel>
            {
                new GameDataModel{ Name="Divine Divinity", Description="Divinity Description", 
                    Genres=new[]{context.Genres.Find(1) }, 
                    PlatformTypes= new[]{context.PlatformTypes.Find(1)}, 
                    Key="ui", Price = 122, Discontinued = false, UnitsInStock = 15,
                    Publisher = context.Publishers.Find(1)
                },
                new GameDataModel{ Name="Divinity: Dragon Commander", Description="Divinity Description", 
                    Genres=new[]{context.Genres.Find(2) }, 
                    PlatformTypes= new[]{context.PlatformTypes.Find(1)}, 
                    Key="uiui", Price = 777, Discontinued = false, UnitsInStock = 65,
                    Publisher = context.Publishers.Find(2)},
                new GameDataModel{ Name="Dark Souls II Season Pass", Description="Divinity Description", 
                    Genres=new[]{context.Genres.Find(1) }, 
                    PlatformTypes= new[]{context.PlatformTypes.Find(2)}, 
                    Key="fdfgh", Price = 8, Discontinued = true, UnitsInStock = 3,
                    Publisher = context.Publishers.Find(3)
                },
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();
            #endregion

            #region Adding Orders
            var orders = new List<OrderDataModel>
            {
                new OrderDataModel
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now
                },
                new OrderDataModel
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now
                },
                new OrderDataModel
                {
                    CustomerId = 2,
                    OrderDate = DateTime.Now
                }
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();
            #endregion

            #region Adding OrderDetails
            var orderDetails = new List<OrderDetailsDataModel>
            {
                new OrderDetailsDataModel
                {
                    Price = 76,
                    Discount = 0,
                    ProductId = 1,
                    Game = context.Games.Find(1),
                    Order = context.Orders.Find(1),
                    Quantity = 1
                },
                new OrderDetailsDataModel
                {
                    Price = 99,
                    Discount = 7,
                    ProductId = 2,
                    Game = context.Games.Find(2),
                    Order = context.Orders.Find(2),
                    Quantity = 5
                },
                new OrderDetailsDataModel
                {
                    Price = 123,
                    Discount = 55,
                    ProductId = 4,
                    Game = context.Games.Find(4),
                    Order = context.Orders.Find(3),
                    Quantity = 2
                }
                
            };
            orderDetails.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();
            #endregion

            #region Adding Comments
            var comment1 = new CommentDataModel { Name = "Is it a good game?", GameId = 2, Body = "Who played this game, please answer.", Game = context.Games.Find(2), CreationDate = DateTime.Now };
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
        // For MVC Task1:
        //    #region Adding Genres 
        //    var genres = new List<GenreDataModel>
        //    {
        //        new GenreDataModel { Name = "Strategy" },
        //        new GenreDataModel { Name = "Puzzle" },
        //         new GenreDataModel { Name = "SomeName" }
        //    };
        //    genres.ForEach(g => context.Genres.Add(g));
        //    context.SaveChanges();
        //    #endregion

        //    #region Adding Platforms 
        //    var platforms = new List<PlatformTypeDataModel>
        //    {
        //        new PlatformTypeDataModel { Type = "Mobile" },
        //        new PlatformTypeDataModel { Type = "Browser" },
        //        new PlatformTypeDataModel { Type = "PC" }
        //    };
        //    platforms.ForEach(p => context.PlatformTypes.Add(p));
        //    context.SaveChanges();
        //    #endregion

        //    #region Adding Games 
        //    var games = new List<GameDataModel>
        //    {
        //        new GameDataModel{ Name="Divine Divinity", Description="Divinity Description", Genres=new[]{context.Genres.Find(1) }, PlatformTypes= new[]{context.PlatformTypes.Find(1)}, Key="ui"},
        //        new GameDataModel{ Name="Divinity: Dragon Commander", Description="Divinity Description", Genres=new[]{context.Genres.Find(2) }, PlatformTypes= new[]{context.PlatformTypes.Find(1)}, Key="uiui"},
        //        new GameDataModel{ Name="Dark Souls II Season Pass", Description="Divinity Description", Genres=new[]{context.Genres.Find(1) }, PlatformTypes= new[]{context.PlatformTypes.Find(2)}, Key="fdfgh"},
        //    };
        //    games.ForEach(g => context.Games.Add(g));
        //    context.SaveChanges();
        //    #endregion

        //    #region Adding Comments
        //    var comment1 = new CommentDataModel { Name = "Is it a good game?",GameId = 2, Body = "Who played this game, please answer.", Game = context.Games.Find(2), CreationDate = DateTime.Now};
        //    var comment2 = new CommentDataModel { Name = "qqq", GameId = 1, Body = "comment body hhhhhh", Game = context.Games.Find(1), CreationDate = DateTime.Now };
        //    var comment3 = new CommentDataModel { Name = "wtt", GameId = 2, Body = "hohoohohohoho?", ParentComment = comment2, CreationDate = DateTime.Now };

        //    var comments = new List<CommentDataModel>
        //    {
        //        comment1,
        //        new CommentDataModel{ Name="Answer_to_1",GameId = 2, Body="I did not", ParentComment=comment1, CreationDate = DateTime.Now},
        //        new CommentDataModel{ Name="Answer_to_2", GameId = 2, Body="Great game", ParentComment = comment1, CreationDate = DateTime.Now},
        //        comment2,
        //        comment3,
        //        new CommentDataModel { Name = "rrr", GameId = 2, Body = "bbbbbbbbbb", ParentComment = comment3, CreationDate = DateTime.Now }
        //    };
        //    comments.ForEach(c => context.Comments.Add(c));
        //    context.SaveChanges();
        //    #endregion

        }
    }
}

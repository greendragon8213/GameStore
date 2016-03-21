using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using GameStore.Data;

namespace GameStore.Models
{
    public class Game
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Key { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        public static IEnumerable<Game> GetAll()
        {
            using (var context = new GameStoreDataContext())
            {
                return (from item in context.Games
                    select new Game()
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Key = item.Key,
                        Name = item.Name
                    }).ToList();
            }
        }

        internal static Game GetById(int gameId)
        {
            using (var context = new GameStoreDataContext())
            {
                return (from item in context.Games
                        where item.Id == gameId
                        select new Game()
                        {
                            Id = item.Id,
                            Description = item.Description,
                            Key = item.Key,
                            Name = item.Name
                        }).FirstOrDefault();
            }
        }

        internal static void Update(Game game)
        {
            using (var context = new GameStoreDataContext())
            {
                var gameToUpdate = context.Games.Find(game.Id);

                if (gameToUpdate == null)
                {
                    Create(game);
                    return;
                }

                gameToUpdate.Key = game.Key;
                gameToUpdate.Name = game.Name;
                gameToUpdate.Description = game.Description;

                context.Games.AddOrUpdate(gameToUpdate);
                context.SaveChanges();
            }
        }

        internal static void Create(Game game)
        {
            if (game == null)
            {
                return;
            }

            using (var context = new GameStoreDataContext())
            {
                var newGame = new Games
                {
                    Key = game.Key, 
                    Name = game.Name, 
                    Description = game.Description
                };

                context.Games.Add(newGame);
                context.SaveChanges();
            }
        }

        internal static void Remove(int gameId)
        {
            using (var context = new GameStoreDataContext())
            {
                var game = context.Games.Find(gameId);

                if (game == null)
                {
                    return;
                }

                // ToDo remove related records

                context.Games.Remove(game);
                context.SaveChanges();
            }
        }
    }
}
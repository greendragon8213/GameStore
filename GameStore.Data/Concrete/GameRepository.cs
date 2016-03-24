using System.Data.Entity.Migrations;
using GameStore.Data.Abstract;
using GameStore.Data.Entities;

namespace GameStore.Data.Concrete
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreDbContext dataContext)
            : base(dataContext)
        {
        }
        
        public void Create(Model.Game game)
        {
            if (game == null)
            {
                return;
            }

            var entity = new Game
            {
                Key = game.Key, 
                Name = game.Name, 
                Description = game.Description
            };

            Create(entity);
        }

        public void Update(Model.Game game)
        {
            var gameToUpdate = _context.Games.Find(game.Id);

            if (gameToUpdate == null)
            {
                Create(game);

                return;
            }

            gameToUpdate.Key = game.Key;
            gameToUpdate.Name = game.Name;
            gameToUpdate.Description = game.Description;

            //_context.Entry(gameToUpdate).State = EntityState.Modified;
            _context.Games.AddOrUpdate(gameToUpdate);
            SaveChanges();
        }

        public override void Remove(int id)
        {
            int i = 0;

            // ToDo
            ////dataContext.Entry(game).Collection("Comments").Load();
            ////game.Comments.ToList().ForEach(t => dataContext.Comments.Remove(t));

            ////dataContext.Entry(game).Collection("GameToGanre").Load();
            ////game.GameToGanre.ToList().ForEach(t => dataContext.GameToGanre.Remove(t));

            ////dataContext.Entry(game).Collection("GameToPlatformType").Load();
            ////game.GameToPlatformType.ToList().ForEach(t => dataContext.GameToPlatformType.Remove(t));
            /// 
            base.Remove(id);
        }
    }
}

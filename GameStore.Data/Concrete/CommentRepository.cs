using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Data.Abstract;
using GameStore.Data.Entities;
using Game = GameStore.Model.Game;

namespace GameStore.Data.Concrete
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreDbContext dataContext) : base(dataContext)
        {
        }

        public void Add(string content, int gameId, int? parentCommetId = null)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            var entity = new Comment()
            {
                Name = "TestName", // ToDo
                Body = content,
                GameId = gameId,
                ParentCommentId = parentCommetId,
                CreationDate = DateTime.Now
            };

            Create(entity);
        }

        public IEnumerable<Comment> GetCommentsByGameId(int gameId)
        {
            return _context.Comments.Where(c => c.GameId == gameId).ToList();
        }
    }
}

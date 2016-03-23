using System.Collections.Generic;
using GameStore.Data.Entities;

namespace GameStore.Data.Abstract
{
    interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsByGameId(int gameId);

        void Add(string content, int gameId, int? parentCommetId = null);
    }
}

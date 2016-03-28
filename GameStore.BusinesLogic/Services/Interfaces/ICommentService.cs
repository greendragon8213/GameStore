using System.Collections.Generic;
using GameStore.BusinesLogic.BLModels;

namespace GameStore.BusinesLogic.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentBLModel> GetCommentsTreeByGameId(int gameId);
        void AddNewComment(string content, int gameId, int? parentCommentId, string name = "testName");
    }
}

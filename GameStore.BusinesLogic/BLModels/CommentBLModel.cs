using System;
using System.Collections.Generic;

namespace GameStore.BusinesLogic.BLModels
{
    public class CommentBLModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int GameId { get; set; }
        public int? ParentCommentId { get; set; }

        public GameBLModel Game { get; set; }

        public CommentBLModel ParentComment { get; set; }

        public ICollection<CommentBLModel> ChildComments { get; set; }
    }
}

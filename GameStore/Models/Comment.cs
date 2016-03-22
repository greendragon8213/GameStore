using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.WebPages;
using GameStore.Data;

namespace GameStore.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Body { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        public int GameId { get; set; }

        public int? ParentCommentId { get; set; }
        
        internal static IEnumerable<Comment> GetCommentsByGameId(int gameId)
        {
            using (var context = new GameStoreDataContext())
            {
                return (from item in context.Comments
                        where item.GameId == gameId
                        select new Comment()
                        {
                            Id = item.Id,
                            Body = item.Body,
                            CreationDate = item.CreationDate,
                            Name = item.Name,
                            ParentCommentId = item.ParentCommentId
                        }).ToList();
            }
        }

        internal static void Add(string content, int gameId, int? parentCommentId = null)
        {
            if (content.IsEmpty())
            {
                return;
            }

            using (var context = new GameStoreDataContext())
            {
                var newComment = new Comments
                {
                    Name = "testName",//???
                    Body = content,
                    GameId = gameId,
                    //ToDo
                    ParentCommentId = parentCommentId,
                    CreationDate = DateTime.Now
                };

                context.Comments.Add(newComment);
                context.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class CommentWebModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Body is required!")]
        [StringLength(128)]
        public string Body { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        //ToDo
        [Required(ErrorMessage = "GameId is required!")]
        public int GameId { get; set; }

        public int? ParentCommentId { get; set; }

        public virtual ICollection<CommentWebModel> ChildComments { get; set; }
    }
}
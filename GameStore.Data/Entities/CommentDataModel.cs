﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("Comments")]
    public class CommentDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Body { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int GameId { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public virtual CommentDataModel ParentComment { get; set; }
        public virtual ICollection<CommentDataModel> ChildComments { get; set; }
        public virtual GameDataModel Game { get; set; }
    }
}

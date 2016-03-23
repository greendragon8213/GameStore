using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    public class Comment
    {
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

        public int? ParentCommentId { get; set; }//???
        public virtual Comment ParentComment { get; set; }//???

        public int GameId { get; set; }
    }
}

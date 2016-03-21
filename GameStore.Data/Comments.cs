namespace GameStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public Comments()
        {
            Comments1 = new HashSet<Comments>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Body { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        public int GameId { get; set; }

        public int? ParentCommentId { get; set; }

        public virtual Games Games { get; set; }

        public virtual ICollection<Comments> Comments1 { get; set; }

        public virtual Comments Comments2 { get; set; }
    }
}

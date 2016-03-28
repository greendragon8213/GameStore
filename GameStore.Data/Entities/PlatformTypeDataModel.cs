using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("PlatformTypes")]
    public class PlatformTypeDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Type { get; set; }
        public virtual ICollection<GameDataModel> Games { get; set; }

        public PlatformTypeDataModel()
        {
            Games = new Collection<GameDataModel>();
        }
    }
}

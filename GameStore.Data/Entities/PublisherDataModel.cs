using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data.Entities
{
    [Table("Publishers")]
    public class PublisherDataModel
    {
        //Pablishers should have: nvarchar(40) CompanyName, ntext Description, ntext HomePage
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(40)]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public virtual ICollection<GameDataModel> Games { get; set; }

        public PublisherDataModel()
        {
                Games = new Collection<GameDataModel>();
        }
    }
}

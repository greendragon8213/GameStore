using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class PublisherWebModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CompanyName is required!")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        //public virtual ICollection<GameWebModel> Games { get; set; }
    }
}
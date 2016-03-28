using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class PlatformTypeWebModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
    }
}
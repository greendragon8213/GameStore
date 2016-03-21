using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class PlatformType
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Name { get; set; }
    }
}
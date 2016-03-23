using System.ComponentModel.DataAnnotations;

namespace GameStore.Model
{
    public class PlatformType
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Name { get; set; }
    }
}
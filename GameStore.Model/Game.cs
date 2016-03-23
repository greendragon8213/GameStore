using System.ComponentModel.DataAnnotations;

namespace GameStore.Model
{
    public class Game
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Key { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Description { get; set; }
    }
}
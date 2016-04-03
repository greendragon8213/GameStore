using System.ComponentModel;

namespace GameStore.Models
{
    public class OrderDetailsWebModel
    {
        public int Id { get; set; }

        public virtual GameWebModel Game { get; set; }

        public decimal Price
        {
            get
            {
                return Game.Price * Quantity - Discount;
            }
        }

        [DefaultValue(1)]
        public short Quantity { get; set; }

        [DefaultValue(0)]
        public decimal Discount { get; set; }
    }
}
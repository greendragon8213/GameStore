using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("OrderDetails")]
    public class OrderDetailsDataModel
    {
        //Add OrderDetails entity with product id, price, (smallint) quantity, (real) discount.
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int ProductId { get; set; }

        public virtual GameDataModel Game { get; set; }

        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public decimal Discount { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual OrderDataModel Order { get; set; }
    }
}

namespace GameStore.BusinesLogic.BLModels
{
    public class OrderDetailsBLModel
    {
        public int Id { get; set; }

        public virtual GameBLModel Game { get; set; }

        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public decimal Discount { get; set; }

        public virtual OrderBLModel Order { get; set; }
    }
}

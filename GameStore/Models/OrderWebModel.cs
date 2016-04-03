using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GameStore.Models
{
    public class OrderWebModel
    {
        public OrderWebModel()
        {
            OrderDetails = new Collection<OrderDetailsWebModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "CustomerId is required!")]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal GetTotalPrice()
        {
            return OrderDetails.Sum(orderDetailsWebModel => orderDetailsWebModel.Price);
        }

        public virtual ICollection<OrderDetailsWebModel> OrderDetails { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    [Table("Orders")]
    public class OrderDataModel
    {
        // Order should contain customer id and order date. 
         [Key]
         [Required]
         public int Id { get; set; }

         //[ForeignKey("Customers")]
         public int CustomerId { get; set; }

         public DateTime OrderDate { get; set; }

         public virtual ICollection<OrderDetailsDataModel> OrderDetails { get; set; }

         public OrderDataModel()
         {
             OrderDetails = new Collection<OrderDetailsDataModel>();
         }

    }
}

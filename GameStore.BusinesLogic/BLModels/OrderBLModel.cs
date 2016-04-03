using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BusinesLogic.BLModels
{
    public class OrderBLModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetailsBLModel> OrderDetails { get; set; }

        //ToDo replace it
        public int CustomerId { get; set; }
        //public virtual CustomerBLModel Customer { get; set; }
    }
}

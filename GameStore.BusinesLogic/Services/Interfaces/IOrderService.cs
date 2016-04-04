using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BusinesLogic.BLModels;

namespace GameStore.BusinesLogic.Services.Interfaces
{
    public interface IOrderService
    {
        bool Add(OrderBLModel order);
        OrderBLModel GetOrderByCustomerId(int id);
        OrderBLModel GetOrderByOrderId(int id);
    }
}

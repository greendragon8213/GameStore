using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Data.Entities;
using GameStore.Data.UnitOfWork.Interfaces;

namespace GameStore.BusinesLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(OrderBLModel order)
        {
            OrderDataModel orderToAdd = Mapper.Map<OrderDataModel>(order);
            // ToDo Save order to database
            /*_unitOfWork.OrderRepository.Create(orderToAdd);

            var orderDetails = Mapper.Map<IEnumerable<OrderDetailsDataModel>>(order.OrderDetails);

            foreach (var orderDetail in orderDetails)
            {
                _unitOfWork.OrderDetailsRepository.Create(orderDetail);
            }*/
        }

        public OrderBLModel GetOrderByCustomerId(int id)
        {
            OrderDataModel order = _unitOfWork.OrderRepository.GetAll().FirstOrDefault(p => p.CustomerId == id);
            return Mapper.Map<OrderBLModel>(order);
        }

        public OrderBLModel GetOrderByOrderId(int id)
        {
            OrderDataModel order = _unitOfWork.OrderRepository.GetById(id);
            return Mapper.Map<OrderBLModel>(order);
        }
    }
}

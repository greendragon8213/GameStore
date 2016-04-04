using System;
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

        public bool Add(OrderBLModel order)
        {
            OrderDataModel orderToAdd = Mapper.Map<OrderDataModel>(order);

            var orderDetailsToAdd = orderToAdd.OrderDetails;
            orderToAdd.OrderDetails = null;
            orderToAdd.OrderDate = DateTime.Now;

            _unitOfWork.OrderRepository.Create(orderToAdd);

            foreach (var item in orderDetailsToAdd)
            {
                item.ProductId = item.Game.Id;
                item.Game = null;
                item.OrderId = orderToAdd.Id;
                _unitOfWork.OrderDetailsRepository.Create(item);
            }

            return _unitOfWork.OrderRepository.GetById(orderToAdd.Id) != null;
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

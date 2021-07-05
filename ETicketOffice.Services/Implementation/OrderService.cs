using ETicketOffice.Domain.DModels;
using ETicketOffice.Repository.Interface;
using ETicketOffice.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}

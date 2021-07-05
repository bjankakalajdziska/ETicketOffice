using ETicketOffice.Domain.DModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        List<Order> getAllOrdersFromUser(string id);
        Order getOrderDetails(BaseEntity model);
    }
}

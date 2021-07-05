using ETicketOffice.Domain.DModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}

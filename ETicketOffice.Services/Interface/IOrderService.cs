using ETicketOffice.Domain.DModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Services.Interface
{
    public interface IOrderService
    {
        List<Order> getAllOrders();

        Order getOrderDetails(BaseEntity model);
    }
}

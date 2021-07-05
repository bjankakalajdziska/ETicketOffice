using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Domain.DModels
{
    public class TicketsInOrder : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }
    }
}

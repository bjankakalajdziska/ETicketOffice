using ETicketOffice.Domain.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketOffice.Domain.DTO
{
    public class AddTicketToCartDto
    {
        public Ticket SelectedTicket{ get; set; }
        public Guid TicketId { get; set; }
        public int Quantity { get; set; }
    }
}

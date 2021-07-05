using ETicketOffice.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Domain.DModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ETicketOfficeUser User { get; set; }
        public virtual ICollection<TicketsInOrder> Tickets { get; set; }
    }
}

using ETicketOffice.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Domain.DModels
{
    public class Cart : BaseEntity
    {
        public string OwnerId { get; set; }
        public ETicketOfficeUser Owner { get; set; }
        public virtual ICollection<TicketsInCart> TicketsInCart { get; set; }

        public Cart() { }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETicketOffice.Domain.DModels
{
    public class TicketsInCart : BaseEntity
    {
        [Required]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        [Required]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
}

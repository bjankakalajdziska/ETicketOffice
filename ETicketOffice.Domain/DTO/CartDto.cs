using ETicketOffice.Domain.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketOffice.Domain.DTO
{
    public class CartDto
    {
        public List<TicketsInCart> TicketsInCart { get; set; }
        public double TotalPrice { get; set; }
       

    }
}

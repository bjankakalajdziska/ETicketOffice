
using ETicketOffice.Domain.DModels;
using ETicketOffice.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Services.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetDetailsForTicket(Guid? id);
        void CreateNewTicket(Ticket t);
        void UpdeteExistingTicket(Ticket t);
        AddTicketToCartDto GetCartInfo(Guid? id);
        void DeleteTicket(Guid id);
        bool AddToCart(AddTicketToCartDto item, string userID);
    }
}

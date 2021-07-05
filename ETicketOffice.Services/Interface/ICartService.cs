using ETicketOffice.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Services.Interface
{
    public interface ICartService
    {
        CartDto getCartInfo(string userId);
        bool deleteTicketFromCart(string userId, Guid id);
        bool orderNow(string userId);
    }
}

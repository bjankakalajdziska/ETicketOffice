using ETicketOffice.Repository.Interface;
using ETicketOffice.Domain.DModels;
using ETicketOffice.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETicketOffice.Domain.DTO;

namespace ETicketOffice.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<TicketsInCart> _ticketInCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<TicketService> _logger;
        public TicketService(IRepository<Ticket> ticketRepository, ILogger<TicketService> logger, IRepository<TicketsInCart> ticketInCartRepository, IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _ticketInCartRepository = ticketInCartRepository;
            _logger = logger;
        }

        public bool AddToCart(AddTicketToCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userCart = user.UserCart;

            if (item.TicketId != null && userCart != null)
            {
                var ticket = this.GetDetailsForTicket(item.TicketId);

                if (ticket != null)
                {
                    TicketsInCart itemToAdd = new TicketsInCart
                    {
                        Id = Guid.NewGuid(),
                        Ticket = ticket,
                        TicketId = ticket.Id,
                        Cart = userCart,
                        CartId = userCart.Id,
                        Quantity = item.Quantity
                    };

                    this._ticketInCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Ticket was successfully added into Cart");
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Something was wrong. TicketId or UserCart may be unaveliable!");
            return false;
        }

        public void CreateNewTicket(Ticket p)
        {
            this._ticketRepository.Insert(p);
        }

        public void DeleteTicket(Guid id)
        {
            var Ticket = this.GetDetailsForTicket(id);
            this._ticketRepository.Delete(Ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            _logger.LogInformation("GetAllTickets was called!");
            return this._ticketRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(Guid? id)
        {
            return this._ticketRepository.Get(id);
        }

        public AddTicketToCartDto GetCartInfo(Guid? id)
        {
            var Ticket = this.GetDetailsForTicket(id);
            AddTicketToCartDto model = new AddTicketToCartDto
            {
                SelectedTicket = Ticket,
                TicketId = Ticket.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingTicket(Ticket p)
        {
            this._ticketRepository.Update(p);
        }
    }
}

using ETicketOffice.Domain.DModels;
using ETicketOffice.Domain.DTO;
using ETicketOffice.Repository.Interface;
using ETicketOffice.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicketOffice.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TicketsInOrder> _ticketInOrderRepository;
        private readonly IRepository<EmailMessage> _emailRepository;
        private readonly IUserRepository _userRepository;
     

        public CartService(IRepository<EmailMessage> emailRepository, IRepository<Cart> cartRepository, IRepository<TicketsInOrder> ticketInOrderRepository, IRepository<Order> orderRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _orderRepository = orderRepository;
            _emailRepository = emailRepository;
        }

        public bool deleteTicketFromCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {

                var loggedInUser = this._userRepository.Get(userId);

                var userCart = loggedInUser.UserCart;

                var itemToDelete = userCart.TicketsInCart.Where(z => z.TicketId.Equals(id)).FirstOrDefault();

                userCart.TicketsInCart.Remove(itemToDelete);

                this._cartRepository.Update(userCart);

                return true;
            }

            return false;
        }

        public CartDto getCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userCart = loggedInUser.UserCart;

            var AllTickets = userCart.TicketsInCart.ToList();

            var allTicketsPrice = AllTickets.Select(z => new
            {
                TicketPrice = z.Ticket.TicketPrice,
                Quanitity = z.Quantity
            }).ToList();

            double totalPrice = 0.0;


            foreach (var item in allTicketsPrice)
            {
                totalPrice += item.Quanitity * item.TicketPrice;
            }


            CartDto scDto = new CartDto
            {
                TicketsInCart = AllTickets,
                TotalPrice = totalPrice
            };


            return scDto;

        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                
                var loggedInUser = this._userRepository.Get(userId);

                var userCart = loggedInUser.UserCart;

                EmailMessage mail = new EmailMessage();
                mail.MailTo = loggedInUser.Email;
                mail.Subject = "Successfully created order";
                mail.Status = false;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<TicketsInOrder> ticketsInOrder = new List<TicketsInOrder>();

                var result = userCart.TicketsInCart.Select(z => new TicketsInOrder
                {
                    Id = Guid.NewGuid(),
                    TicketId = z.Ticket.Id,
                    Ticket = z.Ticket,
                    OrderId = order.Id,
                    UserOrder = order,
                    Quantity = z.Quantity
                }).ToList();

                StringBuilder sb = new StringBuilder();

                double totalPrice = 0;

                sb.AppendLine("Your order is completed. The order conains: ");

                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];

                    totalPrice += item.Quantity * item.Ticket.TicketPrice;

                    sb.AppendLine(i.ToString() + ". " + item.Ticket.MovieName + " with price of: " + item.Ticket.TicketPrice + " and quantity of: " + item.Quantity);
                }

                sb.AppendLine("Total price: " + totalPrice.ToString());


                mail.Content = sb.ToString();


                ticketsInOrder.AddRange(result);

                foreach (var item in ticketsInOrder)
                {
                    this._ticketInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.TicketsInCart.Clear();

                this._emailRepository.Insert(mail);
                this._userRepository.Update(loggedInUser);
                

                return true;
            }
            return false;
        }
    }
}

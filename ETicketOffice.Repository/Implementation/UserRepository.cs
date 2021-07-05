using ETicketOffice.Domain.Identity;
using ETicketOffice.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicketOffice.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<ETicketOfficeUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ETicketOfficeUser>();
        }
        public IEnumerable<ETicketOfficeUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ETicketOfficeUser Get(string id)
        {
            return entities.Include(z => z.UserCart).
                            Include("UserCart.TicketsInCart").
                            Include("UserCart.TicketsInCart.Ticket").
                            SingleOrDefault(s => s.Id == id);
        }
        public void Insert(ETicketOfficeUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ETicketOfficeUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ETicketOfficeUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}

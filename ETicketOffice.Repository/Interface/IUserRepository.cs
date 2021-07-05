using ETicketOffice.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ETicketOfficeUser> GetAll();
        ETicketOfficeUser Get(string id);
        void Insert(ETicketOfficeUser entity);
        void Update(ETicketOfficeUser entity);
        void Delete(ETicketOfficeUser entity);
    }
}

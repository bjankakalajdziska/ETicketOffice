using ETicketOffice.Domain.DModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETicketOffice.Repository.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}

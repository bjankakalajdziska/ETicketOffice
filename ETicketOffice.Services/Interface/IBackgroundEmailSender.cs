using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETicketOffice.Repository.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}

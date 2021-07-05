using ETicketOffice.Domain.DModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETicketOffice.Domain.Identity
{
    public class ETicketOfficeUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }

        //public Guid UserCartId { get; set; }

        [Required]
        public virtual Cart UserCart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

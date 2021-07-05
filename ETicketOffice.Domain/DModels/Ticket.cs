using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETicketOffice.Domain.DModels
{
    public class Ticket : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        
        public string Image { get; set; }
        
        public string MovieDescription { get; set; }
        [Required]
        public double TicketPrice { get; set; }
     
        public double MovieRating { get; set; }

        [Required]
        public  string MovieGenre { get; set; }

        public DateTime  Date { get; set; }

        public virtual ICollection<TicketsInCart> Carts { get; set; }

        public virtual ICollection<TicketsInOrder> Orders { get; set; }

        public Ticket() { }
    }
}


using ETicketOffice.Domain.DModels;
using ETicketOffice.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicketOffice.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ETicketOfficeUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<TicketsInCart> TicketsInCart { get; set; }
        public virtual DbSet<TicketsInOrder> TicketsInOrder { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Cart>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            //builder.Entity<ETicketOfficeUser>()
            //    .HasOne(z => z.UserCart)
            //    .WithOne(z => z.Owner)
            //    .HasForeignKey<Cart>(z => z.OwnerId);

            //builder.Entity<TicketsInCart>()
                //.HasKey(z => new { z.TicketId, z.CartId });

            builder.Entity<TicketsInCart>()
                .HasOne(z => z.Ticket)
                .WithMany(t => t.Carts)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketsInCart>()
                .HasOne(z => z.Cart)
                .WithMany(t => t.TicketsInCart)
                .HasForeignKey(z => z.CartId);

            builder.Entity<Cart>()
                .HasOne<ETicketOfficeUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<Cart>(z => z.OwnerId);

            //builder.Entity<TicketsInOrder>()
            //.HasKey(z => new { z.TicketId, z.OrderId });

            builder.Entity<TicketsInOrder>()
                .HasOne(z => z.Ticket)
                .WithMany(t => t.Orders)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketsInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(t => t.Tickets)
                .HasForeignKey(z => z.OrderId);
        }
    }
}

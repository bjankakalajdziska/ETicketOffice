using ETicketOffice.Services.Interface;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ETicketOffice.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_orderService.getAllOrdersFromUser(userId));
        }

        public IActionResult CreateInvoice(Guid orderId)
        {
            //ne mi tekna kako da ja zemam soodvetnata naracka so orderId
            //var result = _orderService.getOrderDetails();
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            var document = DocumentModel.Load(templatePath);


            //document.Content.Replace("{{OrderNumber}}", orderId.ToString());
            //document.Content.Replace("{{UserName}}", result.User.UserName);

            //StringBuilder sb = new StringBuilder();

            //var totalPrice = 0.0;

            //foreach (var item in result.Tickets)
            //{
            //    totalPrice += item.Quantity * item.Ticket.TicketPrice;
            //    sb.AppendLine(item.Ticket.MovieName + " with quantity of: " + item.Quantity + " and price of: " + item.Ticket.TicketPrice + "$");
            //}


            //document.Content.Replace("{{TicketList}}", sb.ToString());
            //document.Content.Replace("{{TotalPrice}}", totalPrice.ToString() + "$");


            var stream = new MemoryStream();

            document.Save(stream, new PdfSaveOptions());

            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }
    }
}

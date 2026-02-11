using CHUSHKA.Models;
using CHUSHKA.Services;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult AllOrders()
        {
            return View(orderService.ListAll());
        }

        public IActionResult MakeAnOrder(Guid productId)
        {


            Order order = new Order
            {
                
            };
            return Redirect("/");
        }
    }
}

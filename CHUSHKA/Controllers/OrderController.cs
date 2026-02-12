using CHUSHKA.Models;
using CHUSHKA.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static NuGet.Packaging.PackagingConstants;

namespace CHUSHKA.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly UserManager<IdentityUser> userManager;

        public OrderController(IOrderService orderService, IProductService productService, UserManager<IdentityUser> userManager)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> AllOrders()
        {
            var test = await orderService.ListAllAsync();
            return View(new OrdersViewModel() { Orders = await orderService.ListAllAsync() });
        }

        public async Task<IActionResult> MakeAnOrder(Guid productId)
        {
            var allProducts = await productService.ListAllAsync();
            Order order = new Order
            {
                Id = new Guid(),
                Product = allProducts.FirstOrDefault(x => x.Id == productId)!,
                Client = await userManager.GetUserAsync(User)!,
                OrderedOn = DateTime.UtcNow,

            };
            if(orderService.ListAllAsync().Result.FirstOrDefault(x => x.Client == order.Client) == null)
            {
                await orderService.CreateAsync(order);
            }
            return Redirect("/");
        }
    }
}

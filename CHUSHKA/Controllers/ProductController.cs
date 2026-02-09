using CHUSHKA.Services;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult ProductPage(Guid id)
        {
            return View(productService.GetById(id));
        }

        public IActionResult Delete(Guid id)
        {
            productService.DeleteById(id);
            return Redirect("/");
        }
    }
}

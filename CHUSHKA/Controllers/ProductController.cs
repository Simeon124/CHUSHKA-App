using CHUSHKA.Models;
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
        public async Task<IActionResult> ProductPage(Guid id)
        {
            var product = await productService.GetByIdAsync(id);
            return View(product);
        }

        public IActionResult Delete(Guid id)
        {
            productService.DeleteById(id);
            return Redirect("/");
        }

        public ActionResult CreateProductPage(Product input)
        {
            return View(input);
        }

        public async Task<IActionResult> CreateProduct(Product input)
        {
            if (ModelState.IsValid == true)
            {
                await productService.CreateAsync(input);
                return Redirect("/");
            }
            return View("CreateProductPage", input);

        }

        public async Task<ActionResult> EditProductPage(Guid id)
        {
            var product = await productService.GetByIdAsync(id);
            return View(product);
        }

        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid == true)
            {
                productService.Update(product);
                return View("ProductPage", product);
            }
            return View("EditProductPage", product);
        }
    }
}

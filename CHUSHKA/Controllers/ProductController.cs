using CHUSHKA.Migrations;
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
        public IActionResult ProductPage(Guid id)
        {
            var product = productService.GetById(id);
            return View(product.Result);
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

        public ActionResult CreateProduct(Product input)
        {
            if (ModelState.IsValid == true)
            {
                productService.Create(input);
                return Redirect("/");
            }
            return View("CreateProductPage", input);

        }

        public ActionResult EditProductPage(Guid id)
        {
            var product = productService.GetById(id);
            return View(product.Result);
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

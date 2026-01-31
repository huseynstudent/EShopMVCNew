using EShopp.Aplication.Abstacts;
using EShopp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EShopp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productService.AddProduct(product);
            return RedirectToAction("CreateProduct", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllWithCategoryAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.RemoveProduct(id);
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            await _productService.AddToCart(id);
            return RedirectToAction("GetAllProducts");
        }
    }
}

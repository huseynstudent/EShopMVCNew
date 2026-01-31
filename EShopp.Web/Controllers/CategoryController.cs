using EShopp.Aplication.Abstacts;
using EShopp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EShopp.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category category)
    {
        await _categoryService.AddCategory(category);
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.RemoveCategory(id);
        return RedirectToAction("GetAllCategories");
    }
}


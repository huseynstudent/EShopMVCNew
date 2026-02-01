using Microsoft.AspNetCore.Mvc;

namespace EShopp.Web.Controllers;

public class SaleController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

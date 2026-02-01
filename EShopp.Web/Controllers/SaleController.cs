using EShopp.Aplication.Abstacts;
using Microsoft.AspNetCore.Mvc;

namespace EShopp.Web.Controllers;

public class SaleController : Controller
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }
    [HttpPost]
    public async Task<IActionResult> Buy(int id )
    {
        await _saleService.BuyAsync(id);
        return RedirectToAction("GetAllOrders");
    }
}

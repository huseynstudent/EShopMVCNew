using EShopp.Aplication.Abstacts;
using Microsoft.AspNetCore.Mvc;

namespace EShopp.Web.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return View(orders);
    }

    [HttpPost]
    public async Task<IActionResult> IncreaseQuantity(int id)
    {
        await _orderService.IncreaseQuantityAsync(id);
        return RedirectToAction("GetAllOrders");
    }

    [HttpPost]
    public async Task<IActionResult> DecreaseQuantity(int id)
    {
        await _orderService.DecreaseQuantityAsync(id);
        return RedirectToAction("GetAllOrders");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        await _orderService.RemoveProductFromCart(id);
        return RedirectToAction("GetAllOrders");
    }
}

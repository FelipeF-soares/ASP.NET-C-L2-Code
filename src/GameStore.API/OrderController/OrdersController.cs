using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.OrderController;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

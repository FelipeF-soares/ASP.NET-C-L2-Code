using GameStore.Application.DTOS;
using GameStore.Application.Services;
using GameStore.Application.Services.Interfaces;
using GameStore.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;

    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
    [HttpPost("Pedidos")]
    public async Task<IActionResult> Post([FromBody] OrderRequest request)
    {
        try
        {
            var orders = OrderValid.IsValid(request);
            foreach(var order in orders)
            {
                await orderService.AddOrder(order);
            }
            return Ok();
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes
                           .Status500InternalServerError,
                           $"Erro ao tentar inserir");
        }
    }
}


using GameStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.DTOS.Input;



namespace GameStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;
    private readonly IBoxService boxService;

    public OrderController(IOrderService orderService, IBoxService boxService)
    {
        this.orderService = orderService;
        this.boxService = boxService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await orderService.GetAllOrderAsync();
        
        return Ok(orders);
    }

    [HttpPost("Pedidos")]
    public async Task<IActionResult> Post([FromBody] InputDTO input)
    {
        try
        {
            var orders = OrdersDTO.IsValid(input);
            var ordersbox = await boxService.BoxOrder(orders);
            foreach (var order in ordersbox)
            {
                await  orderService.AddOrder(order);
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


using GameStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.DTOS.Input;
using GameStore.Application.DTOS.Output;



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

    [HttpGet("Saida")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var orders = await orderService.GetAllOrderAsync();
            var pedidos = PedidoDTO.IsValid(orders);

            return Ok(pedidos);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes
                           .Status500InternalServerError,
                           $"Erro ao tentar Carregar");
        }
        
    }

    [HttpPost("Entrada")]
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

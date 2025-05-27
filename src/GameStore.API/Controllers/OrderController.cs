using GameStore.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly GameStoreDbContext dbContext;

    public OrderController(GameStoreDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var boxes = dbContext.Boxes;

        return Ok(boxes);
    }
}

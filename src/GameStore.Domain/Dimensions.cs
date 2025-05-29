using Microsoft.EntityFrameworkCore;
namespace GameStore.Domain;

public class Dimensions
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
    public int Volume { get; set; }

   
}

using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS.Input;

public class DimensoesInputDTO
{
    
    public int largura { get; set; }
    
    public int altura { get; set; }
   
    public int comprimento { get; set; }
}

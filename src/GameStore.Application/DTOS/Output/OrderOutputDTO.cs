using GameStore.Application.DTOS.Output;
using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS;

public class OrderOutputDTO
{
    [JsonPropertyName("pedido_id")]
    public int OrderId { get; set; }
    [JsonPropertyName("caixas")]
    public BoxOutputDTO Boxe { get; set; } 
}

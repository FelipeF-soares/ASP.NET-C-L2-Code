using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS;

public class OrderRequest
{
    [JsonPropertyName("pedidos")]
    public List<OrderDTO> Orders { get; set; }
}

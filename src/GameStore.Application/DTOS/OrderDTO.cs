using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS;

public class OrderDTO
{
    [JsonPropertyName("pedido_id")]
    public int OrderId { get; set; }
    [JsonPropertyName("produtos")]
    public List<ProductDTO> Products { get; set; }
}

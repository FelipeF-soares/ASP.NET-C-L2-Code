using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS;

public class ProductDTO
{
    [JsonPropertyName("produto_id")]
    public string ProductId { get; set; }
    [JsonPropertyName("dimensoes")]
    public DimensionsDTO Dimensions { get; set; }
}

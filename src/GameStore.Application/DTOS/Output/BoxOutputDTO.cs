using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS.Output;

public class BoxOutputDTO
{
    [JsonPropertyName("caixa_id")]
    public string? Name { get; set; }
    [JsonPropertyName("produtos")]
    public List<ProductOutputDTO> Products { get; set; }



}

using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS;

public class DimensionsDTO
{
    [JsonPropertyName("largura")]
    public int Width { get; set; }
    [JsonPropertyName("altura")]
    public int Height { get; set; }
    [JsonPropertyName("comprimento")]
    public int Depth { get; set; }
}

using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS.Input;

public class ProdutosInputDTO
{
    public string produto_id { get; set; }

    [JsonPropertyName("dimensoes")]
    public DimensoesInputDTO dimensoes { get; set; }
}

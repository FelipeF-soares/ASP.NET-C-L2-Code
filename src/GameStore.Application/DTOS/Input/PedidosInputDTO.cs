using System.Text.Json.Serialization;

namespace GameStore.Application.DTOS.Input;

public class PedidosInputDTO
{
    public int pedido_id { get; set; }
    public List<ProdutosInputDTO> produtos { get; set; }
}

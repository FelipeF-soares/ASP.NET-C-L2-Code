using GameStore.Domain;

namespace GameStore.Application.DTOS.Output;

public static class PedidoDTO
{
    public static OutputDTO IsValid(Order[] orders)
    {
        var listPedidos = new OutputDTO();
        var listPedidosDto = new List<PedidosOutputDTO>();
        foreach(var order in orders)
        {
            var pedido = new PedidosOutputDTO();
            pedido.pedido_id = order.OrdersId;
            var listCaixa = new List<CaixasOutputDTO>();
            var listProdutos = new List<ProdutosOutputDTO>();

            foreach(var box in order.Boxes)
            {
                var caixaDTO = new CaixasOutputDTO();
                
                caixaDTO.caixa_id = box.Name;
                foreach(var product in order.Products)
                {
                    var produtoDTO = new ProdutosOutputDTO();
                    produtoDTO.Nome = product.ProductsId;
                    listProdutos.Add(produtoDTO);
                }
                caixaDTO.produtos = listProdutos;
                listCaixa.Add(caixaDTO);
            }
            pedido.caixas = listCaixa;
            listPedidosDto.Add(pedido);
        }
        listPedidos.pedidos = listPedidosDto;
        return listPedidos;
    }
}

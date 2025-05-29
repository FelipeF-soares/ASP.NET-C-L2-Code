using GameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            pedido.pedido_id = order.Id;
            var listCaixa = new List<CaixasOutputDTO>();
            var listProdutos = new List<ProdutosOutputDTO>();
            var caixas = new CaixasOutputDTO();
            caixas.caixa_id = order.Box.Name;
            foreach (var produto in order.Products)
            {
                var produtoDTO = new ProdutosOutputDTO();
                produtoDTO.Nome = produto.ProductName;
                listProdutos.Add(produtoDTO);
            }
            caixas.produtos = listProdutos;
            listCaixa.Add(caixas);
            
            pedido.caixas = listCaixa;
            listPedidosDto.Add(pedido);
        }
        listPedidos.pedidos = listPedidosDto;
        return listPedidos;
    }
}

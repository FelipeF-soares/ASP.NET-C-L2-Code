using GameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.DTOS.Input;

public static class OrdersDTO
{
    public static List<Order> IsValid(InputDTO dto)
    {
        var listOrder = new List<Order>();
        foreach(var pedido in dto.pedidos)
        {
            var order = new Order();
            order.Id = pedido.pedido_id;
            var listProduct = new List<Product>();
            foreach (var produto in pedido.produtos)
            {
                var products = new Product();
                products.OrderId = pedido.pedido_id;
                products.ProductName = produto.produto_id;
                products.Height = produto.dimensoes.altura;
                products.Width = produto.dimensoes.largura;
                products.Depth = produto.dimensoes.comprimento;
                products.Volume = (products.Height * products.Width * products.Depth);
                
                listProduct.Add(products);
            }
            var size = SizeOrder(listProduct);
            order.Depth = size.Depth;
            order.Width = size.Width;
            order.Height = size.Height;
            order.Volume = size.Volume;
            order.Products = listProduct;
            listOrder.Add(order);
        }
        return listOrder;
    }

    public static Dimensions SizeOrder(List<Product> products)
    {
        Dimensions dimensions = new Dimensions();
        foreach(var size in products)
        {
            dimensions.Volume += size.Volume;
            dimensions.Width += size.Width;
            dimensions.Height += size.Height;
            dimensions.Depth += size.Depth;
        }
        return dimensions;
    }
}

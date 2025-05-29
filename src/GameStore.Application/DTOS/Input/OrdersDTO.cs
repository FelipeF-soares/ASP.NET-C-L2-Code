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
            var orderDimension = new Dimensions();
            order.Id = pedido.pedido_id;
            var listProduct = new List<Product>();
            foreach (var produto in pedido.produtos)
            {
                var products = new Product();
                var dimensions = new Dimensions();

                products.OrderId = pedido.pedido_id;
                products.ProductName = produto.produto_id;
                dimensions.Height = produto.dimensoes.altura;
                dimensions.Width = produto.dimensoes.largura;
                dimensions.Depth = produto.dimensoes.comprimento;
                dimensions.Volume = (dimensions.Height * dimensions.Width * dimensions.Depth);
                products.Dimensions = dimensions;
                listProduct.Add(products);
            }
            var size = SizeOrder(listProduct);
            orderDimension.Depth = size.Depth;
            orderDimension.Width = size.Width;
            orderDimension.Height = size.Height;
            orderDimension.Volume = size.Volume;
            order.Dimensions = orderDimension;
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
            dimensions.Volume += size.Dimensions.Volume;
            dimensions.Width += size.Dimensions.Width;
            dimensions.Height += size.Dimensions.Height;
            dimensions.Depth += size.Dimensions.Depth;
        }
        return dimensions;
    }
}

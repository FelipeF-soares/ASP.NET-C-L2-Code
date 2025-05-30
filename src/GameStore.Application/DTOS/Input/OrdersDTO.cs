using GameStore.Domain;

namespace GameStore.Application.DTOS.Input;

public static class OrdersDTO
{
    public static List<Order> IsValid(InputDTO dto)
    {
        var listOrder = new List<Order>();
        foreach(var pedido in dto.pedidos)
        {
            var listProducts = new List<Product>();
            foreach(var produto in pedido.produtos)
            {
                var product = new Product();
                product.ProductsId = produto.produto_id;
                product.Width = produto.dimensoes.largura;
                product.Height = produto.dimensoes.altura;
                product.Depth = produto.dimensoes.comprimento;
                product.Volume = (product.Width * product.Height * product.Depth);
                listProducts.Add(product);
            }
            var order = SizeOrder(listProducts);
            order.OrdersId = pedido.pedido_id;
            order.Products = listProducts;
            listOrder.Add(order);
        }
        return listOrder;
    }

    public static Order SizeOrder(List<Product> products)
    {
        var order = new Order();
        foreach(var size in products)
        {
            order.Volume += size.Volume;
            if(order.Width < size.Width) order.Width = size.Width;
            if(order.Height < size.Height) order.Height = size.Height;
            order.Depth += size.Depth;
        }
        return order;
    }
}

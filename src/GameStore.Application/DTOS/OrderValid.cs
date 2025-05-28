using GameStore.Domain;

namespace GameStore.Application.DTOS;

public static class OrderValid
{
    public static List<Order> IsValid(OrderRequest request)
    {
        List<Order> orderList = new List<Order>();
        
        foreach(var orderDTO in request.Orders)
        {
            Order order = new Order();
            order.Id = orderDTO.OrderId;
            List<Product> productList = new List<Product>();
            for (int i = 0; i < orderDTO.Products.Count; i++)
            {
                var product = new Product();
                product.ProductName = orderDTO.Products[i].ProductId;
                product.Width = orderDTO.Products[i].Dimensions.Width;
                product.Height = orderDTO.Products[i].Dimensions.Height;
                product.Depth = orderDTO.Products[i].Dimensions.Depth;
                productList.Add(product);
            }
            order.Products = productList;
            orderList.Add(order);
        }
        
        return orderList;
    }

    public static Order Test()
    {
        Order order = new Order();
        Product product = new Product();
        List<Product> products = new List<Product>();
        product.ProductName = "PS5";
        product.Width = 10;
        product.Height = 40;
        product.Depth = 25;
        products.Add(product);
        order.Products = products;

        return order;

    }
}

namespace GameStore.Domain;

public class Order : Dimensions
{
    public int Id { get; set; }
    public int OrdersId { get; set; }
    public List<Product> Products { get; set; }
    public List<Box> Boxes { get; set; }
}

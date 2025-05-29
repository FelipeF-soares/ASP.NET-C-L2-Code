namespace GameStore.Domain;

public class Order
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public int? BoxId { get; set; }
    public Box Box { get; set; }
    public Dimensions? Dimensions { get; set; }

}

namespace GameStore.Domain;

public class Order
{
    public int Id { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public int BoxId { get; set; }
    public Box Box { get; set; }
}

namespace GameStore.Domain;

public class Box : Dimensions
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Order> Orders { get; set; }
    public List<Product> Products { get; set; }
}

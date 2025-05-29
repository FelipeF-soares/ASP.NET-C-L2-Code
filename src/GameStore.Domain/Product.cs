namespace GameStore.Domain;

public class Product 
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public Dimensions? Dimensions { get; set; }
}

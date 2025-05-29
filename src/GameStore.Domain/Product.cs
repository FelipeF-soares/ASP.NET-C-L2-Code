namespace GameStore.Domain;

public class Product : Dimensions
{
    public int Id { get; set; }
    public string ProductsId { get; set; } = string.Empty;
    public int OrderId { get; set; }
    public Order Order { get; set; }
}

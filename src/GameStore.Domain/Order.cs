namespace GameStore.Domain;

public class Order : Dimensions
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public int? BoxId { get; set; }
    public Box Box { get; set; }

}

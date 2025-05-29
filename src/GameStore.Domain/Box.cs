namespace GameStore.Domain;

public class Box : Dimensions
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Order> Orders { get; set; }
}

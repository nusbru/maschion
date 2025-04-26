namespace maschion.API.Models;

public class Item
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
}
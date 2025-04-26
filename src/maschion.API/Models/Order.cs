namespace maschion.API.Models;

public class Order
{
    public long Id { get; set; }
    public long ProfileId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Profile Profile { get; set; }
    public ICollection<Item>? Items { get; set; } = new List<Item>();
}

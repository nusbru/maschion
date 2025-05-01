namespace maschion.API.Domain;

public class Customer
{
    public long Id { get; set; }
    public long ProfileId { get; set; }
    public Profile Profile { get; set; }
    public long SellerId { get; set; }
    public Seller Seller { get; set; }
}
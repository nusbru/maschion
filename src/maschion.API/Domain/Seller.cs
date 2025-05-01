namespace maschion.API.Domain;

public class Seller
{
    public long Id { get; set; }
    public long ProfileId { get; set; }
    public Profile Profile { get; set; }
    public ICollection<Customer> Customers { get; set; }
}

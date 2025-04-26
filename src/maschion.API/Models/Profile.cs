namespace maschion.API.Models;

public class Profile
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Profiletype Type { get; set; }

    public ICollection<Order> Orders { get; set; }
}

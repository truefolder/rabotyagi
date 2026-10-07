using Microsoft.AspNetCore.Identity;

namespace rabotyagi.DataAccess.Entities;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
    public List<Role> Roles { get; set; } = null!;
    public Address? Address { get; set; }
    public ICollection<Order> InitiatedOrders { get; set; } = [];
    public ICollection<Order> ExecutedOrders { get; set; } = [];
}
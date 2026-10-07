using Microsoft.AspNetCore.Identity;

namespace rabotyagi.DataAccess.Entities;

public class Role : IdentityRole<Guid>
{
    public List<User> Users { get; set; } = [];
}
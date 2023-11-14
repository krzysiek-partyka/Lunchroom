using Lunchroom.Domain.Entities;

namespace Lunchroom.Application.ApplicationUser;

public class CurrentUser
{
    public CurrentUser(string? id, string? email, IEnumerable<string> roles)
    {
        Id = id;

        Email = email;

        Roles = roles;
    }

    public string? Id { get; set; }
    public string? Email { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public bool IsInRole(Role role)
    {
        return Roles.Contains(role.ToString());
    }
}
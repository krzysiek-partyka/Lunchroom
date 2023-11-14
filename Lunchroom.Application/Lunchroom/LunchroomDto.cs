namespace Lunchroom.Application.Lunchroom;

public class LunchroomDto
{
    public int StudentId { get; set; }
    public string Name { get; set; } = default!;

    public string? Description { get; set; }
    public string? EncodedName { get; set; }
    public string? LunchPrice { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public bool IsEditable { get; set; }
    public DateTime LunchesUpdate { get; set; }
    public bool IsAutomaticLunchesEnabled { get; set; }
}
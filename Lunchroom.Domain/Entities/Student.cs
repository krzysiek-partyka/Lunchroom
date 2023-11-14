namespace Lunchroom.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public bool HasLunch { get; set; }
    public int NumberOfLunches { get; set; }
    public ClassroomName? ClassroomName { get; set; }
    public int? LunchroomId { get; set; }
    public Meal Lunchroom { get; set; } = default!;
}
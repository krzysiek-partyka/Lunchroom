using Lunchroom.Domain.Entities;

namespace Lunchroom.Application.Student;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NumberOfLunches { get; set; }
    public ClassroomName? ClassroomName { get; set; }
    public decimal LunchPrice { get; set; }
    public decimal Payment { get; set; }
    public string LunchroomEncodedName { get; set; }
}
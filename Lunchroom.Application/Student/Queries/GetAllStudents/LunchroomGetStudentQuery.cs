using MediatR;

namespace Lunchroom.Application.Student.Queries.GetAllStudents;

public class LunchroomGetStudentQuery : IRequest<IEnumerable<StudentDto>>
{
    public string EncodedName { get; set; } = default!;
}
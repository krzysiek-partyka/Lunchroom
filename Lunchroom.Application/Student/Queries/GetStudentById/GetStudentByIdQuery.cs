using MediatR;

namespace Lunchroom.Application.Student.Queries.GetStudentById;

public class GetStudentByIdQuery : IRequest<StudentDto>
{
    public int Id { get; set; }
    public string EncodedName { get; set; } = default!;
}
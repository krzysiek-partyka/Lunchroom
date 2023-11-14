using MediatR;


namespace Lunchroom.Application.Student.Commands.EditStudent;

public class EditStudentCommand : StudentDto, IRequest
{
    public int StudentId { get; set; }
    public string EncodedName { get; set; } = default!;
}
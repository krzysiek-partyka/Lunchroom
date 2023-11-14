using MediatR;

namespace Lunchroom.Application.Student.Commands.CreateStudent;

public class CreateStudentCommand : StudentDto, IRequest
{
}
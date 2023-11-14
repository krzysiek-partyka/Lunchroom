using MediatR;

namespace Lunchroom.Application.Student.Commands.RemoveLunch;

public class RemoveLunchCommand : StudentDto, IRequest
{
    public int Id { get; set; }
}
using MediatR;

namespace Lunchroom.Application.Student.Commands.AddLunch;

public class AddLunchCommand : StudentDto, IRequest
{
    public int Id { get; set; }
}
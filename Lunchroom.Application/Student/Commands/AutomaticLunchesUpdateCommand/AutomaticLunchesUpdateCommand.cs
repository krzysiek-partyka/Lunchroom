using MediatR;

namespace Lunchroom.Application.Student.Commands.AutomaticLunchesUpdateCommand;

public class AutomaticLunchesUpdateCommand : StudentDto, IRequest
{
    public string EncodedName { get; set; }
    public int AutomaticUpdateLunchValue { get; set; }
}
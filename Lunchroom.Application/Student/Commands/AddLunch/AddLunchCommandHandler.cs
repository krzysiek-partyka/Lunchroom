using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Commands.AddLunch;

public class AddLunchCommandHandler : IRequestHandler<AddLunchCommand>
{
    private readonly IStudentRepository _studentRepository;

    public AddLunchCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Unit> Handle(AddLunchCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetStudentById(request.Id);
        student.NumberOfLunches += 1;
        await _studentRepository.Commit();
        return Unit.Value;
    }
}
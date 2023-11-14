using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Commands.RemoveLunch;

public class RemoveLunchCommandHandler : IRequestHandler<RemoveLunchCommand>
{
    private readonly IStudentRepository _studentRepository;

    public RemoveLunchCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Unit> Handle(RemoveLunchCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetStudentById(request.Id);
        if (student == null) return Unit.Value;

        student.NumberOfLunches -= 1;

        await _studentRepository.Commit();

        return Unit.Value;
    }
}
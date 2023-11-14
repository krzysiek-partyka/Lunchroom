using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Interfaces;
using MediatR;


namespace Lunchroom.Application.Student.Commands.EditStudent;

public class EditStudentCommandHandler : IRequestHandler<EditStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUserContext _userContext;

    public EditStudentCommandHandler(IStudentRepository studentRepository, IUserContext userContext)
    {
        _studentRepository = studentRepository;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetStudentById(request.StudentId);

        var user = _userContext.GetCurrentUser();
        //var isEditable = user != null && (student.Lunchroom.CreatedById == user.Id || user.IsInRole("Moderator"));
        //if (!isEditable)
        //{
        //    return Unit.Value;
        //}
        var enumValue = (int)request.ClassroomName!;
        student.FirstName = request.FirstName;
        student.LastName = request.LastName;
        student.NumberOfLunches = request.NumberOfLunches;
        student.ClassroomName = (Domain.Entities.ClassroomName)enumValue;

        await _studentRepository.Commit();

        return Unit.Value;
    }
}
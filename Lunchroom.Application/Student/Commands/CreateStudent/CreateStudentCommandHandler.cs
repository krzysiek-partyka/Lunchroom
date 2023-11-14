using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Entities;
using Lunchroom.Domain.Interfaces;
using MediatR;


namespace Lunchroom.Application.Student.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly ILunchroomRepository _lunchroomRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUserContext _userContext;

    public CreateStudentCommandHandler(IStudentRepository studentRepository, IUserContext userContext, ILunchroomRepository lunchroomRepository)
    {
        _studentRepository = studentRepository;
        _userContext = userContext;
        _lunchroomRepository = lunchroomRepository;
    }

    public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var lunchroom = await _lunchroomRepository.GetMealByEncodedName(request.LunchroomEncodedName!);

        var user = _userContext.GetCurrentUser();
        var isEditable = user != null && (lunchroom.CreatedById == user.Id || user.IsInRole(Role.Moderator));
        if (!isEditable)
        {
            return Unit.Value;
        }


        var enumValue = (int)request.ClassroomName!;
        var student = new Domain.Entities.Student()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            ClassroomName = (Domain.Entities.ClassroomName)enumValue,
            LunchroomId = lunchroom.Id
        };

        await _studentRepository.CreateStudent(student);

        return Unit.Value;
    }
}
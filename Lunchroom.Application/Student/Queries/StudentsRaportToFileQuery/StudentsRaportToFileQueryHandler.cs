using AutoMapper;
using Lunchroom.Application.Services;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Queries.StudentsRaportToFileQuery;

public class StudentsRaportToFileQueryHandler : IRequestHandler<StudentsRaportToFileQuery>
{
    private readonly ILunchroomRepository _lunchroomRepository;
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentService _studentService;

    public StudentsRaportToFileQueryHandler(IStudentRepository studentRepository, IStudentService studentService,
        IMapper mapper, ILunchroomRepository lunchroomRepository)
    {
        _studentRepository = studentRepository;
        _studentService = studentService;
        _mapper = mapper;
        _lunchroomRepository = lunchroomRepository;
    }

    public async Task<Unit> Handle(StudentsRaportToFileQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetStudents();
        var lunchroom = await _lunchroomRepository.GetMealByEncodedName(request.EncodedName);

        var dtosWithPayment = _mapper.Map<IEnumerable<StudentDto>>(students)
            .Select(d =>
            {
                d.Payment = lunchroom.LunchPrice * d.NumberOfLunches;
                return d;
            });

        await _studentService.StudentsRaportToFile(dtosWithPayment, "Raport.txt");

        return Unit.Value;
    }
}
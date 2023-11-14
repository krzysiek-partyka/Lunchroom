using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Queries.CreateRaport;

public class CreateRaportQueryHandler : IRequestHandler<CreateRaportQuery, IEnumerable<StudentDto>>
{
    private readonly ILunchroomRepository _lunchroomRepository;
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public CreateRaportQueryHandler(IStudentRepository studentRepository, IMapper mapper, ILunchroomRepository lunchroomRepository)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _lunchroomRepository = lunchroomRepository;
    }

    public async Task<IEnumerable<StudentDto>> Handle(CreateRaportQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetStudents();
        var lunchroom = await _lunchroomRepository.GetMealByEncodedName(request.EncodedName);

        var dtosWithPayment = _mapper.Map<IEnumerable<StudentDto>>(students)
            .Select(d =>
            {
                d.Payment = lunchroom.LunchPrice * d.NumberOfLunches;
                return d;
            });

        return dtosWithPayment;
    }
}
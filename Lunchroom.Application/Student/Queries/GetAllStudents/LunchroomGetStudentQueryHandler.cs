using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Queries.GetAllStudents;

public class LunchroomGetStudentQueryHandler : IRequestHandler<LunchroomGetStudentQuery, IEnumerable<StudentDto>>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public LunchroomGetStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> Handle(LunchroomGetStudentQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetStudentsByLunchroomEncodedName(request.EncodedName);
        return _mapper.Map<IEnumerable<StudentDto>>(students);
        ;
    }
}
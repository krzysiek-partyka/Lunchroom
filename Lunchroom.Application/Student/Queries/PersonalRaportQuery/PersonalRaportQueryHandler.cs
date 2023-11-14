using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Queries.PersonalRaportQuery;

public class PersonalRaportQueryHandler : IRequestHandler<PersonalRaportQuery, StudentDto>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public PersonalRaportQueryHandler(IMapper mapper, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(PersonalRaportQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetStudentById(request.Id);
        return _mapper.Map<StudentDto>(student);
    }
}
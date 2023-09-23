using AutoMapper;
using Lunchroom.Application.Services;
using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.StudentsRaportToFileQuery
{
    public  class StudentsRaportToFileQueryHandler : IRequestHandler<StudentsRaportToFileQuery>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly ILunchroomRepository _lunchroomRepository;

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
            var lunchroom = await _lunchroomRepository.GetStudentByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            var dtosWitchPayment = dtos.Select(d =>
            {
                d.Payment = lunchroom.LunchPrice * d.NumberOfLunches;
                return d;
            });

            await _studentService.StudentsRaportToFile(dtosWitchPayment, $"Raport.txt");

            return Unit.Value;
        }
    }
}

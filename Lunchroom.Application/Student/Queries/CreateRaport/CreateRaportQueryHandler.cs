using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.CreateRaport
{
    public class CreateRaportQueryHandler : IRequestHandler<CreateRaportQuery, IEnumerable<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILunchroomRepository _lunchroomRepository;

        public CreateRaportQueryHandler(IStudentRepository studentRepository, IMapper mapper, ILunchroomRepository lunchroomRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _lunchroomRepository = lunchroomRepository;
        }

        public async Task<IEnumerable<StudentDto>> Handle(CreateRaportQuery request, CancellationToken cancellationToken)
        {
            
            var students = await _studentRepository.GetStudents();
            var lunchroom = await _lunchroomRepository.GetByEncodedName(request.EncodedName);
            
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            var dtosWitchPayment = dtos.Select(d =>
            {
                d.Payment = lunchroom.LunchPrice * d.NumberOfLunches;
                return d;
            });

            return dtosWitchPayment;

            
        }
    }
}

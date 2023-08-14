using AutoMapper;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Domain.Entities.Student>(request);
            
            
            await _studentRepository.Create(student);
            return Unit.Value;
        }
    }
}

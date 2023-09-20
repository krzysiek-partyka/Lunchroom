using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Commands.AutomaticLunchesUpdateCommand
{
    public class AutomaticLunchesUpdateCommandHandler : IRequestHandler<AutomaticLunchesUpdateCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public AutomaticLunchesUpdateCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(AutomaticLunchesUpdateCommand request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetStudentsByLunchroomEncodedName(request.EncodedName);
            var studentsWithUpdatedLunches = students.Select(s =>
            {
                s.NumberOfLunches += 1;
            });

            return Unit.Value;
        }
    }
}

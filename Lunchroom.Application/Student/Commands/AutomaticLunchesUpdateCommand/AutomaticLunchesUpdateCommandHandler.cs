using AutoMapper;
using Lunchroom.Application.Lunchroom;
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
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;

        public AutomaticLunchesUpdateCommandHandler(IStudentRepository studentRepository, ILunchroomRepository lunchroomRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AutomaticLunchesUpdateCommand request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetStudentsByLunchroomEncodedName(request.EncodedName);
            var lunchroom = await _lunchroomRepository.GetStudentByEncodedName(request.EncodedName);
            var lunchromDto = _mapper.Map<LunchroomDto>(lunchroom);
            

            var timeByMinuts = DateTime.Now.TimeOfDay;

            while (true)
            {
                lunchromDto.IsAutomaticLunchesEnabled = Convert.ToBoolean(request.AutomaticUpdateLunchValue);
                timeByMinuts = DateTime.Now.TimeOfDay;

                if (!lunchromDto.IsAutomaticLunchesEnabled)
                {
                    break; 
                }

                await Task.Delay(TimeSpan.FromMinutes(1));
            }

            if (lunchroom.LunchesUpdate.TimeOfDay == DateTime.Now.TimeOfDay)
            {
                foreach (var student in students)
                {
                    student.NumberOfLunches += 1;
                }
            }

            return Unit.Value;
        }
    }
}

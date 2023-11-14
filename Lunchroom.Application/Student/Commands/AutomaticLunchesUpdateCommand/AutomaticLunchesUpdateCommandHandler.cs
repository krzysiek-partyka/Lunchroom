using AutoMapper;
using Lunchroom.Application.Lunchroom;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Student.Commands.AutomaticLunchesUpdateCommand;

public class AutomaticLunchesUpdateCommandHandler : IRequestHandler<AutomaticLunchesUpdateCommand>
{
    private readonly ILunchroomRepository _lunchroomRepository;
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

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
        var lunchroom = await _lunchroomRepository.GetMealByEncodedName(request.EncodedName);
        var lunchroomDto = _mapper.Map<LunchroomDto>(lunchroom);


        while (true)
        {
            lunchroomDto.IsAutomaticLunchesEnabled = Convert.ToBoolean(request.AutomaticUpdateLunchValue);

            if (!lunchroomDto.IsAutomaticLunchesEnabled) break;

            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
        }

        if (lunchroom.LunchesUpdate.TimeOfDay == DateTime.Now.TimeOfDay)
            foreach (var student in students)
                student.NumberOfLunches += 1;

        return Unit.Value;
    }
}
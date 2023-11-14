using AutoMapper;
using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Entities;
using Lunchroom.Domain.Interfaces;
using MediatR;


namespace Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;

public class CreateLunchroomCommandHandler : IRequestHandler<CreateLunchroomCommand>
{
    private readonly ILunchroomRepository _lunchroomRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public CreateLunchroomCommandHandler(ILunchroomRepository lunchroomRepository, IMapper mapper, IUserContext userContext)
    {
        _lunchroomRepository = lunchroomRepository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(CreateLunchroomCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        if (currentUser is null || !currentUser.IsInRole(Role.Moderator))
        {
            return Unit.Value;
        }

        var lunchroom = _mapper.Map<Meal>(request);
        lunchroom.EncodeName();
        lunchroom.CreatedById = currentUser.Id;
        await _lunchroomRepository.CreateMeal(lunchroom);
        return Unit.Value;
    }
}
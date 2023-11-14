using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Entities;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Lunchroom.Commands.EditLunchroom;

public class EditLunchroomCommandHandler : IRequestHandler<EditLunchroomCommand>
{
    private readonly ILunchroomRepository _lunchroomRepository;
    private readonly IUserContext _userContext;

    public EditLunchroomCommandHandler(ILunchroomRepository lunchroomRepository, IUserContext userContext)
    {
        _lunchroomRepository = lunchroomRepository;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(EditLunchroomCommand request, CancellationToken cancellationToken)
    {
        var lunchroom = await _lunchroomRepository.GetMealByEncodedName(request.EncodedName!);

        var user = _userContext.GetCurrentUser();
        var isEditable = user != null && (lunchroom.CreatedById == user.Id || user.IsInRole(Role.Moderator));
        if (!isEditable)
        {
            return Unit.Value;
        }

        lunchroom.Description = request.Description;
        lunchroom.LunchPrice = decimal.Parse(request.LunchPrice);
        lunchroom.ContactDetails.Phone = request.Phone;
        lunchroom.ContactDetails.PostalCode = request.PostalCode;
        lunchroom.ContactDetails.City = request.City;
        lunchroom.ContactDetails.Street = request.Street;
        await _lunchroomRepository.Commit();

        return Unit.Value;
    }
}
using AutoMapper;
using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Commands.EditLunchroom
{
    public class EditLunchroomCommandHandler : IRequestHandler<EditLunchroomCommand>
    {
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public EditLunchroomCommandHandler(ILunchroomRepository lunchroomRepository, IMapper mapper,IUserContext userContext)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditLunchroomCommand request, CancellationToken cancellationToken)
        {
            var lunchroom = await _lunchroomRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (lunchroom.CreatedById == user.Id || user.IsInRole("Moderator"));
            if (!isEditable)
            {
                return Unit.Value;
            }
            lunchroom.Description = request.Description;
            lunchroom.ContactDetails.Phone = request.Phone;
            lunchroom.ContactDetails.PostalCode = request.PostalCode;
            lunchroom.ContactDetails.City = request.City;
            lunchroom.ContactDetails.Street = request.Street;
            await  _lunchroomRepository.Commit();

            return Unit.Value;
        }
    }
}

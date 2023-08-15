using AutoMapper;
using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Commands.CreateLunchroom
{
    public class CreateLunchroomCommandHandler : IRequestHandler<CreateLunchroomCommand>
    {
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateLunchroomCommandHandler(ILunchroomRepository lunchroomRepository,IMapper mapper, IUserContext userContext)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateLunchroomCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var lunchroom = _mapper.Map<Domain.Entities.Lunchroom>(request);
            lunchroom.EncodeName();
            lunchroom.CreatedById = currentUser.Id;
            await _lunchroomRepository.Create(lunchroom);
            return Unit.Value;
        }
    }
}

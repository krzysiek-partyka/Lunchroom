using AutoMapper;
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

        public CreateLunchroomCommandHandler(ILunchroomRepository lunchroomRepository,IMapper mapper)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateLunchroomCommand request, CancellationToken cancellationToken)
        {
            var lunchroom = _mapper.Map<Domain.Entities.Lunchroom>(request);
            lunchroom.EncodeName();
            await _lunchroomRepository.Create(lunchroom);
            return Unit.Value;
        }
    }
}

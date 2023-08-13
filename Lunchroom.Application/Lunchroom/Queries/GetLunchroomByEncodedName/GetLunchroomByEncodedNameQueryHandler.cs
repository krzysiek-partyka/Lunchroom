using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Queries.GetLunchroomByEncodedName
{

    public class GetLunchroomByEncodedNameQueryHandler : IRequestHandler<GetLunchroomByEncodedNameQuery, LunchroomDto>
    {
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;

        public GetLunchroomByEncodedNameQueryHandler(ILunchroomRepository lunchroomRepository, IMapper mapper)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
        }
        public async Task<LunchroomDto> Handle(GetLunchroomByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var lunchroom = await _lunchroomRepository.GetByEncodedName(request.EncodedName);   
            var dto = _mapper.Map<LunchroomDto>(lunchroom);
            return dto;
        }
    }
}

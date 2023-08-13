using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms
{
    public class GetAllLunchroomsQueryHandler : IRequestHandler<GetAllLunchroomsQuery, IEnumerable<LunchroomDto>>
    {
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;

        public GetAllLunchroomsQueryHandler(ILunchroomRepository lunchroomRepository, IMapper mapper)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LunchroomDto>> Handle(GetAllLunchroomsQuery request, CancellationToken cancellationToken)
        {
            var lunchrooms = await _lunchroomRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<LunchroomDto>>(lunchrooms);
            return dtos;
        }
    }
}

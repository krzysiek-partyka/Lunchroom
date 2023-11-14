using AutoMapper;
using Lunchroom.Domain.Interfaces;
using MediatR;

namespace Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms;

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
        var lunchrooms = await _lunchroomRepository.GetAllMeals();
        return _mapper.Map<IEnumerable<LunchroomDto>>(lunchrooms);
        ;
    }
}
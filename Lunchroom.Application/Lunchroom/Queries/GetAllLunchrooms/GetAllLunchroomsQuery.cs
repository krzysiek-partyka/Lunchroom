using MediatR;

namespace Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms
{
    public class GetAllLunchroomsQuery : IRequest<IEnumerable<LunchroomDto>>
    {
    }
}
using MediatR;

namespace Lunchroom.Application.Lunchroom.Queries.GetLunchroomByEncodedName;

public class GetLunchroomByEncodedNameQuery : IRequest<LunchroomDto>
{
    public GetLunchroomByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }

    public string EncodedName { get; set; }
}
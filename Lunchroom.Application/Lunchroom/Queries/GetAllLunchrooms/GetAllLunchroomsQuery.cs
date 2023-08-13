using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms
{
    public class GetAllLunchroomsQuery : IRequest<IEnumerable<LunchroomDto>>
    {
    }
}

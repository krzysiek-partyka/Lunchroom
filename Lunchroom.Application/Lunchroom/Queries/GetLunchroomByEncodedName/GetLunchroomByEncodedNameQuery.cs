using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Queries.GetLunchroomByEncodedName
{
    public class GetLunchroomByEncodedNameQuery : IRequest<LunchroomDto>
    {
        public string EncodedName { get; set; }
        public GetLunchroomByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.CreateRaport
{
    public class CreateRaportQuery : IRequest<IEnumerable<StudentDto>>
    {
        public string EncodedName { get; set; }

        public CreateRaportQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}

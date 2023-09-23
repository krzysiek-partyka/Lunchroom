using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.StudentsRaportToFileQuery
{
    public class StudentsRaportToFileQuery : StudentDto, IRequest
    {
        public string EncodedName { get; set; }
        public StudentsRaportToFileQuery(string encodedName)
        {

            EncodedName = encodedName;

        }
    }
}

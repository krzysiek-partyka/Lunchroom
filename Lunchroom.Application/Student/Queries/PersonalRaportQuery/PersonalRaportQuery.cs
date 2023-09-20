using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.PersonalRaportQuery
{
    public class PersonalRaportQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
        public string EncodedName { get; set; }
        public PersonalRaportQuery(string encodedName, int id)
        {
            Id = id;   
            EncodedName = encodedName;
        }
    }
}

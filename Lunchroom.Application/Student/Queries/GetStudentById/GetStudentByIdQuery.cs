using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
        public string EncodedName { get; set; } = default!;
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Commands.EditStudent
{
    public class EditStudentCommand : StudentDto, IRequest
    {
        public int StudentId { get; set; }
        public string EncodedName { get; set; } = default!;
    }
}

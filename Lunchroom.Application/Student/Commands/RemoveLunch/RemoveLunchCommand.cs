using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Commands.RemoveLunch
{
    public class RemoveLunchCommand : StudentDto, IRequest
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Commands.AutomaticLunchesUpdateCommand
{
    public class AutomaticLunchesUpdateCommand : StudentDto, IRequest
    {
        public string EncodedName { get; set; }
        public int AutomaticUpdateLunchValue { get; set; }
    }
}

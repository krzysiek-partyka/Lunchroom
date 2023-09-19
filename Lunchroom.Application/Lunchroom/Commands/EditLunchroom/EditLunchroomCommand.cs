using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom.Commands.EditLunchroom
{
    public class EditLunchroomCommand : LunchroomDto, IRequest
    {
        public int Id { get; set; }
    }
}

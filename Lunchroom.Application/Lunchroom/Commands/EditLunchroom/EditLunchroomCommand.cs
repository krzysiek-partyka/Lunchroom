using MediatR;

namespace Lunchroom.Application.Lunchroom.Commands.EditLunchroom;

public class EditLunchroomCommand : LunchroomDto, IRequest
{
    public int Id { get; set; }
}
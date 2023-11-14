using MediatR;

namespace Lunchroom.Application.Student.Queries.PersonalRaportQuery;

public class PersonalRaportQuery : IRequest<StudentDto>
{
    public PersonalRaportQuery(string encodedName, int id)
    {
        Id = id;
        EncodedName = encodedName;
    }

    public int Id { get; set; }
    public string EncodedName { get; set; }
}
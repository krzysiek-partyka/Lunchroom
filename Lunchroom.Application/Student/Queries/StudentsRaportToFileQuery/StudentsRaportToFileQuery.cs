using MediatR;

namespace Lunchroom.Application.Student.Queries.StudentsRaportToFileQuery;

public class StudentsRaportToFileQuery : StudentDto, IRequest
{
    public StudentsRaportToFileQuery(string encodedName)
    {
        EncodedName = encodedName;
    }

    public string EncodedName { get; set; }
}
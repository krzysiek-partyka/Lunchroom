using MediatR;

namespace Lunchroom.Application.Student.Queries.CreateRaport
{
    public class CreateRaportQuery : IRequest<IEnumerable<StudentDto>>
    {
        public CreateRaportQuery(string encodedName)
        {
            EncodedName = encodedName;
        }

        public string EncodedName { get; set; }
    }
}
using Lunchroom.Application.Student;

namespace Lunchroom.Application.Services;

public interface IStudentService
{
    Task StudentsRaportToFile(IEnumerable<StudentDto> students, string path);
}

public class StudentService : IStudentService
{
    public async Task StudentsRaportToFile(IEnumerable<StudentDto> students, string path)
    {
        await using var writer = new StreamWriter(path);

        await writer.WriteLineAsync("Firstname, Lastname, Lunches number, Payment");
        foreach (var student in students)
        {
            var studentLine = student.FirstName + student.LastName.PadLeft(10) + student.Payment.ToString().PadLeft(10);
            await writer.WriteLineAsync(studentLine);
        }
    }
}
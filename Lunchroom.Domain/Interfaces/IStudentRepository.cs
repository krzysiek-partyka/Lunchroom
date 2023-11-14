using Lunchroom.Domain.Entities;

namespace Lunchroom.Domain.Interfaces;

public interface IStudentRepository
{
    Task CreateStudent(Student student);
    Task<IEnumerable<Student>> GetStudentsByLunchroomEncodedName(string encodedName);
    Task<Student?> GetStudentById(int id);
    Task Commit();
    Task<IEnumerable<Student>> GetStudents();
}
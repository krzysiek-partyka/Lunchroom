using Lunchroom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Domain.Interfaces
{
    public  interface IStudentRepository
    {
        Task CreateStudent(Student student);
        Task<IEnumerable<Student>> GetStudentsByEncodedName(string encodedName);
        Task<Student> GetStudentById(int id);
        Task Commit();
        Task<IEnumerable<Student>> GetStudents();

    }
}

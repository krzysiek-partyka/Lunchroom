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
        Task Commit();
        Task Create(Student student);
        Task<IEnumerable<Student>> GetAll(string encodeName);
    }
}

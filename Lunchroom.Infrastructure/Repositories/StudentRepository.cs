using Lunchroom.Domain.Entities;
using Lunchroom.Domain.Interfaces;
using Lunchroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly LunchroomDbContext _dbContext;

        public StudentRepository(LunchroomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }


        public async Task Create(Student student)
        {
            _dbContext.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll(string encodeName) =>
            await _dbContext.Students.ToListAsync();
    }
}

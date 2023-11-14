using Lunchroom.Domain.Entities;
using Lunchroom.Domain.Interfaces;
using Lunchroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lunchroom.Infrastructure.Repositories;

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

    public async Task CreateStudent(Student student)
    {
        _dbContext.Add(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Student> GetStudentById(int id)
    {
        return await _dbContext.Students.FirstAsync(s => s.Id == id);
    }

    public Task<IEnumerable<Student>> GetStudentsByLunchroomEncodedName(string encodedName)
    {
        return Task.FromResult<IEnumerable<Student>>(_dbContext.Students
            .Where(s => s.Lunchroom.EncodedName == encodedName));
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _dbContext.Students.ToListAsync();
    }
}
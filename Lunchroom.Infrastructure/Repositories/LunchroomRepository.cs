using Lunchroom.Domain.Entities;
using Lunchroom.Domain.Interfaces;
using Lunchroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lunchroom.Infrastructure.Repositories;

public class LunchroomRepository : ILunchroomRepository
{
    private readonly LunchroomDbContext _dbContext;

    public LunchroomRepository(LunchroomDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateMeal(Meal lunchroom)
    {
        _dbContext.Add(lunchroom);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Meal>> GetAllMeals()
    {
        return await _dbContext.Lunchrooms.ToListAsync();
    }

    public async Task<Meal> GetMealByEncodedName(string encodedName)
    {
        return await _dbContext.Lunchrooms.FirstAsync(l => l.EncodedName == encodedName);
    }

    public async Task<Meal?> GetMealByName(string name)
    {
        return await _dbContext.Lunchrooms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }

    public async Task<Meal> Edit(Meal lunchroom, string encodedName)
    {
        return await _dbContext.Lunchrooms.FirstAsync(l => l.Name == encodedName);
    }
}
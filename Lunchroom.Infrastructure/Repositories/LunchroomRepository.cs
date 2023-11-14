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

    public async Task Commit() =>
        await _dbContext.SaveChangesAsync();

    public async Task CreateMeal(Domain.Entities.Meal lunchroom)
    {
        _dbContext.Add(lunchroom);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Domain.Entities.Meal>> GetAllMeals() =>
        await _dbContext.Lunchrooms.ToListAsync();

    public async Task<Domain.Entities.Meal> GetMealByEncodedName(string encodedName) =>
        await _dbContext.Lunchrooms.FirstAsync(l => l.EncodedName == encodedName);

    public async Task<Domain.Entities.Meal?> GetMealByName(string name) =>
        await _dbContext.Lunchrooms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

    public async Task<Domain.Entities.Meal> Edit(Domain.Entities.Meal lunchroom, string encodedName) =>
        await _dbContext.Lunchrooms.FirstAsync(l => l.Name == encodedName);
}
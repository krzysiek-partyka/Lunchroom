using Lunchroom.Infrastructure.Persistence;

namespace Lunchroom.Infrastructure.Seeders;

public class LunchroomSeeder
{
    private readonly LunchroomDbContext _dbContext;

    public LunchroomSeeder(LunchroomDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (!_dbContext.Lunchrooms.Any())
            {
                var schoolLunchroom = new Domain.Entities.Meal()
                {
                    Name = "Stołowka Szkolna",
                    Description = "Stołow ka przy szkole nr 12 w Olsztynie",
                    ContactDetails = new()
                    {
                        City = "Olsztyn",
                        Street = "Poznańska 23",
                        PostalCode = "10-117",
                        Phone = "+486255154"
                    }
                };
                schoolLunchroom.EncodeName();
                _dbContext.Add(schoolLunchroom);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
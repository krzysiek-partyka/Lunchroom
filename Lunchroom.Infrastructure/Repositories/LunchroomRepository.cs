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
    public class LunchroomRepository : ILunchroomRepository
    {
        private readonly LunchroomDbContext _dbContext;

        public LunchroomRepository(LunchroomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() =>
            await _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Meal lunchroom)
        {
            _dbContext.Add(lunchroom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Meal> Edit(Domain.Entities.Meal lunchroom, string encodedName) =>
            await _dbContext.Lunchrooms.FirstAsync(l => l.Name == encodedName);

        public async Task<IEnumerable<Domain.Entities.Meal>> GetAll() =>
            await _dbContext.Lunchrooms.ToListAsync();

        public async Task<Domain.Entities.Meal> GetByEncodedName(string encodedName) =>
            await _dbContext.Lunchrooms.FirstAsync(l => l.EncodedName == encodedName);

        public async Task<Domain.Entities.Meal?> GetName(string name) =>
        
            await _dbContext.Lunchrooms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
        
    }
}

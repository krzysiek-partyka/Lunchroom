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

        public async Task Create(Domain.Entities.Lunchroom lunchroom)
        {
            _dbContext.Add(lunchroom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Lunchroom> Edit(Domain.Entities.Lunchroom lunchroom, string encodedName) =>
            await _dbContext.Lunchrooms.FirstAsync(l => l.Name == encodedName);

        public async Task<IEnumerable<Domain.Entities.Lunchroom>> GetAll() =>
            await _dbContext.Lunchrooms.ToListAsync();

        public async Task<Domain.Entities.Lunchroom> GetByEncodedName(string encodedName) =>
            await _dbContext.Lunchrooms.FirstAsync(l => l.EncodedName == encodedName);

        public async Task<Domain.Entities.Lunchroom?> GetName(string name) =>
        
            await _dbContext.Lunchrooms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
        
    }
}

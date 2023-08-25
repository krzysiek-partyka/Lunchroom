using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Domain.Interfaces
{
    public interface ILunchroomRepository
    {
        Task Create(Domain.Entities.Meal lunchroom);
        Task<IEnumerable<Domain.Entities.Meal>> GetAll();
        Task<Domain.Entities.Meal?> GetName(string name);
        Task<Domain.Entities.Meal> GetByEncodedName(string encodedName);
        Task<Domain.Entities.Meal> Edit(Domain.Entities.Meal lunchroom, string encodedName);
        Task Commit();
    }
}

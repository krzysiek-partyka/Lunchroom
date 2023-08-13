using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Domain.Interfaces
{
    public interface ILunchroomRepository
    {
        Task Create(Domain.Entities.Lunchroom lunchroom);
        Task<IEnumerable<Domain.Entities.Lunchroom>> GetAll();
        Task<Domain.Entities.Lunchroom?> GetName(string name);
        Task<Domain.Entities.Lunchroom> GetByEncodedName(string encodedName);
        Task<Domain.Entities.Lunchroom> Edit(Domain.Entities.Lunchroom lunchroom, string encodedName);
        Task Commit();
    }
}

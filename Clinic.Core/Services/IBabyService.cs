using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IBabyService
    {
         Task<IEnumerable<Baby>> GetAllAsync();

        Baby GetById(int id);

        Task<Baby> PostBabyAsync(Baby newBaby);

        Task<Baby> PutBabyAsync(int id, Baby baby);

        Task DeleteBabyAsync(int id);
    }
}

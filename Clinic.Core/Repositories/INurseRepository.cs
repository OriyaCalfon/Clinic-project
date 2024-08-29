using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface INurseRepository
    {
        Task<IEnumerable<Nurse>> GetAllAsync();

        Nurse GetById(int id);

        Task<Nurse> PostNurseAsync(Nurse newNurse);

        Task<Nurse> PutNurseAsync(int id, Nurse nurse);

        Task DeleteNurseAsync(int id);
    }
}

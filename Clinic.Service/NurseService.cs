using Clinic.Core.Models;
using Clinic.Core.Repositories;
using Clinic.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service
{
    public class NurseService: INurseService
    {
        private readonly INurseRepository _nurseRepository;
        public NurseService(INurseRepository nursrRepository)
        {
            _nurseRepository = nursrRepository;
        }

        public async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            return await _nurseRepository.GetAllAsync();
        }


        public Nurse GetById(int id)
        {
            return _nurseRepository.GetById(id);
        }


        public async Task<Nurse> PostNurseAsync(Nurse newNurse)
        {
           return await _nurseRepository.PostNurseAsync(newNurse);
        }


        public async Task<Nurse> PutNurseAsync(int id, Nurse nurse)
        {
           return await _nurseRepository.PutNurseAsync(id, nurse);
        }


        public async Task DeleteNurseAsync(int id)
        {
            _nurseRepository.DeleteNurseAsync(id);
        }
    }
}

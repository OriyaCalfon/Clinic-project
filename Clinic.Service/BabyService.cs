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
    public class BabyService: IBabyService
    {
        private readonly IBabyRepository _babyRepository;

        public BabyService(IBabyRepository babyRepository)
        {
            _babyRepository = babyRepository;
        }

        public async Task<IEnumerable<Baby>> GetAllAsync()
        {
            return await _babyRepository.GetAllAsync();
        }


        public Baby GetById(int id)
        {
            return _babyRepository.GetById(id);
        }


        public async Task<Baby> PostBabyAsync(Baby newBaby)
        {
           return await _babyRepository.PostBabyAsync(newBaby);
        }

        public async Task<Baby> PutBabyAsync(int id, Baby baby)
        {
          return await _babyRepository.PutBabyAsync(id, baby);
        }

        public async Task DeleteBabyAsync(int id)
        {
            _babyRepository.DeleteBabyAsync(id);
        }

       
    }
}

using Clinic.Core.Models;
using Clinic.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Repositories
{
    public class NurseRepository: INurseRepository
    {
        private readonly DataContext _context;

        public NurseRepository(DataContext context)
        {
            _context = context;
        }

       

        public async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            //return await _context.Nurses.Include(n=>n).ToListAsync();????
            return await _context.Nurses.ToListAsync();
        }

        public Nurse GetById(int id)
        {
            return _context.Nurses.Find(id);
        }



        public async Task<Nurse> PostNurseAsync(Nurse newNurse)
        {
            _context.Nurses.Add(newNurse);
            await _context.SaveChangesAsync();
            return newNurse;
        }

      
        public async Task<Nurse> PutNurseAsync(int id, Nurse nurse)
        {
            var existNurse = GetById(id);
            existNurse.Name = nurse.Name;
            existNurse.PhoneNumber = nurse.PhoneNumber;
            existNurse.Salary=nurse.Salary;
            await _context.SaveChangesAsync();
            return existNurse;
        }

        public async Task DeleteNurseAsync(int id)
        {
            var nurse = GetById(id);
            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();
        }
    }
}

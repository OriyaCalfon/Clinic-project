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
    public class BabyRepository: IBabyRepository
    {
        private readonly DataContext _context;
        public BabyRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Baby>> GetAllAsync()
        {
            //return await _context.Babys.Include(b=>b).ToListAsync();????
            return await _context.Babys.ToListAsync();
        }


        public Baby GetById(int id)
        {
            return _context.Babys.Find(id);
        }


        public async Task<Baby> PostBabyAsync(Baby newBaby)
        {
            _context.Babys.Add(newBaby);
            await _context.SaveChangesAsync();
            return newBaby;
        }


        public async Task<Baby> PutBabyAsync(int id, Baby baby)
        {
            var existBaby = GetById(id);
            existBaby.Name= baby.Name;
            existBaby.Age= baby.Age;
           await _context.SaveChangesAsync();
            return existBaby;
        }
       

        //מה עדיף להחזיר TASK או VOID???
         public async Task DeleteBabyAsync(int id)
        {
            var baby= GetById(id);
            _context.Babys.Remove(baby);
           await _context.SaveChangesAsync();
        }





    }
}

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
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly DataContext _context;
        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }


        
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.Include(a => a.Baby).Include(a => a.Nurse).ToListAsync();
        }


        public Appointment GetById(int id)
        {
            return _context.Appointments.Find(id);
        }


        public async Task<Appointment> PostAppointmentAsync(Appointment newAppointment)
        {
            _context.Appointments.Add(newAppointment);
            await _context.SaveChangesAsync();
            return newAppointment;
        }



        public async Task<Appointment> PutAppointmentAsync(int id, Appointment appointment)
        {
            var existAppointment = GetById(id);
            existAppointment.Title = appointment.Title;
            existAppointment.Hour=appointment.Hour;
            existAppointment.Day = appointment.Day;
            await _context.SaveChangesAsync();
            return existAppointment;
        }


        public async Task DeleteAppointmentAsync(int id)
        {
            var appintment = GetById(id);
            _context.Appointments.Remove(appintment);
            await _context.SaveChangesAsync();
        }
    }
}

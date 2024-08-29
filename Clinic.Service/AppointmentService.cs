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
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

       
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public async Task<Appointment> PostAppointmentAsync(Appointment newAppointment)
        {
           return await _appointmentRepository.PostAppointmentAsync(newAppointment);
        }

        public async Task<Appointment> PutAppointmentAsync(int id, Appointment appointment)
        {
           return await _appointmentRepository.PutAppointmentAsync(id, appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            _appointmentRepository.DeleteAppointmentAsync(id);
        }
    }
}

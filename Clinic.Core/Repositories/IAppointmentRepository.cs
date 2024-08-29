using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IAppointmentRepository
    {

        Task<IEnumerable<Appointment>> GetAllAsync();

        Appointment GetById(int id);

        Task<Appointment> PostAppointmentAsync(Appointment newAppointment);

        Task<Appointment> PutAppointmentAsync(int id, Appointment appointment);

        Task DeleteAppointmentAsync(int id);
    }
}

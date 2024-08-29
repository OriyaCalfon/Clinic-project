using Clinic.Core.DTOs;
using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clinic.Core
{
    public class Mapping
    {
        public BabyDto MapToBabyDto(Baby baby)
        {
            return new BabyDto { Id = baby.Id, Age = baby.Age, Name = baby.Name };
        }

        public AppointmentDto MapToAppointmentDto(Appointment appointment)
        {
            return new AppointmentDto {Id=appointment.Id, Day=appointment.Day, Hour=appointment.Hour,
                Title=appointment.Title, BabyId=appointment.BabyId, NurseId=appointment.NurseId};
        }


    }
}

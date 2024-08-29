using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Hour { get; set; }

        public int Day { get; set; }


        public int BabyId { get; set; }
        public int NurseId { get; set; }

      
        public BabyDto Baby { get; set; }
        public NurseDto Nurse { get; set; }
    }
}

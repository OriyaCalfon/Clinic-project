using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Hour { get; set; }

        public int Day { get; set; }


        public int BabyId { get; set; }
        public int NurseId { get; set; }

        //
        public Baby Baby { get; set; }
        public Nurse Nurse { get; set; }

        //public DateTime Date { get; set; }
    }
}

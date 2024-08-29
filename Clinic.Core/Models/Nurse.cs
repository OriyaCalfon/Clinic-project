using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Models
{
    public class Nurse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; } 
        public string PhoneNumber { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}

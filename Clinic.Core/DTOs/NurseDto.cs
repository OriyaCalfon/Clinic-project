using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class NurseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyclinic.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public override string ToString()
        {
            return Name;
        }
    }
}

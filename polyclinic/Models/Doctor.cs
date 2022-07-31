using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyclinic.Models
{
    public class Doctor : Employee
    {
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}

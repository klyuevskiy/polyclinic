using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyclinic.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string FIO { get; set; } = "";

        public override string ToString()
        {
            return FIO;
        }
    }
}

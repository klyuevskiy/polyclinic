using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyclinic.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FIO { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        public override string ToString()
        {
            return FIO;
        }
    }
}

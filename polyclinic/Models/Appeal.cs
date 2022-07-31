using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyclinic.Models
{
    public class Appeal
    {
        public int Id { get; set; }
        
        public Patient Patient { get; set; } = new Patient();
        public Operator? Operator { get; set; }
        public Department? Department { get; set; } = null;
        public Doctor? Doctor { get; set; } = null;

        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public string Anamnesis { get; set; } = "";
        public string DoctorDisease { get; set; } = "";

        public Appeal()
        {
            Operator = null;
        }

        public Appeal(Operator op)
        {
            Operator = op;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Appeal : BaseModel
    {
        [Required]
        public virtual Patient Patient { get; set; }

        [Required]
        public virtual Operator Operator { get; set; }

        [Required]
        public virtual Department Department { get; set; } = null;

        [Required]
        public virtual Doctor Doctor { get; set; } = null;

        [Required]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        [Required]
        public string Anamnesis { get; set; } = "";

        [Required]
        public string DoctorDisease { get; set; } = "";

        public Appeal()
        {
            Operator = null;
        }

        public Appeal(Operator op)
        {
            Operator = op;
            Patient = new Patient();
        }
    }
}

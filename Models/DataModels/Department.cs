using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Department : BaseModel
    {
        [Required]
        public string Name { get; set; } = "";

        public virtual ICollection<Doctor> Doctors { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Department
    {
        // автоматически определится первичным ключём
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public virtual ICollection<Doctor> Doctors { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

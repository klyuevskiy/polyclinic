using System.Collections.Generic;

namespace Models.DataModels
{
    public class Doctor : Employee
    {
        public virtual ICollection<Department> Departments { get; set; }
    }
}

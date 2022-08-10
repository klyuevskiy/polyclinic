using Models.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Models.DataAccess
{
    public class DepartmentDAL : BaseDAL
    {
        public static IEnumerable<Department> GetHaveDoctors()
        {
            return DataBase.Departments
                .Where(d => d.Doctors.Count > 0);
        }
    }
}

using Models.DataModels;

namespace Models.DataAccess
{
    public class EmployeeDAL : BaseDAL
    {
        public static Employee Get(string login, string password)
        {
            password = PasswordHash.ComputeHash(password);

            Employee employee = OperatorDAL.Get(login, password);

            if (employee == null)
                employee = DoctorDAL.Get(login, password);

            return employee;
        }
    }
}

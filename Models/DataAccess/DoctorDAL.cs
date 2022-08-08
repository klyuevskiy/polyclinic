using Models.DataModels;
using System.Linq;

namespace Models.DataAccess
{
    public class DoctorDAL : BaseDAL
    {
        public static Doctor Get(string login, string passwordHash)
        {
            return DataBase.Doctors.FirstOrDefault(doc =>
            doc.Login == login && doc.Password == passwordHash);
        }
    }
}

using Models.DataModels;
using System.Linq;

namespace Models.DataAccess
{
    public class OperatorDAL : BaseDAL
    {
        public static Operator Get(string login, string passwordHash)
        {
            return DataBase.Operators.FirstOrDefault(op =>
            op.Login == login && op.Password == passwordHash);
        }
    }
}

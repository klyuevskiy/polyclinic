namespace Models.DataAccess
{
    public class BaseDAL
    {
        internal static AppContext DataBase { get; set; } =
            new AppContext();
    }
}

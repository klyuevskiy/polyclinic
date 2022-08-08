using Models.DataModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace Models.DataAccess
{
    public class AppealDAL : BaseDAL
    {
        public static void Add(Appeal appeal)
        {
            appeal.Patient = PatientDAL.Update(appeal.Patient);

            DataBase.Appeals.Add(appeal);

            DataBase.SaveChanges();
        }

        public static ObservableCollection<Appeal> GetAll()
        {
            return new ObservableCollection<Appeal>(DataBase.Appeals);
        }

        public static ObservableCollection<Appeal> GetForDoctor(int doctorId)
        {
            return new ObservableCollection<Appeal>(DataBase.Appeals
                .Where(a => a.Doctor.Id == doctorId));
        }

        public static ObservableCollection<Appeal> GetForEmployee(Employee employee)
        {
            if (employee is Doctor doctor)
                return GetForDoctor(doctor.Id);

            return GetAll();
        }
    }
}

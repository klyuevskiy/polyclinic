using Models.DataModels;
using System.Collections.Generic;
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

        public static IEnumerable<Appeal> GetAll()
        {
            return DataBase.Appeals;
        }

        public static IEnumerable<Appeal> GetForDoctor(int doctorId)
        {
            return DataBase.Appeals.Where(a => a.Doctor.Id == doctorId);
        }

        public static IEnumerable<Appeal> GetForEmployee(Employee employee)
        {
            if (employee is Doctor doctor)
                return GetForDoctor(doctor.Id);

            return GetAll();
        }
    }
}

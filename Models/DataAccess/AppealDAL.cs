using Models.DataModels;
using System;
using System.Collections.Generic;
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

        public static IEnumerable<Appeal> GetDateRangeDoctor
            (DateTime leftBound, DateTime rightBound, int doctorId)
        {
            return DataBase.Appeals.Where(a => a.Doctor.Id == doctorId &&
            a.ReceiptDate >= leftBound && a.ReceiptDate <= rightBound);
        }

        public static IEnumerable<Appeal> GetDateDoctor(DateTime date, int doctorId)
        {
            return DataBase.Appeals.Where(a => a.Doctor.Id == doctorId &&
            a.ReceiptDate.Date == date.Date);
        }
    }
}

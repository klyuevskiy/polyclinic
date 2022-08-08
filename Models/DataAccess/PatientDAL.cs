using Models.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Models.DataAccess
{
    public class PatientDAL : BaseDAL
    {
        public static Patient Get(int patientId)
        {
            return DataBase.Patients.FirstOrDefault(p => p.Id == patientId);
        }

        public static void Add(Patient patient)
        {
            DataBase.Patients.Add(patient);
            DataBase.SaveChanges();
        }

        public static List<Patient> GetAll()
        {
            return DataBase.Patients.ToList();
        }

        public static Patient Update(Patient patient)
        {
            // поиск если есть уже в БД, то обновлять эту
            Patient findPatient = DataBase.Patients
                .FirstOrDefault(p =>
                p.FIO == patient.FIO ||
                p.PhoneNumber == patient.PhoneNumber);

            if (findPatient != null)
            {
                findPatient.FIO = patient.FIO;
                findPatient.PhoneNumber = patient.PhoneNumber;

                return findPatient;
            }

            Add(patient);

            return patient;
        }
    }
}

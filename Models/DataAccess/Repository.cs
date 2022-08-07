using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Models.DataAccess
{
    public static class Repository
    {
        static AppContext dataBase = new AppContext();

        public static Employee FindEmployee(string login, string password)
        {
            SHA256 sha256 = SHA256.Create();

            password = Convert.ToBase64String(
                sha256.ComputeHash(Encoding.Default.GetBytes(password)));

            Employee employee = dataBase.Operators
                .FirstOrDefault(op => op.Login == login && op.Password == password);

            if (employee == null)
                employee = dataBase.Doctors
                    .FirstOrDefault(doc => doc.Login == login && doc.Password == password);

            return employee;
        }

        public static Patient FindPatient(int patientId)
        {
            return dataBase.Patients.FirstOrDefault(p => p.Id == patientId);
        }

        static void AddPatient(Patient patient)
        {
            dataBase.Patients.Add(patient);
        }

        static Patient UpdatePatient(Patient patient)
        {
            Patient findPatient = dataBase.Patients
                .FirstOrDefault(p =>
                p.FIO == patient.FIO ||
                p.PhoneNumber == patient.PhoneNumber);

            if (findPatient != null)
            {
                findPatient.FIO = patient.FIO;
                findPatient.PhoneNumber = patient.PhoneNumber;

                return findPatient;
            }

            AddPatient(patient);

            return patient;
        }

        public static void AddAppeal(Appeal appeal)
        {
            appeal.Patient = UpdatePatient(appeal.Patient);

            dataBase.Appeals.Add(appeal);

            dataBase.SaveChanges();
        }

        public static ObservableCollection<Appeal> GetAllAppeals()
        {
            return new ObservableCollection<Appeal>(dataBase.Appeals);
        }

        public static ObservableCollection<Appeal> GetDoctorAppeals(int doctorId)
        {
            return new ObservableCollection<Appeal>(dataBase.Appeals
                .Where(a => a.Doctor.Id == doctorId));
        }

        public static ObservableCollection<Appeal> GetAppealsForEmployee(Employee employee)
        {
            if (employee is Doctor doctor)
                return GetDoctorAppeals(doctor.Id);

            return GetAllAppeals();
        }

        public static List<Patient> GetAllPatients()
        {
            return dataBase.Patients.ToList();
        }

        public static List<Department> GetDepartmentsHaveDoctors()
        {
            return dataBase.Departments
                .Where(d => d.Doctors.Count > 0)
                .ToList();
        }
    }
}

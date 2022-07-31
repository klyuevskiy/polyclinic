using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using polyclinic.Models;
using polyclinic.Views;

namespace polyclinic.ViewModels
{
    public class EditAppealViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private readonly AppContext dataBase;

        public EditAppealViewModel(AppContext dataBase, Appeal appeal)
        {
            this.dataBase = dataBase;
            Appeal = appeal;

            Patients = dataBase.Patients.ToList();
            Departments = dataBase.Departments.Include(d => d.Doctors)
                .Where(d => d.Doctors.Count > 0)
                .ToList();

            ConfirmCommand = new ParametrizedCommand(Confirm);
            ChangeDepartmentCommand = new Command(ChangeDepartment);
            CancelCommand = new ParametrizedCommand(Cancel);
        }

        public string PatientFIO { get; set; } = "";

        string patientPhoneNumber = "";
        public string PatientPhoneNumber
        {
            get { return patientPhoneNumber; }
            set
            {
                patientPhoneNumber = value;

                OnPropertyChanged("PatientPhoneNumber");
            }
        }

        Patient selectedPatient = new Patient();
        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                selectedPatient = value;

                if (value != null)
                {
                    PatientFIO = selectedPatient.FIO;
                    PatientPhoneNumber = selectedPatient.PhoneNumber;
                }
            }
        }

        List<Patient> patients = null!;
        public List<Patient> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged("Patients");
            }
        }

        Visibility errorMessageVisibility = Visibility.Collapsed;
        public Visibility ErrorMessageVisibility
        {
            get { return errorMessageVisibility; }
            set
            {
                errorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        public List<Department> Departments { get; }

        List<Doctor> doctors = null!;
        public List<Doctor> Doctors
        {
            get { return doctors; }
            set
            {
                doctors = value;
                OnPropertyChanged("Doctors");
            }
        }

        public Appeal Appeal { get; }

        public ParametrizedCommand ConfirmCommand { get; }
        public Command ChangeDepartmentCommand { get; }
        public ParametrizedCommand CancelCommand { get; }

        void ChangeDepartment()
        {
            Doctors = Appeal.Department.Doctors;
        }

        void Confirm(object obj)
        {
            var appealWindow = obj as EditAppealWindow;

            if (appealWindow == null)
                return;

            if (Appeal.Department != null && Appeal.Doctor != null)
            {
                ErrorMessageVisibility = Visibility.Collapsed;

                Appeal.Patient.FIO = PatientFIO;
                Appeal.Patient.PhoneNumber = PatientPhoneNumber;

                appealWindow.DialogResult = true;
                appealWindow.Close();
            }
            else
                ErrorMessageVisibility = Visibility.Visible;
        }

        void Cancel(object obj)
        {
            if (obj is EditAppealWindow appealWindow)
                appealWindow.Close();
        }
    }
}

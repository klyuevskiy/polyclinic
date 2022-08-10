using Models.DataModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    public class AppealViewModel : ViewModel
    {
        public Appeal Appeal { get; set; }

        public IndexPatientsViewModel IndexPatientsViewModel { get; private set; }
        public IndexDepartmentsViewModel IndexDepartmentsViewModel { get; private set; } 
        public IndexDoctorsViewModel IndexDoctorsViewModel { get; private set; }

        PatientViewModel selectedPatient;

        public PatientViewModel SelectedPatient
        {
            get => selectedPatient;
            set
            {
                if (value != null)
                {
                    selectedPatient = value;
                    OnPropertyChanged();
                }
            }
        }


        public DoctorViewModel SelectedDoctor { get; set; }

        DepartmentViewModel selectedDepartment;
        public DepartmentViewModel SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;

                if (selectedDepartment != null &&
                    selectedDepartment.Department != null)
                    IndexDoctorsViewModel.UpdateDoctors(selectedDepartment);

                OnPropertyChanged();
            }
        }

        public void Load()
        {
            IndexPatientsViewModel = new IndexPatientsViewModel();
            IndexDepartmentsViewModel = new IndexDepartmentsViewModel();
            IndexDoctorsViewModel = new IndexDoctorsViewModel();
        }

        public AppealViewModel(Appeal appeal)
        {
            Appeal = appeal;

            SelectedPatient = new PatientViewModel(Appeal.Patient);
            SelectedDepartment = new DepartmentViewModel(Appeal.Department);
            SelectedDoctor = new DoctorViewModel(Appeal.Doctor);

            ConfirmCommand = new Command(Confirm);
            CancelCommand = new Command(Cancel);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public Action SetConfirmDialogResult { get; set; }
        public Action CloseWindow { get; set; }

        Visibility errorMessageVisibility = Visibility.Collapsed;

        public Visibility ErrorMessageVisibility
        {
            get => errorMessageVisibility;
            set
            {
                errorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        string errorMessage = "";
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        void Confirm()
        {
            if (!SelectedPatient.IsValid())
            {
                ErrorMessage = "Не заполнены данные пациента";
                ErrorMessageVisibility = Visibility.Visible;
            }
            else if (SelectedDepartment.Department == null ||
                SelectedDoctor.Doctor == null)
            {
                ErrorMessage = "Не выбрано отделение или врач";
                ErrorMessageVisibility = Visibility.Visible;
            }
            else
            {
                ErrorMessageVisibility = Visibility.Collapsed;

                Appeal.Patient.FIO = SelectedPatient.PatientFIO;
                Appeal.Patient.PhoneNumber = SelectedPatient.PatientPhoneNumber;

                Appeal.Department = SelectedDepartment.Department;
                Appeal.Doctor = SelectedDoctor.Doctor;

                SetConfirmDialogResult();
                CloseWindow();
            }
        }

        void Cancel()
        {
            CloseWindow();
        }
    }
}

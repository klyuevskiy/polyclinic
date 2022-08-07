using Models.DataModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    public class AppealViewModel : ViewModel
    {
        public Appeal Appeal { get; set; }

        public IndexPatientsViewModel IndexPatientsViewModel { get; }
        public IndexDepartmentsViewModel IndexDepartmentsViewModel { get;} 
        public IndexDoctorsViewModel IndexDoctorsViewModel { get; }

        public PatientViewModel SelectedPatient { get; }

        public AppealViewModel(Appeal appeal)
        {
            Appeal = appeal;

            IndexPatientsViewModel = new IndexPatientsViewModel();
            IndexDepartmentsViewModel = new IndexDepartmentsViewModel();
            IndexDoctorsViewModel = new IndexDoctorsViewModel();

            SelectedPatient = new PatientViewModel();

            ConfirmCommand = new Command(Confirm);
            CancelCommand = new Command(Cancel);
            ChangeDepartmentCommand = new Command(ChangeDepartment);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ChangeDepartmentCommand { get; }

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

        void ChangeDepartment()
        {
            Department department = IndexDepartmentsViewModel.SelectedDepartment;
            
            if (department != null)
            {
                IndexDoctorsViewModel.UpdateDoctors(department);
            }
        }

        void Confirm()
        {
            if (!SelectedPatient.IsValid())
            {
                ErrorMessage = "Не заполнены данные пациента";
                ErrorMessageVisibility = Visibility.Visible;
            }
            else if (IndexDepartmentsViewModel.SelectedDepartment == null ||
                IndexDoctorsViewModel.SelectedDoctor == null)
            {
                ErrorMessage = "Не выбрано отделение или врач";
                ErrorMessageVisibility = Visibility.Visible;
            }
            else
            {
                ErrorMessageVisibility = Visibility.Collapsed;

                Appeal.Patient.FIO = SelectedPatient.PatientFIO;
                Appeal.Patient.PhoneNumber = SelectedPatient.PatientPhoneNumber;
                Appeal.Department = IndexDepartmentsViewModel.SelectedDepartment;
                Appeal.Doctor = IndexDoctorsViewModel.SelectedDoctor;

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

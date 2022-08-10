using Models.DataModels;
using System;
using System.Windows.Input;

namespace ViewModels
{
    public class AppealViewModel : ModelViewModel<Appeal>
    {
        public Appeal Appeal
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

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
                    IndexDoctorsViewModel?.UpdateDoctors(selectedDepartment);

                OnPropertyChanged();
            }
        }

        Employee employee;

        public void Load(Employee employee)
        {
            this.employee = employee;

            IndexPatientsViewModel = new IndexPatientsViewModel();
            IndexDepartmentsViewModel = new IndexDepartmentsViewModel();
            IndexDoctorsViewModel = new IndexDoctorsViewModel();
        }

        public AppealViewModel(Appeal appeal)
            : base(appeal)
        {
            SelectedPatient = new PatientViewModel(Appeal.Patient);
            SelectedDepartment = new DepartmentViewModel(Appeal.Department);
            SelectedDoctor = new DoctorViewModel(Appeal.Doctor);

            ConfirmCommand = new Command(Confirm);
            CancelCommand = new Command(Cancel);
            IdentifyEmployeeCommand = new Command(IdentifyEmployee);
        }

        public ICommand ConfirmCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand IdentifyEmployeeCommand { get; private set; }

        public Action SetConfirmDialogResult { get; set; }
        public Action CloseWindow { get; set; }

        public Action ShowUnvalidPateintError { get; set; }
        public Action ShowUnselectedDepartmentError { get; set; }
        public Action ShowUnselectedDoctorError { get; set; }
        public Action HideErrors { get; set; }

        public Action EnabledElementsForDoctor { get; set; }
        public Action EnabledElementsForOperator { get; set; }

        void IdentifyEmployee()
        {
            if (employee == null)
                return;

            if (employee is Doctor)
                EnabledElementsForDoctor();
            else
                EnabledElementsForOperator();
        }

        void Confirm()
        {
            if (!SelectedPatient.IsValid())
            {
                ShowUnvalidPateintError();
            }
            else if (SelectedDepartment.Department == null)
            {
                ShowUnselectedDepartmentError();
            }
            else if (SelectedDoctor.Doctor == null)
            {
                ShowUnselectedDoctorError();
            }
            else
            {
                HideErrors();

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

using Microsoft.EntityFrameworkCore;
using polyclinic.Models;
using polyclinic.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace polyclinic.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        AppContext dataBase;
        public AuthorizationWindow authorizationWindow;
        public Employee Employee { get; }

        public ObservableCollection<Appeal> Appeals { get; private set; } = null!;

        public string EmployeeName { get; }

        Visibility addAppealMenuItemVisibility = Visibility.Visible;
        public Visibility AddAppealMenuItemVisibility
        {
            get { return addAppealMenuItemVisibility; }
            set
            {
                addAppealMenuItemVisibility = value;
                OnPropertyChanged("AddAppealMenuItemVisibility");
            }
        }
        Visibility removeAppealMenuItemVisibility = Visibility.Visible;
        public Visibility RemoveAppealMenuItemVisibility
        {
            get { return removeAppealMenuItemVisibility; }
            set
            {
                removeAppealMenuItemVisibility = value;
                OnPropertyChanged("RemoveAppealMenuItemVisibility");
            }
        }

        public MainWindowViewModel(AppContext dataBase, AuthorizationWindow authorizationWindow, Employee employee)
        {
            this.dataBase = dataBase;
            this.authorizationWindow = authorizationWindow;
            Employee = employee;

            EmployeeName = (Employee is Operator ? "Оператор: " : "Врач: ") +
                Employee.FIO;

            ClosingWindowCommand = new ParametrizedCommand(ClosingWindow);

            dataBase.Departments.Load();
            dataBase.Patients.Load();
            dataBase.Appeals.Load();

            CheckEmployee();

            AddAppealCommand = new Command(AddAppeal);
        }

        public ParametrizedCommand ClosingWindowCommand { get; }
        public Command AddAppealCommand { get; }

        void AddAppeal()
        {
            var editAppealViewModel =
                new EditAppealViewModel(dataBase, new Appeal(Employee as Operator));

            var editAppealWindow = new EditAppealWindow(editAppealViewModel);

            bool? dialogResult = editAppealWindow.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value)
            {
                Appeal appeal = editAppealViewModel.Appeal;

                Patient? patient = dataBase.Patients
                    .FirstOrDefault(p => p.FIO == appeal.Patient.FIO ||
                    p.PhoneNumber == appeal.Patient.PhoneNumber);

                if (patient != null)
                {
                    patient.FIO = appeal.Patient.FIO;
                    patient.PhoneNumber = appeal.Patient.PhoneNumber;

                    appeal.Patient = patient;
                }
                else
                {
                    dataBase.Patients.Add(appeal.Patient);
                }

                dataBase.Appeals.Add(appeal);
                dataBase.SaveChanges();

                Appeals.Add(appeal);
            }
        }

        void CheckEmployee()
        {
            if (Employee is Doctor doctor)
            {
                AddAppealMenuItemVisibility = Visibility.Collapsed;
                RemoveAppealMenuItemVisibility = Visibility.Collapsed;

                Appeals = new ObservableCollection<Appeal>
                    (dataBase.Appeals.Where(a => a.Doctor.Id == doctor.Id).ToList());
            }
            else
                Appeals = new ObservableCollection<Appeal>(dataBase.Appeals.ToList());
        }

        void ClosingWindow(object obj)
        {
            if (obj is CancelEventArgs e)
            {
                if (MessageBox.Show("Вы уверены, что хотите выйти?", "Закрытие", MessageBoxButton.YesNo)
                    != MessageBoxResult.Yes)
                    e.Cancel = true;
                else
                    authorizationWindow.Show();
            }
        }
    }
}

using Models.DataAccess;
using Models.DataModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    public class IndexAppealsViewModel : IndexViewModel<Appeal, AppealViewModel>
    {
        public ObservableCollection<AppealViewModel> Appeals
        {
            get => collection;
            set
            {
                collection = value;
                OnPropertyChanged();
            }
        }

        private readonly Employee employee;

        public string EmployeeName { get; }

        public IndexAppealsViewModel(Employee employee)
            : base(appeal => new AppealViewModel(appeal))
        {
            EmployeeName = (employee is Operator ? "Оператор: " : "Врач: ") +
                    employee.FIO;

            Build(AppealDAL.GetForEmployee(employee));

            AddCommand = new Command(Add);
            IdentifyEmployeeCommand = new Command(IdentifyEmployee);

            this.employee = employee;
        }

        public ICommand AddCommand { get; }
        public ICommand IdentifyEmployeeCommand { get; }

        public Predicate<AppealViewModel> TryChangeAppeal { get; set; }
        public Action HideButtonsForDoctor { get; set; }

        // при добавслении и реадктировании надо сделать dataGrid.Items.Refresh()
        public Action UpdateAppealsView { get; set; }

        void IdentifyEmployee()
        {
            if (employee is Doctor)
                HideButtonsForDoctor();
        }

        void Add()
        {
            Appeal appeal = new Appeal(employee as Operator);

            var appealViewModel = new AppealViewModel(appeal);
            
            appealViewModel.Load(employee);

            if (TryChangeAppeal(appealViewModel))
            {
                AppealDAL.Add(appeal);
                Appeals.Add(appealViewModel);

                UpdateAppealsView();
            }
        }
    }
}

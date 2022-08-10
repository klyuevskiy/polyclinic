using Models.DataAccess;
using Models.DataModels;
using System.Collections.ObjectModel;

namespace Models
{
    public class AppealsProcess
    {
        Employee employee;
        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;

                EmployeeName = (Employee is Operator ? "Оператор: " : "Врач: ") +
                    Employee.FIO;

                Appeals = new ObservableCollection<Appeal>(AppealDAL.GetForEmployee(employee));
            }
        }

        public string EmployeeName { get; private set; }

        public ObservableCollection<Appeal> Appeals { get; private set; }

        public AppealsProcess(Employee employee)
        {
            Employee = employee;
        }

        public Appeal Create()
        {
            Appeal appeal = new Appeal(Employee as Operator);
            appeal.Patient = new Patient();

            return appeal;
        }

        public void Add(Appeal appeal)
        {
            AppealDAL.Add(appeal);
            Appeals.Add(appeal);
        }
    }
}

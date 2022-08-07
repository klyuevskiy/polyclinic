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

                Appeals = Repository.GetAppealsForEmployee(employee);
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
            Repository.AddAppeal(appeal);
            Appeals.Add(appeal);
        }
    }
}

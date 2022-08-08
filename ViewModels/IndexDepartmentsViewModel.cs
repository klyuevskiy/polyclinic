using Models.DataAccess;
using Models.DataModels;
using System.Collections.Generic;

namespace ViewModels
{
    public class IndexDepartmentsViewModel : ViewModel
    {
        public List<Department> Departments { get; }

        Department selectedDepartment = null;

        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;
                OnPropertyChanged();
            }
        }

        public IndexDepartmentsViewModel()
        {
            Departments = DepartmentDAL.GetHaveDoctors();
        }
    }
}

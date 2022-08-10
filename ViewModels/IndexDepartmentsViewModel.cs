using Models.DataAccess;
using Models.DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class IndexDepartmentsViewModel : IndexViewModel<Department, DepartmentViewModel>
    {
        public IndexDepartmentsViewModel():
            base(dep => new DepartmentViewModel(dep))
        {
            Build(DepartmentDAL.GetHaveDoctors());
        }

        public ObservableCollection<DepartmentViewModel> Departments
        {
            get => collection;
            set
            {
                collection = value;
                OnPropertyChanged();
            }
        }
    }
}

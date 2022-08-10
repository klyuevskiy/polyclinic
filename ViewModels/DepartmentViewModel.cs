using Models.DataModels;

namespace ViewModels
{
    public class DepartmentViewModel : ModelViewModel<Department>
    {
        public DepartmentViewModel(Department model) : base(model)
        {
        }

        public Department Department
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            if (Department == null)
                return string.Empty;

            return Department.Name;
        }
    }
}

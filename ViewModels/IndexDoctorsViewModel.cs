using Models.DataModels;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class IndexDoctorsViewModel : IndexViewModel<Doctor, DoctorViewModel>
    {
        public IndexDoctorsViewModel() :
            base(doc => new DoctorViewModel(doc))
        {
        }

        public ObservableCollection<DoctorViewModel> Doctors
        {
            get => collection;
            set
            {
                collection = value;
                OnPropertyChanged();
            }
        }

        public void UpdateDoctors(DepartmentViewModel departmentViewModel)
        {
            Build(departmentViewModel.Department.Doctors);
        }
    }
}

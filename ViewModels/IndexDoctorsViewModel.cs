using Models.DataModels;
using System.Collections.Generic;

namespace ViewModels
{
    public class IndexDoctorsViewModel : ViewModel
    {
        ICollection<Doctor> doctors;
        public ICollection<Doctor> Doctors
        {
            get => doctors;
            set
            {
                doctors = value;
                OnPropertyChanged();
            }
        }

        Doctor selectedDoctor = null;

        public Doctor SelectedDoctor
        {
            get => selectedDoctor;
            set
            {
                selectedDoctor = value;
                OnPropertyChanged();
            }
        }

        public void UpdateDoctors(Department department)
        {
            Doctors = department.Doctors;
        }
    }
}

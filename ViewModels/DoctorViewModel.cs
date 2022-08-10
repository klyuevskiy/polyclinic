using Models.DataModels;

namespace ViewModels
{
    public class DoctorViewModel : ModelViewModel<Doctor>
    {
        public DoctorViewModel(Doctor model) : base(model)
        {
        }

        public Doctor Doctor
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
            if (Doctor == null || Doctor.FIO == null)
                return string.Empty;

            return Doctor.FIO;
        }
    }
}

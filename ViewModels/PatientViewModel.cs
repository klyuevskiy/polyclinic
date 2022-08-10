using Models.DataModels;

namespace ViewModels
{
    public class PatientViewModel : ModelViewModel<Patient>
    {
        public Patient Patient
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        string patientFIO;

        public string PatientFIO
        {
            get => patientFIO;
            set
            {
                patientFIO = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            if (Patient == null || Patient.FIO == null)
                return string.Empty;

            return Patient.FIO;
        }

        string patientPhoneNumber;

        public string PatientPhoneNumber
        {
            get => patientPhoneNumber;
            set
            {
                patientPhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public PatientViewModel(Patient model) : base(model)
        {
            PatientFIO = model.FIO;
            PatientPhoneNumber = model.PhoneNumber;
        }

        public bool IsValid()
        {
            return PatientFIO != null && PatientPhoneNumber != null &&
                PatientFIO != "" && PatientPhoneNumber != "";
        }
    }
}

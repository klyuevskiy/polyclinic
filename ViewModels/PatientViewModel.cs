using Models.DataModels;

namespace ViewModels
{
    public class PatientViewModel : ViewModel
    {
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

        Patient patient = new Patient();
        public Patient Patient
        {
            get { return patient; }
            set
            {
                patient = value;

                if (value != null)
                {
                    PatientFIO = patient.FIO;
                    PatientPhoneNumber = patient.PhoneNumber;
                }
            }
        }

        public bool IsValid()
        {
            return PatientFIO != null && PatientPhoneNumber != null &&
                PatientFIO != "" && PatientPhoneNumber != "";
        }
    }
}

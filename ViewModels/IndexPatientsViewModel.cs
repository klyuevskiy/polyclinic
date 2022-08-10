using Models.DataAccess;
using Models.DataModels;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class IndexPatientsViewModel : IndexViewModel<Patient, PatientViewModel>
    {
        public IndexPatientsViewModel() :
            base(p => new PatientViewModel(p))
        {
            Build(PatientDAL.GetAll());
        }

        public ObservableCollection<PatientViewModel> Patients
        {
            get => collection;
        }
    }
}

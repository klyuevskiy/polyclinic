using Models.DataAccess;
using Models.DataModels;
using System.Collections.Generic;

namespace ViewModels
{
    public class IndexPatientsViewModel : ViewModel
    {
        public List<Patient> Patients { get; }

        public IndexPatientsViewModel()
        {
            Patients = Repository.GetAllPatients();
        }
    }
}

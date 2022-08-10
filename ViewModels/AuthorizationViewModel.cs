using Models.DataAccess;
using Models.DataModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModels
{
    public class AuthorizationViewModel : ViewModel
    {
        string login = "";
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        public AuthorizationViewModel()
        {
            AuthorizationCommand = new ParametrizedCommand(Authorization);
        }

        public ICommand AuthorizationCommand { get; }

        public Action<IndexAppealsViewModel> SuccessAuthorization { get; set; }
        public Action ShowAuthorazationError { get; set; }
        public Action HideErrors { get; set; }

        void Authorization(object obj)
        {
            var passwordBox = obj as PasswordBox;

            if (passwordBox == null)
                return;

            Employee employee = EmployeeDAL.Get(Login, passwordBox.Password);

            if (employee == null)
            {
                ShowAuthorazationError();
            }
            else
            {
                HideErrors();

                var indexAppealsViewModel = new IndexAppealsViewModel(employee);

                SuccessAuthorization(indexAppealsViewModel);

                Login = "";
                passwordBox.Password = "";
            }

        }
    }
}

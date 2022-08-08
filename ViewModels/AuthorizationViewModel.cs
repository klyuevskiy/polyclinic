using Models;
using Models.DataAccess;
using Models.DataModels;
using System;
using System.Linq;
using System.Windows;
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

        Visibility authorizationErrorMessageVisibility = Visibility.Hidden;

        public Visibility ErrorMessageVisibility
        {
            get { return authorizationErrorMessageVisibility; }
            set
            {
                authorizationErrorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        public AuthorizationViewModel()
        {
            AuthorizationCommand = new ParametrizedCommand(Authorization);
        }
        public ICommand AuthorizationCommand { get; }

        public Action<AppealsProcess> SuccessAuthorization { get; set; }

        void Authorization(object obj)
        {
            var passwordBox = obj as PasswordBox;

            if (passwordBox == null)
                return;

            Employee employee = EmployeeDAL.Get(Login, passwordBox.Password);

            //Models.DataAccess.AppContext appContext = new Models.DataAccess.AppContext();

            //appContext.Database.EnsureCreated();
            //Employee employee = appContext.Operators.First();

            if (employee == null)
            {
                ErrorMessageVisibility = Visibility.Visible;
            }
            else
            {
                ErrorMessageVisibility = Visibility.Hidden;

                var appealsProcess = new AppealsProcess(employee);

                SuccessAuthorization(appealsProcess);

                Login = "";
                passwordBox.Password = "";
            }

        }
    }
}

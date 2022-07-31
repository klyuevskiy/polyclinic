using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using polyclinic.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace polyclinic.ViewModels
{
    internal class AuthorizationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        AuthorizationWindow authorizationWindow;

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

        public Visibility AuthorizationErrorMessageVisibility
        {
            get { return authorizationErrorMessageVisibility; }
            set
            {
                authorizationErrorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        AppContext dataBase;

        public AuthorizationViewModel(AuthorizationWindow authorizationWindow)
        {
            this.authorizationWindow = authorizationWindow;

            dataBase = new AppContext();

            AuthorizationCommand = new ParametrizedCommand(Authorization);
            LoadedWindowCommand = new Command(LoadedAuthorizationWindow);
            ClosingWindowCommand = new Command(ClosingWindow);
        }

        public ParametrizedCommand AuthorizationCommand { get; }
        public Command LoadedWindowCommand { get; }
        public Command ClosingWindowCommand { get; }

        void LoadedAuthorizationWindow()
        {
            dataBase.Operators.Load();
            dataBase.Doctors.Load();
        }

        void Authorization(object obj)
        {
            var passwordBox = obj as PasswordBox;

            if (passwordBox == null)
                return;

            string password = passwordBox.Password;

            Employee? employee = dataBase.Operators
                .FirstOrDefault(op => op.Login == Login && op.Password == password);

            if (employee == null)
                employee = dataBase.Doctors
                    .FirstOrDefault(op => op.Login == Login && op.Password == password);

            if (employee == null)
            {
                AuthorizationErrorMessageVisibility = Visibility.Visible;
            }
            else
            {
                AuthorizationErrorMessageVisibility = Visibility.Hidden;

                var mainWindowViewModel = new MainWindowViewModel(dataBase, authorizationWindow, employee);

                var mainWindow = new MainWindow(mainWindowViewModel);
                mainWindow.Show();

                Login = "";
                passwordBox.Password = "";
                authorizationWindow.Hide();
            }

        }

        void ClosingWindow()
        {
            dataBase.Dispose();
        }
    }
}

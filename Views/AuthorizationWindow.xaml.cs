using Models;
using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            var authorizationViewModel = new AuthorizationViewModel();

            DataContext = authorizationViewModel;

            authorizationViewModel.SuccessAuthorization = (AppealsProcess appealsProcess) =>
            {
                var indexAppealsViewModel = new IndexAppealsViewModel(appealsProcess);

                var mainWindow = new MainWindow(indexAppealsViewModel);
                mainWindow.Show();

                Hide();
            };
        }
    }
}

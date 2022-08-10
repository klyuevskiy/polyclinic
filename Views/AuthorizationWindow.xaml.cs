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

            authorizationViewModel.SuccessAuthorization =
                (IndexAppealsViewModel indexAppealsViewModel) =>
            {
                var mainWindow = new MainWindow(indexAppealsViewModel);
                mainWindow.Show();

                Hide();
            };

            authorizationViewModel.ShowAuthorazationError =
                () => errorMessageBox.Visibility = Visibility.Visible;

            authorizationViewModel.HideErrors =
                () => errorMessageBox.Visibility = Visibility.Collapsed;
        }
    }
}

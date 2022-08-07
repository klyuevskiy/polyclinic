using ViewModels;
using System.Windows;

namespace Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(IndexAppealsViewModel indexAppealsViewModel)
        {
            InitializeComponent();

            DataContext = indexAppealsViewModel;

            indexAppealsViewModel.TryChangeAppeal =
                (AppealViewModel appealViewModel) =>
            {
                var editAppealWindow = new EditAppealWindow(appealViewModel);

                bool? dialogResult = editAppealWindow.ShowDialog();

                return dialogResult.HasValue && dialogResult.Value;
            };

            indexAppealsViewModel.UpdateAppealsView = () => viewAppeals.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Закрытие", MessageBoxButton.YesNo)
                    != MessageBoxResult.Yes)
                e.Cancel = true;
            else
                App.Current.MainWindow.Show();
        }
    }
}

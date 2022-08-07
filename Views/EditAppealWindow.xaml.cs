using ViewModels;
using System.Windows;

namespace Views
{
    /// <summary>
    /// Логика взаимодействия для EditAppealWindow.xaml
    /// </summary>
    public partial class EditAppealWindow : Window
    {
        public EditAppealWindow(AppealViewModel appealViewModel)
        {
            InitializeComponent();

            DataContext = appealViewModel;

            appealViewModel.CloseWindow = () => Close();
            appealViewModel.SetConfirmDialogResult = () => DialogResult = true;
        }
    }
}

using System.Windows;
using ViewModels;

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

            appealViewModel.EnabledElementsForOperator = () =>
            {
                doctorDiseaseTextBox.IsEnabled = false;
            };

            appealViewModel.EnabledElementsForDoctor = () =>
            {
                patientComboBox.IsEnabled = false;
                patientPhoneNumberTextBox.IsEnabled = false;
                departmentComboBox.IsEnabled = false;
                doctorComboBox.IsEnabled = false;
                receiptDatePicker.IsEnabled = false;
                receiptTimePicker.IsEnabled = false;
            };

            SetErrorsActions(appealViewModel);
        }

        void SetErrorsActions(AppealViewModel appealViewModel)
        {

            appealViewModel.ShowUnvalidPateintError = () =>
            {
                errorMessageBox.Text = "Не заполнены данные пациента";
                errorMessageBox.Visibility = Visibility.Visible;
            };

            appealViewModel.ShowUnselectedDepartmentError = () =>
            {
                errorMessageBox.Text = "Не выбрано отделение";
                errorMessageBox.Visibility = Visibility.Visible;
            };

            appealViewModel.ShowUnselectedDoctorError = () =>
            {
                errorMessageBox.Text = "Не выбран доктор";
                errorMessageBox.Visibility = Visibility.Visible;
            };

            appealViewModel.HideErrors =
                () => errorMessageBox.Visibility = Visibility.Collapsed;
        }
    }
}

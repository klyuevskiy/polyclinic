using Models;
using Models.DataModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    public class IndexAppealsViewModel : ViewModel
    {
        public ObservableCollection<Appeal> Appeals { get; }

        AppealsProcess appealsProcess;

        public string EmployeeName
        {
            get => appealsProcess.EmployeeName;
        }

        public IndexAppealsViewModel(AppealsProcess appealsProcess)
        {
            Appeals = appealsProcess.Appeals;
            this.appealsProcess = appealsProcess;

            AddCommand = new Command(Add);

            if (appealsProcess.Employee is Doctor)
                HideAddRemoveButtons();
        }

        public ICommand AddCommand { get; }

        public Predicate<AppealViewModel> TryChangeAppeal { get; set; }

        // при добавслении и реадктировании надо сделать dataGrid.Items.Refresh()
        public Action UpdateAppealsView { get; set; }

        void Add()
        {
            Appeal appeal = appealsProcess.Create();

            var appealViewModel = new AppealViewModel(appeal);
            appealViewModel.Load();

            if (TryChangeAppeal(appealViewModel))
            {
                appealsProcess.Add(appeal);
                UpdateAppealsView();
            }
        }

        void HideAddRemoveButtons()
        {
            AddMenuItemVisibility = Visibility.Collapsed;
            RemoveMenuItemVisibility = Visibility.Collapsed;
        }

        Visibility addMenuItemVisibility = Visibility.Visible;
        Visibility removeMenuItemVisibility = Visibility.Visible;

        public Visibility AddMenuItemVisibility
        {
            get => addMenuItemVisibility;
            set
            {
                addMenuItemVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility RemoveMenuItemVisibility
        {
            get => removeMenuItemVisibility;
            set
            {
                removeMenuItemVisibility = value;
                OnPropertyChanged();
            }
        }
    }
}

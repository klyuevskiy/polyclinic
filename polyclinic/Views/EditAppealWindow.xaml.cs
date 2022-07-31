using polyclinic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace polyclinic.Views
{
    /// <summary>
    /// Логика взаимодействия для EditAppealWindow.xaml
    /// </summary>
    public partial class EditAppealWindow : Window
    {
        public EditAppealWindow(EditAppealViewModel editAppealViewModel)
        {
            InitializeComponent();

            DataContext = editAppealViewModel;
        }
    }
}

using System;
using System.Windows.Input;

namespace ViewModels
{
    public class ParametrizedCommand : ICommand
    {
        Action<object> action;

        public ParametrizedCommand(Action<object> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
                action(parameter);
        }
    }
}

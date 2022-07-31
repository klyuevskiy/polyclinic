using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace polyclinic
{
    public class ParametrizedCommand : ICommand
    {
        Action<object> action;

        public ParametrizedCommand(Action<object> action)
        {
            this.action = action;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
                action(parameter);
        }
    }
}

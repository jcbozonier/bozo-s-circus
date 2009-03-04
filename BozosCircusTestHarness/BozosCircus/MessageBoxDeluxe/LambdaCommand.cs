using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BozosCircus.MessageBoxDeluxe
{
    public class LambdaCommand<T> : ICommand
    {
        private Action<T> _Command;
        private Predicate<T> _IsEnabled;

        public LambdaCommand(Action<T> command, Predicate<T> isEnabled)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (isEnabled == null) throw new ArgumentNullException("isEnabled");

            _Command = command;
            _IsEnabled = isEnabled;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (parameter == null) return;

            if (_Command != null)
                _Command((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null &&
                   _IsEnabled((T)parameter);
        }
    }
}
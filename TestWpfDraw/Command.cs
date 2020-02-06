using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestGit
{
    class Command : ICommand
    {
        public Action<object> Action { get; }

        public bool CanExecute(object parameter) => Action != null;

        public void Execute(object parameter) => Action?.Invoke(parameter);

        public event EventHandler CanExecuteChanged;

        public Command(Action<object> action) => Action = action;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _4_TermPaper.ViewModel
{
    internal class RelayCommand : ICommand
    {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> onExecute;

        public RelayCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            if(execute == null)
                throw new ArgumentNullException("Передаваємий метод для виконання не може бути null");
            
            this.canExecute = canExecute;
            this.onExecute = execute;
        }

        public event EventHandler? CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter) => canExecute == null ? true : canExecute.Invoke(parameter);
        public void Execute(object? parameter) => onExecute?.Invoke(parameter);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//code source and base research from https://www.codeproject.com/Articles/126249/MVVM-Pattern-in-WPF-A-Simple-Tutorial-for-Absolute
//also implementation of RelayCommand : https://stackoverflow.com/questions/22285866/why-relaycommand

namespace DATools.MVVM.ViewModelBases
{
    public class RelayCommand<T> : ICommand
    {
        //predicado y accion o comandos delegados privados
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        //Constructor del Objecto RelayCommand
        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}

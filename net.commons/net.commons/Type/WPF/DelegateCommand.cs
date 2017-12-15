using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Net.Commons.Type.WPF
{
    /// <summary>
    /// Delegate class for a <see cref="ICommand"/>
    /// </summary>
    public sealed class DelegateCommand : ICommand
    {
        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteFunc;

        public DelegateCommand(Action executeAction) : this(executeAction, () => true)
        {
        }

        public DelegateCommand(Action executeAction, Func<bool> canExecuteFunc) : this(o => executeAction(), o => canExecuteFunc())
        {
        }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, o => true)
        {
        }

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc(parameter);
        }

        /// <inheritdoc />
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        /// <summary>
        /// Raise the <see cref="CanExecuteChanged"/> event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
namespace Chess.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Klassen GenericCommand.
    /// </summary>
    public class GenericCommand : ICommand
    {
        /// <summary>
        /// En instans av klassen Action.
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initierar en ny instans av klassen GenericCommand.
        /// </summary>
        public GenericCommand(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// CanExecuteChanged EventHandler.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Kontrollerar om ett kommando kan utföras.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Utför kommandot.
        /// </summary>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}

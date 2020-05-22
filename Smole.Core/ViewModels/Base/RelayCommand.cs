using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Smole.Core    
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        // The action to run
        private Action mAction;

        #endregion

        #region Public Events

        // The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// Default constructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        // A relay command can always execute
        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Executes the commands Action
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}

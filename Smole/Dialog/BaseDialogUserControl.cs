using Smole.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Smole
{
    /// <summary>
    /// The base class for any content inside <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        // The dialog window we will contained within
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Properties

        // Dialog window Minimum Height
        public int WindowMinimumHeight { get; set; } = 100;

        // Dialog window Minimum Width
        public int WindowMinimumWidth { get; set; } = 250;

        // Dialog window Title Height
        public int TitleHeight { get; set; } = 15;

        // Dialog window Title
        public string Title { get; set; }

        #endregion

        #region Commands

        public ICommand CloseCommand { get; private set; }
        public ICommand YesCommand { get; private set; }
        public ICommand NoCommand { get; private set; }

        #endregion

        #region Constructor

        // Default Constructor
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Create a new Dialog Window
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

                // Create a Choise to no
                IoC.Application.YesNoChoise = false;

                // Create Command
                CloseCommand = new RelayCommand(() => mDialogWindow.Close());
                YesCommand = new RelayCommand(YesMethod);
                NoCommand = new RelayCommand(NoMethod);
            }
        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel"> View Model</param>
        /// <typeparam name="T"> The View Model's type </typeparam>
        /// <returns> Wait user choise </returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            // Create a task to await a dialog closing
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI Thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Set default values
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    // Set this control to the dialog window content
                    mDialogWindow.ViewModel.Content = this;

                    // Set DataContext
                    DataContext = viewModel;

                    // Show dialog
                    mDialogWindow.ShowDialog();
                }
                // If our porgramm will crush we have to ..
                finally
                {
                    // Let caller know we finish
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion

        #region Command Methods

        public void YesMethod()
        {
            IoC.Application.YesNoChoise = true;
            mDialogWindow.Close();
        }

        public void NoMethod()
        {
            IoC.Application.YesNoChoise = false;
            mDialogWindow.Close();
        }

        #endregion
    }
}

using System.Windows;
using System.Windows.Controls;

namespace Smole
{
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        // The title of this dialog window
        public string Title { get; set; }

        // The content to host inside the dialog
        public Control Content { get; set; }

        #endregion

        #region Constructor

        // Default constructor
        public DialogWindowViewModel(Window window) : base(window)
        {
            // Make minimum size smaller
            WindowMinimumWidth = 250;
            WindowMinimumHeight = 100;
        }

        #endregion
    }
}

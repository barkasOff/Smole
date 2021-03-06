﻿using System.Threading.Tasks;

namespace Smole.Core
{
    /// <summary>
    /// The UI Manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel"> View Model</param>
        /// <returns> Wait user choise </returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);

        /// <summary>
        /// Displays a yes/no message box to the user
        /// </summary>
        /// <param name="viewModel"> View Model</param>
        /// <returns> Wait user choise </returns>
        Task YesNoShowMessage(MessageBoxDialogViewModel viewModel);
    }
}

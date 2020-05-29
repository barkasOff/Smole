using Smole.Core;
using System.Threading.Tasks;

namespace Smole
{
    /// <summary>
    /// The Application implemention of <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel"> View Model</param>
        /// <returns> Wait user choise </returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel) =>
            new DialogMessageBox().ShowDialog(viewModel);

        /// <summary>
        /// Displays a yes/no message box to the user
        /// </summary>
        /// <param name="viewModel"> View Model</param>
        /// <returns> Wait user choise </returns>
        public Task YesNoShowMessage(MessageBoxDialogViewModel viewModel) =>
            new YesNoDialogMessageBox().ShowDialog(viewModel);
    }
}

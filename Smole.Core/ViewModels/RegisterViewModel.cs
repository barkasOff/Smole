using System.Threading.Tasks;
using System.Windows.Input;

namespace Smole.Core
{
    /// <summary>
    /// Register Screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        // NewUserName
        public string NewUserName { get; set; }

        // NewUserEmail
        public string NewUserEmail { get; set; }

        #endregion

        #region Commands

        // Login Command
        public ICommand LoginCommand { get; set; }

        // GOTO: Register Page
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommandParameter(async (parameter) => await RegisterMethodAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginMethodAsync());
        }

        #endregion

        #region Private Methods

        private async Task RegisterMethodAsync(object parameter)
        {
            IoC.Application.GoToPage(ApplicationPage.Home);
            IoC.Application.ShowGroupItems ^= true; ;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Welcome!!",
                Message = "Here you are, dude!!"
            });

            await Task.Delay(1);
        }

        private async Task LoginMethodAsync()
        {
            // GOTO: go to login page??
            IoC.Application.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }

        #endregion
    }
}

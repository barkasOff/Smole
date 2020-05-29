using System.Threading.Tasks;
using System.Windows.Input;

namespace Smole.Core
{
    /// <summary>
    /// Login Screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        // NewUserEmail
        public string LoginUserName { get; set; }

        #endregion

        #region Commands

        // Login Command
        public ICommand LoginCommand { get; set; }

        // GOTO: Register Page
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayCommandParameter(async (parameter) => await LoginMethodAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterMethodAsync());
        }

        #endregion

        #region Private Methods

        private async Task LoginMethodAsync(object parameter)
        {
            IoC.Application.GoToPage(ApplicationPage.Home);
            IoC.Application.ShowGroupItems ^= true;

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Welcome!!",
                Message = "Here you are, dude!!"
            });

            await Task.Delay(100);
        }

        private async Task RegisterMethodAsync()
        {
            // GOTO: go to register page??
            IoC.Application.GoToPage(ApplicationPage.Register);

            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Welcome!!",
                Message = "Here you are, dude!!"
            });

            await Task.Delay(1);
        }

        #endregion
    }
}

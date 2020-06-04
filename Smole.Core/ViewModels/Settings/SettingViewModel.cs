using System.Threading.Tasks;
using System.Windows.Input;

namespace Smole.Core
{
    /// <summary>
    /// View model for thwe setting control
    /// </summary>
    public class SettingViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the view model
        /// </summary>
        public static SettingViewModel Instance => new SettingViewModel();

        #endregion

        #region Public Properties

        /// <summary>
        /// Current user name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// Current user surname
        /// </summary>
        public TextEntryViewModel Surname { get; set; }

        /// <summary>
        /// Current user username
        /// </summary>
        public TextEntryViewModel Username { get; set; }

        /// <summary>
        /// Current user password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// Current user email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Open Setting Menu Command
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        /// Close Setting Menu Command
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Close Setting Menu Command
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingViewModel()
        {
            // Create Commands
            OpenCommand = new RelayCommand(async () => await OpenMethodAsync());
            CloseCommand = new RelayCommand(async () => await CloseMethodAsync());
            LogoutCommand = new RelayCommand(LogoutMethodAsync);

            Name = new TextEntryViewModel
            {
                Label = "First Name",
                OriginalText = IoC.Base.LastUserInTheApp?.Name,
                UserEditingInfo = IUserEditInfo.Name
            };

            Surname = new TextEntryViewModel
            {
                Label = "Second Name",
                OriginalText = IoC.Base.LastUserInTheApp?.Surname,
                UserEditingInfo = IUserEditInfo.Surname
            };

            Username = new TextEntryViewModel
            {
                Label = "UserName",
                OriginalText = IoC.Base.LastUserInTheApp?.UserName,
                UserEditingInfo = IUserEditInfo.Username
            };

            Password = new PasswordEntryViewModel
            {
                Label = "Password",
                FakePassword = "*****"
            };

            Email = new TextEntryViewModel
            {
                Label = "Email",
                OriginalText = IoC.Base.LastUserInTheApp?.Email,
                UserEditingInfo = IUserEditInfo.Email
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Close settings
        /// </summary>
        /// <returns> Wait </returns>
        private async Task CloseMethodAsync()
        {
            IoC.Application.SettingVisible = false;

            await Task.Delay(100);
        }

        /// <summary>
        /// Open settings
        /// </summary>
        /// <returns> Wait </returns>
        private async Task OpenMethodAsync()
        {
            IoC.Application.SideMenuVisible = false;
            IoC.Application.DimmebleOverlayVisible = false;
            IoC.Application.SettingVisible = true;

            await Task.Delay(100);
        }

        /// <summary>
        /// Login 
        /// </summary>
        private void LogoutMethodAsync()
        {
            IoC.Application.SettingVisible = false;
            IoC.Application.GoToPage(ApplicationPage.Login);
            IoC.Application.HasGroup = true;
            IoC.Application.ShowGroupItems = false;
            IoC.Base.LastUserInTheApp.SaveUserInfo = false;
            IoC.Base.SaveUsers();
        }

        /// <summary>
        /// Load new data to thew app
        /// </summary>
        public void LoadNewDataUser()
        {
            // Set first name
            Name.OriginalText = IoC.AppUser.Name = IoC.Base.LastUserInTheApp?.UserName;

            // Set last name
            Surname.OriginalText = IoC.AppUser.SurName = IoC.Base.LastUserInTheApp?.Surname;

            // Set username
            Username.OriginalText = IoC.AppUser.UserName = IoC.Base.LastUserInTheApp?.UserName;

            // Set email
            Email.OriginalText = IoC.AppUser.Email = IoC.Base.LastUserInTheApp?.Email;
        }

        #endregion
    }
}

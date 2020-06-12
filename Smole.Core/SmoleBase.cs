using System;
using System.Collections.Generic;

namespace Smole.Core
{
    /// <summary>
    /// Main class, from which we give Baselities fro user
    /// </summary>
    public class SmoleBase
    {
        #region Private members

        /// <summary>
        /// User icon colors
        /// </summary>
        private string[] UserColors =
            new string[] { "ff4", "5e916c", "0255fa", "ca77ed", "ff006f",
                           "bfff00", "7afa6b", "1bff00", "ff8800", "eb5e5e"};

        #endregion

        #region Public Properties

        /// <summary>
        /// Last User in the app to save
        /// </summary>
        public User LastUserInTheApp { get; set; }

        /// <summary>
        /// All users in the SN
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();

        /// <summary>
        /// All Groups in the SN
        /// </summary>
        public List<UsersInGroups> Groups { get; set; } = new List<UsersInGroups>();

        #endregion

        #region Methods

        /// <summary>
        /// Serialize all users and LastUser
        /// </summary>
        public void SaveUsers()
        {
            string PATH = $"{Environment.CurrentDirectory}\\LastConnection.json";
            FileIOService fileIOfileIO = new FileIOService(PATH);

            fileIOfileIO.JsonSerialization(LastUserInTheApp);
        }

        /// <summary>
        /// Deserialize all users and LastUser
        /// </summary>
        public void LoadUsers()
        {
            // PATH to application file
            string PATH = $"{Environment.CurrentDirectory}\\LastConnection.json";
            FileIOService fileIOfileIO = new FileIOService(PATH);

            // Deserialize users
            LastUserInTheApp = fileIOfileIO.JsonDeserialization<User>();

            // Load Info
            IoC.Setting.LoadNewDataUser();

            // Does he want to auto login?..
            if (LastUserInTheApp?.SaveUserInfo ?? false)
                AutoLogin();
        }

        // Login without password and username
        public void AutoLogin()
        {
            // Load Info
            IoC.Setting.LoadNewDataUser();

            IoC.Application.GoToPage(ApplicationPage.Home);
            IoC.Application.ShowGroupItems = true;
            IoC.Application.HasGroup = false;
        }

        #endregion
    }
}

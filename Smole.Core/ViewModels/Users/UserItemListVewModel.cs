using System.Collections.Generic;

namespace Smole.Core
{
    public class UserItemListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Flag which load users
        /// </summary>
        public bool NewUser { get; set; }

        /// <summary>
        /// Initials
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// ProfilePictureRGB
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User SurName
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// User UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User groups are followed
        /// </summary>
        public List<string> Groups { get; set; } = new List<string>();

        /// <summary>
        /// All photo in user account
        /// </summary>
        public List<string> Photos { get; set; } = new List<string>();

        /// <summary>
        /// User Age
        /// </summary>
        public int Age { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace Smole.Core
{
    public class User
    {
        #region Public Properties

        /// <summary>
        /// All groups the user is subscribed to
        /// </summary>
        public List<UsersInGroups> Groups { get; set; }

        /// <summary>
        /// If we subscribe to the group, btn color changes to gray
        /// </summary>
        public string FollowBtnColor { get; set; } = "ffaa00";

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
        /// User Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User UserEmail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// All photo in user account
        /// </summary>
        public List<string> Photos { get; set; } = new List<string>();

        /// <summary>
        /// Date of the user burth
        /// </summary>
        public DateTime DateBurth { get; set; }

        /// <summary>
        /// Indicate about new info about user
        /// </summary>
        public bool SaveUserInfo { get; set; } 

        #endregion

        /// <summary>
        /// Output Specifications
        /// </summary>
        /// <returns> New Output string </returns>
        public override string ToString() =>
            $"{UserName}";
    }
}

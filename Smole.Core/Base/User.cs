using System;
using System.Collections.Generic;

namespace Smole.Core
{
    public class User
    {
        /// <summary>
        /// If we subscribe to the group, btn color changes to gray
        /// </summary>
        public string FollowBtnColor { get; set; } = "ffaa00";

        // Initials
        public string Initials { get; set; }

        // Status
        public string Status { get; set; }

        // ProfilePictureRGB
        public string ProfilePictureRGB { get; set; }

        // User Name
        public string Name { get; set; }

        // User SurName
        public string Surname { get; set; }

        // User UserName
        public string UserName { get; set; }

        // User UserEmail
        public string Email { get; set; }

        // User Password
        public string Password { get; set; }

        // User groups are followed
        public List<string> Groups { get; set; } = new List<string>();

        // All photo in user account
        public List<string> Photos { get; set; } = new List<string>();

        // Date of the user burth
        public DateTime DateBurth { get; set; }

        /// <summary>
        /// Indicate about new info about user
        /// </summary>
        public bool SaveUserInfo { get; set; }

        /// <summary>
        /// Output Specifications
        /// </summary>
        /// <returns> New Output string </returns>
        public override string ToString() =>
            $"{UserName}";
    }
}

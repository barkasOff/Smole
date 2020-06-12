using System.Collections.Generic;

namespace Smole.Core
{
    public class Group
    {
        #region Public Properties

        /// <summary>
        /// All groups the user is subscribed to
        /// </summary>
        public List<UsersInGroups> Users { get; set; }

        /// <summary>
        /// Name Of Our Group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Discription { get; set; } = "Welcome to may group!";

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// Users Current Count
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        /// Current Image of the group
        /// </summary>
        public string CurrentPageImage { get; set; }

        /// <summary>
        /// If we subscribe to the group, btn color changes to gray
        /// </summary>
        public string FollowBtnColor { get; set; } = "ffaa00";

        /// <summary>
        /// All Images of the group
        /// </summary>
        public List<string> GroupImages { get; set; } = new List<string>();

        /// <summary>
        /// All Posts of the group
        /// </summary>
        public List<Post> Posts { get; set; } = new List<Post>();

        /// <summary>
        /// All Audios of the group
        /// </summary>
        public List<string> Audios { get; set; } = new List<string>();

        /// <summary>
        /// All Videos of the group
        /// </summary>
        public List<string> Videos { get; set; } = new List<string>(); 

        #endregion
    }
}

using System.Collections.Generic;

namespace Smole.Core
{
    public class Group
    {
        // Name Of Our Group
        public string Name { get; set; }

        // The latest message from this chat
        public string Discription { get; set; } = "Welcome to may group!";

        // The initials to show for the profile picture background
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        // Users Current Count
        public int UserCount { get; set; }

        // Current Image of the group
        public string CurrentPageImage { get; set; }

        /// <summary>
        /// If we subscribe to the group, btn color changes to gray
        /// </summary>
        public string FollowBtnColor { get; set; } = "ffaa00";

        // All Images of the group
        public List<string> GroupImages { get; set; } = new List<string>();

        // All Posts of the group
        public List<Post> Posts { get; set; } = new List<Post>();

        // All Posts of the group
        public List<User> Users { get; set; } = new List<User>();

        // All Audios of the group
        public List<string> Audios { get; set; } = new List<string>();

        // All Videos of the group
        public List<string> Videos { get; set; } = new List<string>();
    }
}

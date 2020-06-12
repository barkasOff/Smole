namespace Smole.Core
{
    /// <summary>
    /// Make a connection between classes
    /// </summary>
    public class UsersInGroups
    {
        /// <summary>
        /// User ID to get to the group
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User to the group
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Group ID to get into the group
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// User to the group
        /// </summary>
        public Group Group { get; set; }
    }
}

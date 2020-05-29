namespace Smole.Core
{
    public class Post
    {
        /// <summary>
        /// Post Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post message
        /// </summary>
        public string PostMessage { get; set; }

        /// <summary>
        /// Flag which indicate app about new post
        /// </summary>
        public bool NewPost { get; set; }
    }
}

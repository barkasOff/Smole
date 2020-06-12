namespace Smole.Core
{
    /// <summary>
    /// Basik Checks For Main
    /// </summary>
    public static class BasikChecks
    {
        /// <summary>
        /// Check string input
        /// </summary>
        /// <param name="input"> Check this input </param>
        public static bool inputCheckString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                PrintClass.Error("Неккоректный ввод!!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check string input
        /// </summary>
        /// <param name="input"> Check this input </param>
        public static bool inputCheckInt(string input)
        {
            int cur = 0;
            if (!int.TryParse(input, out cur))
            {
                PrintClass.Error("Enter a number!!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check user in group
        /// </summary>
        public static bool userInGroup(User user, Group group)
        {
            foreach (var us in group.Users)
            {
                if (us.User.UserName == user.UserName)
                    return true;
            }

            return false;
        }
    }
}

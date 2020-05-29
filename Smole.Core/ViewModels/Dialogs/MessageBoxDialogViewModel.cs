namespace Smole.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        // Message Box Message
        public string Message { get; set; } = "Hello!";

        // Message Box Button Text - Ok
        public string OkText { get; set; } = "OK";


        // Message Box Button Text - Yes
        public string YesText { get; set; } = "Yes";


        // Message Box Button Text - No
        public string NoText { get; set; } = "No";
    }
}

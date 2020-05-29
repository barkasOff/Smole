namespace Smole.Core
{
    public static class PrintClass
    {
        /// <summary>
        /// Return Red Color Error
        /// </summary>
        /// <param name="message"> Error's text </param>
        public static void Error(string message)
        {
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Error!!",
                Message = message,
                OkText = "OK"
            });
        }
        
        /// <summary>
        /// Return Red Color Error
        /// </summary>
        /// <param name="message"> Error's text </param>
        public static void Congratulations(string message)
        {
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Congratulations",
                Message = message,
                OkText = "Ok"
            });
        }

        /// <summary>
        /// Return Red Color Error
        /// </summary>
        /// <param name="message"> Error's text </param>
        public static void YesNoQuestion(string message)
        {
            IoC.UI.YesNoShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Question",
                Message = message,
                YesText = "Yes",
                NoText = "No"
            });
        }
    }
}

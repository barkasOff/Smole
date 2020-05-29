namespace Smole.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singelton

        // Singelton prop of this class
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        // Default constructor
        public MessageBoxDialogDesignModel()
        {
            OkText = "OK";
            Message = "Error!!";
        }

        #endregion
    }
}

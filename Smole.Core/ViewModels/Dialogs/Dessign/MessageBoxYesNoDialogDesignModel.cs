namespace Smole.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxYesNoDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singelton

        // Singelton prop of this class
        public static MessageBoxYesNoDialogDesignModel Instance => new MessageBoxYesNoDialogDesignModel();

        #endregion

        #region Constructor

        // Default constructor
        public MessageBoxYesNoDialogDesignModel()
        {
            YesText = "Yes";
            NoText = "No";
            Message = "Error!!";
        }

        #endregion
    }
}

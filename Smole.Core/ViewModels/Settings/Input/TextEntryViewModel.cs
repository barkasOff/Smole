using System.Diagnostics;
using System.Windows.Input;

namespace Smole.Core
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// <summary>
    public class TextEntryViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TextEntryViewModel Instance => new TextEntryViewModel();

        #endregion

        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current saved value
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        public string EditedText { get; set; }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

        /// <summary>
        /// Which parameter we edit
        /// </summary>
        public IUserEditInfo UserEditingInfo { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextEntryViewModel()
        {
            // Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            // Set the edited text to the current value
            EditedText = OriginalText;

            // Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            EditUser(IoC.Base.LastUserInTheApp);
        }

        #endregion

        #region Help Methods

        private void EditUser(User user)
        {
            // Edit main info
            switch (UserEditingInfo)
            {
                case IUserEditInfo.Name:
                    IoC.Base.LastUserInTheApp.Name = IoC.AppUser.Name = EditedText;
                    if (user != null)
                        user.Name = EditedText;
                    break;

                case IUserEditInfo.Surname:
                    IoC.Base.LastUserInTheApp.Surname = IoC.AppUser.SurName = EditedText;
                    if (user != null)
                        user.Surname = EditedText;
                    break;

                case IUserEditInfo.Email:
                    IoC.Base.LastUserInTheApp.Email = IoC.AppUser.Email = EditedText;
                    if (user != null)
                        user.Email = EditedText;
                    break;

                case IUserEditInfo.Username:
                    IoC.Base.LastUserInTheApp.UserName = IoC.AppUser.UserName = EditedText;
                    if (user != null)
                        user.UserName = EditedText;
                    break;

                default:
                    Debugger.Break();
                    break;
            }

            // Serialize users
            IoC.Base.SaveUsers();

            // Restore original value
            OriginalText = EditedText;

            // Go back into edit mode
            Editing = false;
        }

        #endregion
    }
}

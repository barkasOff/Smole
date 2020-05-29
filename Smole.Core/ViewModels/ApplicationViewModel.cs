namespace Smole.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        // The current page of the application
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        // Page View Model
        public BaseViewModel PageVM { get; set; }

        // True if we want to dimmed overlay
        public bool DimmebleOverlayVisible { get; set; }

        // True if the slide menu should be shown
        public bool SideMenuVisible { get; set; }

        // Flag which help to show bubble
        public bool ShowBubble { get; set; }

        // Flag which help to show groups
        public bool HasGroup { get; set; }

        /// <summary>
        /// Flag wich help with beatiful slode group page
        /// </summary>
        public bool ShowGroupItems { get; set; }


        // True if the slide menu should be shown
        public bool SettingVisible { get; set; }

        // True if user click yesButton
        public bool YesNoChoise { get; set; }

        #endregion

        /// <summary>
        /// Go to the spacial page with spacial viewModel
        /// </summary>
        /// <param name="page"> Go to?.. </param>
        /// <param name="viewModel"> View model of the page </param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            // Change view model
            PageVM = viewModel;

            // Change page
            CurrentPage = page;

            // Give signal to change the page
            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}

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

        // Flag which help to show bubble
        public bool ShowBubble { get; set; } = true;

        // Flag which help to show groups
        public bool HasGroup { get; set; } = true;

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

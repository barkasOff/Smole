namespace Smole.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// The current group of the application
        /// </summary>
        public ApplicationPage CurrentGroup { get; set; } = ApplicationPage.GroupContent;

        /// <summary>
        /// Page View Model
        /// </summary>
        public BaseViewModel PageVM { get; set; }

        /// <summary>
        /// Group View Model
        /// </summary>
        public BaseViewModel GroupVM { get; set; }

        /// <summary>
        /// True if we want to dimmed overlay
        /// </summary>
        public bool DimmebleOverlayVisible { get; set; }

        /// <summary>
        /// True if the slide menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; }

        /// <summary>
        /// Flag which help to show bubble
        /// </summary>
        public bool ShowBubble { get; set; } = true;

        /// <summary>
        /// Flag which help to show groups
        /// </summary>
        public bool HasGroup { get; set; }

        /// <summary>
        /// Flag wich help with beatiful slode group page
        /// </summary>
        public bool ShowGroupItems { get; set; }

        /// <summary>
        /// True if the slide menu should be shown
        /// </summary>
        public bool SettingVisible { get; set; }

        /// <summary>
        /// True if user click yesButton
        /// </summary>
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

        /// <summary>
        /// Go to the spacial group with spacial viewModel
        /// </summary>
        /// <param name="group"> Go to?.. </param>
        /// <param name="viewModel"> View model of the page </param>
        public void GoToGroup(ApplicationPage group, BaseViewModel viewModel = null)
        {
            // Change view model
            GroupVM = viewModel;

            // Change page
            CurrentGroup = group;

            // Give signal to change the page
            OnPropertyChanged(nameof(CurrentGroup));
        }
    }
}

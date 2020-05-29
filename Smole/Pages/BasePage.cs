using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using Smole.Core;

namespace Smole
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : Page
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private object mViewModel;

        #endregion

        #region Public Properties

        // The animation the play when the page is first loaded
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        // The animation the play when the page is unloaded
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        // The time any slide animation takes to complete
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The flag to indicate if this page should animate out on Load
        /// Useful when we want to change page frames
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        // Add ViewModel to the page
        public object ViewModelObject
        {
            get => mViewModel;
            set
            {
                // If nothing has changed
                if (mViewModel == value)
                    return;

                mViewModel = value;

                // Set DataContext to this Page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        // Default constructor
        public BasePage()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // If we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility =  Visibility.Collapsed;

            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;
        }

        #endregion

        #region Animation Load / Unload

        // Once the page is loaded, perform any required animation
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                // Animate the page out
                await AnimateOut();
            else
                // Animate the page in
                await AnimateIn();
        }

        // Animates the page in
        public async Task AnimateIn()
        {
            // Make sure we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            if (IoC.Application.CurrentPage == ApplicationPage.Home)
                PageLoadAnimation = PageAnimation.None;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    // Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;

                case PageAnimation.None:
                    // Start the animation
                    await this.FadeIn(this.SlideSeconds);

                    break;
            }
            PageLoadAnimation = PageAnimation.SlideAndFadeInFromRight;
        }

        // Animates the page out
        public async Task AnimateOut()
        {
            // Make sure we have something to do
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }

        #endregion
    }

    /// <summary>
    /// A base page with added viewmodel support
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Public Properties

        // Add ViewModel to the page
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        // Default constructor
        public BasePage() : base()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // Create a default ViewModel
            ViewModel = IoC.Get<VM>();
        }


        // Special constructor to show groups
        public BasePage(VM specificViewModel = null) : base()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // Set specific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
                // Create a default ViewModel
                ViewModel = IoC.Get<VM>();
        }

        #endregion
    }
}

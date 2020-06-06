using Smole.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Smole
{
    /// <summary>
    /// Логика взаимодействия для GroupHost.xaml
    /// </summary>
    public partial class GroupHost : UserControl
    {
        #region Dependency Properties

        // Current page to show in the page host
        public ApplicationPage CurrentGroup
        {
            get => (ApplicationPage)GetValue(CurrentGroupProperty);
            set => SetValue(CurrentGroupProperty, value);
        }

        /// <summary>
        /// Register <see cref="CurrentGroup"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentGroupProperty =
            DependencyProperty.Register(nameof(CurrentGroup), typeof(ApplicationPage), typeof(GroupHost),
                new UIPropertyMetadata(default(ApplicationPage), null, CurrentGroupPropertyChanged));

        /// <summary>
        /// The current group to show in the page host
        /// </summary>
        public BaseViewModel CurrentGroupViewModel
        {
            get => (BaseViewModel)GetValue(CurrentGroupViewModelProperty);
            set => SetValue(CurrentGroupViewModelProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentGroupViewModel"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentGroupViewModelProperty =
            DependencyProperty.Register(nameof(CurrentGroupViewModel),
                typeof(BaseViewModel), typeof(GroupHost),
                new UIPropertyMetadata());


        #endregion

        #region Constructor

        public GroupHost()
        {
            InitializeComponent();
        }

        #endregion

        #region Property Changed Events

        // Called when the <see cref="CurrentPage"/> has changed
        private static object CurrentGroupPropertyChanged(DependencyObject d, object value)
        {
            // Get current values
            var currentGroup = (ApplicationPage)d.GetValue(CurrentGroupProperty);
            var currentGroupViewModel = d.GetValue(CurrentGroupViewModelProperty);

            // Get the Frames
            var newGroupFrame = (d as GroupHost).NewGroup;
            var oldGroupFrame = (d as GroupHost).OldGroup;

            // If the current page hasn't changed
            // just update the view model
            if (newGroupFrame.Content is BaseGroup group)
            {
                // Just update the view model
                group.ViewModelObject = currentGroupViewModel;

                return value;
            }

            // Store the current page content as oldPage
            var oldPageContent = newGroupFrame.Content;

            // Remove current page from new page
            newGroupFrame.Content = null;

            // Move the current page content to the old page
            oldGroupFrame.Content = oldPageContent;

            // Animate out previous page
            if (oldPageContent is BaseGroup oldPage)
            {
                oldPage.ShouldAnimateOut = true;

                // Once it is done, remove it
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    // Remove old page
                    Application.Current.Dispatcher.Invoke(() => oldGroupFrame.Content = null);
                });
            }

            // Set The new page content
            newGroupFrame.Content = new ApplicationValueConverter().Convert(currentGroup, null, currentGroupViewModel);

            return value;
        }

        #endregion
    }
}

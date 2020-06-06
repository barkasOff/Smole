using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smole.Core
{
    public class GroupViewModel : GroupItemListViewModel
    {
        #region Public Properties

        /// <summary>
        /// All groups in the app
        /// </summary>
        public ObservableCollection<GroupItemListViewModel> Groups { get; set; }
            = new ObservableCollection<GroupItemListViewModel>();

        /// <summary>
        /// User groups in the app
        /// </summary>
        public ObservableCollection<GroupItemListViewModel> FilteredGroups { get; set; }
            = new ObservableCollection<GroupItemListViewModel>();

        /// <summary>
        /// All post in the group
        /// </summary>
        public ObservableCollection<GroupViewModel> Posts { get; set; }
            = new ObservableCollection<GroupViewModel>();

        /// <summary>
        /// Text changed when we want to show our or all groups
        /// </summary>
        public string FilterText { get; set; } = "All groups";

        /// <summary>
        /// Flag changed when we want to show our or all groups
        /// </summary>
        public bool GroupFilter { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Filter Groups
        /// </summary>
        public ICommand FilterCommand { get; set; }

        /// <summary>
        /// Filter Groups
        /// </summary>
        public ICommand ShowBubbleCommand { get; set; }

        /// <summary>
        /// Search a group in the SN
        /// </summary>
        public ICommand ShowHamburgerCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Deafault constructor
        /// </summary>
        public GroupViewModel()
        {
            ShowHamburgerCommand = new RelayCommand(ShowHamburgerMethod);
            ShowBubbleCommand = new RelayCommand(ShowBubbleMethod);
            FilterCommand = new RelayCommand(FilterMethod);

            Group borov = new Group
            {
                Name = "B o r o v",
                Initials = "BV",
                ProfilePictureRGB = "ff4"
            };

            Groups.Add(GroupInitialize(borov));
            IoC.Base.Groups.Add(borov);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Filter groups
        /// </summary>
        private void FilterMethod() =>
            // Swap groups
            SwapGroups();

        /// <summary>
        /// Show or hide the bubble
        /// </summary>
        private void ShowBubbleMethod() =>
            IoC.Application.ShowBubble ^= true;

        /// <summary>
        /// Show Hamburger
        /// </summary>
        private void ShowHamburgerMethod()
        {
            IoC.Application.SideMenuVisible ^= true;
            IoC.Application.DimmebleOverlayVisible = true;
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Initialize group in the app
        /// </summary>
        /// <param name="group"> Take group </param>
        /// <returns> Convert group </returns>
        public GroupItemListViewModel GroupInitialize(Group group) =>
             new GroupItemListViewModel
             {
                 Initials = group.Initials,
                 Discription = group.Discription,
                 ProfilePictureRGB = group.ProfilePictureRGB,
                 Name = group.Name,
                 FollowBtnColor = group.FollowBtnColor,
                 UserCount = group.UserCount,
                 NewGroup = true
             };

        /// <summary>
        /// Swap filtered groups
        /// </summary>
        public void SwapGroups()
        {
            // Save value
            var temp = Groups;

            // Change
            Groups = FilteredGroups;
            FilteredGroups = temp;

            // If we change the flag ..
            if (GroupFilter)
                // Set this text
                FilterText = "All Groups";
            // Or ..
            else
                // This text
                FilterText = "User Groups";

            // Change flag
            GroupFilter ^= true;
        }

        /// <summary>
        /// Get user groups
        /// </summary>
        public void GetUserGroups()
        {
            // By all groups
            foreach (var group in IoC.Base.LastUserInTheApp.Groups)
                // Convert and add
                FilteredGroups.Add(GroupInitialize(group));
        }

        #endregion
    }
}

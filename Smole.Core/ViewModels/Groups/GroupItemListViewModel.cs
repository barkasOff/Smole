using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smole.Core
{
    public class GroupItemListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// All posts in the group
        /// </summary>
        public ObservableCollection<PostViewModel> Posts { get; set; }
            = new ObservableCollection<PostViewModel>();

        /// <summary>
        /// Text from textbox to communicate
        /// </summary>
        public string SearchGroup { get; set; }

        /// <summary>
        /// Flag which help us with reesizing
        /// </summary>
        public bool ResizeGroup { get; set; } = true;

        /// <summary>
        /// If we subscribe to the group, btn color changes to gray
        /// </summary>
        public string FollowBtnColor { get; set; } = "ffaa00";

        /// <summary>
        /// Post text from textbox
        /// </summary>
        public string NewPostMessage { get; set; } = "";

        /// <summary>
        /// All Users in the group
        /// </summary>
        public static ObservableCollection<User> GroupUsers { get; set; } = new ObservableCollection<User>();

        /// <summary>
        /// Name of the group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Discription { get; set; } = "Welcome to may group!";

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; } = "NN";

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; } = "FF0000";

        /// <summary>
        /// User Count in a group
        /// </summary>
        public int UserCount { get; set; } = 0;

        /// <summary>
        /// Update the group
        /// </summary>
        public bool NewGroup { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Add Post to the group Command
        /// </summary>
        public ICommand AddPostCommand { get; set; }

        /// <summary>
        /// Open Group
        /// </summary>
        public ICommand OpenGroupCommand { get; set; }

        /// <summary>
        /// Search a group in the SN
        /// </summary>
        public ICommand FindGroupCommand { get; set; }

        /// <summary>
        /// Resize a group in the SN
        /// </summary>
        public ICommand ResizeGroupCommand { get; set; }

        /// <summary>
        /// Clear groups
        /// </summary>
        public ICommand HomeCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GroupItemListViewModel()
        {
            AddPostCommand = new RelayCommand(AddPostMethod);
            HomeCommand = new RelayCommand(HomeMethod);
            OpenGroupCommand = new RelayCommand(OpenGroupMethod);
            FindGroupCommand = new RelayCommand(FindGroupMethod);
            ResizeGroupCommand = new RelayCommand(ResizeGroupMethod);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add post
        /// </summary>
        private void AddPostMethod()
        {
            Posts.Add(new PostViewModel
            {
                Name = this.Name,
                ProfilePictureRGB = this.ProfilePictureRGB,
                Initials = this.Initials,
                PostMessage = NewPostMessage,
                NewPost = true
            });

            NewPostMessage = "";
        }

        /// <summary>
        /// Open group
        /// </summary>
        private void OpenGroupMethod()
        {
            if (IoC.Application.HasGroup == false)
                IoC.Application.HasGroup = true;

            if (IoC.Application.GroupVM != this) 
            {
                this.NewGroup = true;
                IoC.Application.GoToGroup(ApplicationPage.GroupContent, this);
            }
        }

        /// <summary>
        /// Resize group
        /// </summary>
        private void ResizeGroupMethod()
        {
            if (IoC.Application.HasGroup != true)
                return;


            IoC.Application.ResizeGroup ^= true;
        }

        /// <summary>
        /// Search a group in the SN
        /// </summary>
        private void FindGroupMethod()
        {
            foreach (var group in IoC.Base.Groups)
                if (SearchGroup == group.Name)
                {
                    IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Message = "Was found!!" });

                    SearchGroup = "";
                    return;
                }


            IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Title = "Error", Message = "There aren't this group!!" });
        }

        /// <summary>
        /// Clear groups
        /// </summary>
        private void HomeMethod() =>
            IoC.Application.HasGroup = false;

        #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smole.Core
{
    public class PostViewModel : GroupItemListViewModel
    {
        #region Public Properties

        /// <summary>
        /// Post text
        /// </summary>
        public string PostMessage { get; set; } = "Test post in my application..";

        /// <summary>
        /// Post Image
        /// </summary>
        public string PostImage { get; set; }

        /// <summary>
        /// Post Video
        /// </summary>
        public string PostVideo { get; set; }

        /// <summary>
        /// Post Audio
        /// </summary>
        public string PostAudio { get; set; }

        /// <summary>
        /// Post ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Flag when add new post
        /// </summary>
        public bool NewPost { get; set; }

        /// <summary>
        /// Flag when add new post
        /// </summary>
        public bool ShowPostSetting { get; set; }

        #endregion

        #region Comands

        /// <summary>
        /// Show post settings
        /// </summary>
        public ICommand ShowPostSettingCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PostViewModel()
        {
            ShowPostSettingCommand = new RelayCommand(ShowPostSettingMethod);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Show post settings
        /// </summary>
        private void ShowPostSettingMethod() =>
            ShowPostSetting ^= true;

        #endregion
    }
}

﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smole.Core
{
    public class GroupViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// All groups in the app
        /// </summary>
        public ObservableCollection<GroupViewModel> Groups { get; set; } = new ObservableCollection<GroupViewModel>();

        /// <summary>
        /// All post in the group
        /// </summary>
        public ObservableCollection<GroupViewModel> Posts { get; set; } = new ObservableCollection<GroupViewModel>();

        /// <summary>
        /// Base of the new post
        /// </summary>
        public Post Post = new Post();

        #endregion

        #region Commands

        /// <summary>
        /// Open Group
        /// </summary>
        public ICommand OpenGroupCommand { get; set; }

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
        public ICommand FindGroupCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Deafault constructor
        /// </summary>
        public GroupViewModel()
        {
            OpenGroupCommand = new RelayCommand(OpenGroupMethod);
            FilterCommand = new RelayCommand(FilterMethod);
            ShowBubbleCommand = new RelayCommand(ShowBubbleMethod);
            FindGroupCommand = new RelayCommand(FindGroupMethod);
        }
               
        #endregion

        #region Methods

        /// <summary>
        /// Open group
        /// </summary>
        private void OpenGroupMethod()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Filter groups
        /// </summary>
        private void FilterMethod()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Show or hide the bubble
        /// </summary>
        private void ShowBubbleMethod() =>
            IoC.Application.ShowBubble ^= true;

        /// <summary>
        /// Search a group in the SN
        /// </summary>
        private void FindGroupMethod()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

using System;
using System.Windows.Input;

namespace Smole.Core
{
    /// <summary>
    /// For Hamburger control
    /// </summary>
    public class HamburgerViewModel : BaseViewModel
    {
        #region Singelton

        // Singelton prop of this class
        public static HamburgerViewModel Instance => new HamburgerViewModel();

        #endregion

        #region Commands

        /// <summary>
        /// Close hambyrger
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Close hambyrger
        /// </summary>
        public ICommand OpenSettingCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HamburgerViewModel()
        {
            CloseCommand = new RelayCommand(CloseMethod);
            OpenSettingCommand = new RelayCommand(OpenSettingMethod);
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Close hamburger
        /// </summary>
        private void CloseMethod()
        {
            IoC.Application.SideMenuVisible = false;
            IoC.Application.DimmebleOverlayVisible = false;
        }

        /// <summary>
        /// Open setting Control
        /// </summary>
        private void OpenSettingMethod()
        {
            IoC.Application.SettingVisible = true;
            IoC.Application.SideMenuVisible = false;
            IoC.Application.DimmebleOverlayVisible = false;
        }

        #endregion
    }
}

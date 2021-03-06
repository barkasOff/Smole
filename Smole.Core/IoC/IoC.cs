﻿using Ninject;

namespace Smole.Core
{
    /// <summary>
    /// IoC Container for our project
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        // The Kernel for our IoC Container
        public static IKernel Kernel { get; set; } = new StandardKernel();

        /// <summary>
        /// A shotcut to acces a <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shotcut to acces a <see cref="SettingViewModel"/>
        /// </summary>
        public static SettingViewModel Setting => IoC.Get<SettingViewModel>();

        /// <summary>
        /// A shotcut to acces a <see cref="UserItemListViewModel"/>
        /// </summary>
        public static UserItemListViewModel AppUser => IoC.Get<UserItemListViewModel>();

        /// <summary>
        /// A shotcut to acces a <see cref="ApplicationViewModel"/>
        /// </summary>
        public static SmoleBase Base => IoC.Get<SmoleBase>();

        /// <summary>
        /// A shotcut to acces a <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        #endregion

        #region Construction

        // Sets up IoC Container and binds all info
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        // Binds all singelton view models
        private static void BindViewModels()
        {
            // Bind to a singelton ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            // Bind to a singelton SettingViewModel
            Kernel.Bind<SettingViewModel>().ToConstant(new SettingViewModel());

            // Bind to a singelton SettingViewModel
            Kernel.Bind<UserItemListViewModel>().ToConstant(new UserItemListViewModel());

            // Bind to a singelton SmoleBase
            Kernel.Bind<SmoleBase>().ToConstant(new SmoleBase());
        }

        #endregion

        // Get a services
        public static T Get<T>() =>
            Kernel.Get<T>();
    }
}

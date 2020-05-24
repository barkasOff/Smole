using Ninject;

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
        }

        #endregion

        // Get a services
        public static T Get<T>() =>
            Kernel.Get<T>();
    }
}

using Smole.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Smole
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Give app do what it need 
            base.OnStartup(e);

            // Setup the main Application
            ApplicationSetup();

            // Show the MainWindow
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        // Configures our application is ready to use
        private void ApplicationSetup()
        {
            // Setup IoC
            IoC.Setup();

            // Bind a UIManager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            // Load Groups and Users
            IoC.Base.LoadUsers();
        }
    }
}

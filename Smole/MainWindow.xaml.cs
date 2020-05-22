using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            // Add datacontext
            DataContext = new WindowViewModel(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// When we are in the app
        /// </summary>
        private void AppWindow_Activated(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When we aren't in the app
        /// </summary>
        private void AppWindow_Deactivated(object sender, EventArgs e)
        {

        } 

        #endregion
    }
}

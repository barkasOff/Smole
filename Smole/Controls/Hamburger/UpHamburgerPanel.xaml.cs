using Smole.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
    /// Логика взаимодействия для UpHamburgerPanel.xaml
    /// </summary>
    public partial class UpHamburgerPanel : UserControl
    {
        public UpHamburgerPanel()
        {
            InitializeComponent();

            // If we are in design mode...
            if (DesignerProperties.GetIsInDesignMode(this))
                // Create new instance of settings view model
                DataContext = new UserItemListViewModel();
            else
                DataContext = IoC.AppUser;
        }
    }
}

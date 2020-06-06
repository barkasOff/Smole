using Smole.Core;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для GroupView.xaml
    /// </summary>
    public partial class GroupView : BaseGroup<GroupItemListViewModel>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GroupView() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specificViewModel
        /// </summary>
        /// <param name="specificViewModel"> Special View Model to show groups </param>
        public GroupView(GroupItemListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}

using Smole.Core;

namespace Smole
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : BasePage<GroupViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GroupPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public GroupPage(GroupViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}

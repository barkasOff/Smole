using Smole.Core;

namespace Smole
{
    /// <summary>
    /// Логика взаимодействия для GroupView.xaml
    /// </summary>
    public partial class GroupView : BaseGroup<GroupViewModel>
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
        public GroupView(GroupViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}

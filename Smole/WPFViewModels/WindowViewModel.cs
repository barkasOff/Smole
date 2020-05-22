using Smole.Core;
using System.Windows;
using System.Windows.Input;

namespace Smole
{
    /// <summary>
    /// View model to main window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        // The window this view model controls
        private readonly Window mWindow;

        // The margin around the window to allow for a drop shadow
        private readonly int mOuterMarginSize = 10;

        // The radius of the edges of the window
        private int mWindowRadius = 6;

        // The last known dock position
        private readonly WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Members

        // The smallest width the window can go to
        public double WindowMinimumWidth { get; set; } = 800;

        public double WindowHeight { get; set; }

        // The smallest height the window can go to
        public double WindowMinimumHeight { get; set; } = 600;

        // True if the window should be borderless because it is docked or maximized
        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        // The size of the resize border around the window
        public int ResizeBorder => Borderless ? 0 : 3;

        // The size of the resize border around the window, taking into account the outer margin
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        // The margin around the window to allow for a drop shadow
        public int OuterMarginSize
        {
            // If it is maximized or docked, no border
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            set => OuterMarginSize = value;
        }

        // The margin around the window to allow for a drop shadow
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        // The radius of the edges of the window
        public int WindowRadius
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            set => mWindowRadius = value;
        }

        // The radius of the edges of the window
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        // The height of the title bar / caption of the window
        public int TitleHeight { get; set; } = 20;

        // The height of the title bar / caption of the window
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        // The margin around the window to allow for a drop shadow
        public Thickness InnerContentPadding => mWindow.WindowState == WindowState.Maximized ? new Thickness(0) : new Thickness(0);

        // True if we want to dimmed overlay
        public bool DimmebleOverlayVisible { get; set; }

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        public WindowViewModel(Window window)
        {
            mWindow = window;

            WindowHeight = mWindow.Height - TitleHeight - ResizeBorder;

            // Informs about windows changes
            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(InnerContentPadding));
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix Window Resize
            var mWindowResizer = new WindowResizability(mWindow);

        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}

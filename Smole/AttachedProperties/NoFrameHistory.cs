using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Smole
{
    /// <summary>
    /// For <see cref="Frame"/> for never see Navigation Bar
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the Frame
            var frame = (sender as Frame);

            // Hide Navigation Bar
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            // Clear History on Navigate
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}

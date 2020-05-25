using Smole.Core;

namespace Smole
{
    /// <summary>
    /// Locates ViewModels from the IoC to xaml
    /// </summary>
    public class ViewModelLocator
    {
        // Singelton ViewModelLocator
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        // Get Current Page
        public static ApplicationViewModel ApplicationViewModel => IoC.Application;
    }
}

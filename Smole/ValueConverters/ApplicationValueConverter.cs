using Smole.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Smole
{
    public class ApplicationValueConverter : BaseValueConverter<ApplicationValueConverter>
    {
        public override object Convert(object value, Type targetType = null,
            object parameter = null, CultureInfo culture = null)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Home:
                    return new GroupPage();
                    
                case ApplicationPage.Login:
                    return new LoginPage(parameter as LoginViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(parameter as RegisterViewModel);

                case ApplicationPage.GroupContent:
                    return new GroupView(parameter as GroupItemListViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

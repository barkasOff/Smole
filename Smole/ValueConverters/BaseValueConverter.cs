using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Smole
{
    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        // A single static instance of this value converter
        private static T mConverter = null;

        #endregion

        #region Markup Extension Methods

        // Provides a static instance of the value converter 
        public override object ProvideValue(IServiceProvider serviceProvider) => 
            mConverter ?? (mConverter = new T());

        #endregion

        #region Value Converter Methods

        // The method to convert one type to another
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        // The method to convert a value back to it's source type
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}

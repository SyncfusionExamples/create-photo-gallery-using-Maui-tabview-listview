using System.Globalization;

namespace PhotoGallery
{
    public class FavoriteToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isFavorite)
            {
                // Assume '&#xE739;' is the outline and '&#xE73A;' is the filled icon.
                return isFavorite ? "\uE707" : "\uE706";
            }
            return "\uE706"; // Default to outline
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

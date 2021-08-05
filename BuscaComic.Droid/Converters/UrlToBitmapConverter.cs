using Android.Graphics;
using MvvmCross.Converters;
using System;
using System.Globalization;
using System.Net;

namespace BuscaComic.Droid.Converters
{
    public class UrlToBitmapConverter : MvxValueConverter<string, Bitmap>
    {
        protected override Bitmap Convert(string url, Type targetType, object parameter, CultureInfo culture)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        protected override string ConvertBack(Bitmap value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
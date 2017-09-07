using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace net.commons.Extension.WPF
{
    public static class ImageExtensions
    {
        public static bool IsPixelTransparent(this Image image, int x, int y, int tolerance = 0)
        {
            var source = (BitmapSource)image.Source;

            var xx = (int)(x / image.ActualWidth * source.PixelWidth);
            var yy = (int)(y / image.ActualHeight * source.PixelHeight);

            var pixel = new byte[4];
            source.CopyPixels(new Int32Rect(xx, yy, 1, 1), pixel, 4, 0);

            return pixel[3] <= tolerance;
        }
    }
}

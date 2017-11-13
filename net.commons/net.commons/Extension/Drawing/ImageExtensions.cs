using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace net.commons.Extension.Drawing
{
    public static class ImageExtensions
    {
        public static BitmapSource ToBitmapSource(this Bitmap image)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, new Int32Rect(0, 0, image.Width, image.Height), BitmapSizeOptions.FromEmptyOptions());
        }
    }
}

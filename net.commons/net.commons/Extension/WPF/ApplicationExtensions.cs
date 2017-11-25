using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Net.Commons.Extension.WPF
{
    public static class ApplicationExtensions
    {
        public static Window GetWindowOfType<T>(this Application application) where T : Window
        {
            return application.Windows.OfType<T>().FirstOrDefault();
        }

        public static Window GetActiveWindow(this Application application)
        {
            return application.Windows.Cast<Window>().FirstOrDefault(window => window.IsActive);
        }
    }
}

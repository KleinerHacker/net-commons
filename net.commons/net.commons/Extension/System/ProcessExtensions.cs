using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using net.commons.Extension.Drawing;

namespace net.commons.Extension.System
{
    public static class ProcessExtensions
    {
        public static Icon GetProcessIcon(this Process process)
        {
            return Icon.ExtractAssociatedIcon(process.MainModule.FileName);
        }

        public static BitmapSource GetProcessIconBitmapSource(this Process process)
        {
            return GetProcessIcon(process).ToBitmapSource();
        }

        public static bool HasWindow(this Process process)
        {
            return process.MainWindowHandle != IntPtr.Zero;
        }

        public static bool IsForeground(this Process process)
        {
            var foregroundWindow = GetForegroundWindow();
            if (foregroundWindow == IntPtr.Zero)
                return false;

            int id;
            GetWindowThreadProcessId(foregroundWindow, out id);

            return process.Id == id;
        }

        public static ProcessController GetProcessController(this Process process)
        {
            return new ProcessController(process);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out int processId);
    }

    public sealed class ProcessController
    {
        public bool HasWindow => _process.MainWindowHandle != IntPtr.Zero;

        private readonly Process _process;

        internal ProcessController(Process process)
        {
            _process = process;
        }

        public void ShowWindow()
        {
            if (_process.HasExited)
                throw new InvalidOperationException("Process with id " + _process.Id + " has died");
            if (!HasWindow)
                throw new InvalidOperationException("Process with id " + _process.Id + " has no window.");

            ShowWindow(_process.MainWindowHandle, 0x0001 | 0x0002);
            SetForegroundWindow(_process.MainWindowHandle);
        }

        public void HideWindow()
        {
            if (_process.HasExited)
                throw new InvalidOperationException("Process with id " + _process.Id + " has died");
            if (!HasWindow)
                throw new InvalidOperationException("Process with id " + _process.Id + " has no window.");

            ShowWindow(_process.MainWindowHandle, 0);
        }

        #region Natives

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr intPtr, uint cmd);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr intPtr);

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenOff
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(IntPtr dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        private const int MOVE = 0x0001;
        private const int HWND_BROADCAST = 0xffff;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MONITORPOWER = 0xF170;

        static public void SomeMethod()
        {
            SendMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
            mouse_event((IntPtr)MOVE, 0, 0, 0, UIntPtr.Zero);
        }
        static void Main(string[] args)
        {
            SomeMethod();
        }
    }
}

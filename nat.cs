using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RU_Browser
{
    internal sealed class NativeMethods
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
            public RECT(Rectangle bounds)
            {
                this.Left = bounds.Left;
                this.Top = bounds.Top;
                this.Right = bounds.Right;
                this.Bottom = bounds.Bottom;
            }
            public override string ToString()
            {
                return String.Format("{0}, {1}, {2}, {3}", Left, Top, Right, Bottom);
            }
        }

        public const int WM_NCLBUTTONDBLCLK = 0xA3;

        public const int WM_SETCURSOR = 0x20;

        public const int WM_NCHITTEST = 0x84;

        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_MOVING = 0x216;
        public const int WM_EXITSIZEMOVE = 0x232;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref TCHITTESTINFO lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct TCHITTESTINFO
        {
            public Point pt;
            public TCHITTESTFLAGS flags;
            public TCHITTESTINFO(Point point)
            {
                pt = point;
                flags = TCHITTESTFLAGS.TCHT_ONITEM;
            }
        }

        [Flags()]
        public enum TCHITTESTFLAGS
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        public const int TCM_HITTEST = 0x130D;

    }

    public enum TabDragBehavior
    { None, TabDragArrange, TabDragOut }
}

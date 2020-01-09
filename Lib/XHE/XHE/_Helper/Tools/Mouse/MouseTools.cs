using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XHE._Helper.Tools.Mouse
{
    public class MouseTools
    {
        #region Win32

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(int nInputs, INPUT[] pInputs, int cbSize);
        
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)] public int type;

            [FieldOffset(4)] public MOUSEINPUT mi;

            [FieldOffset(4)] public KEYBDINPUT ki;

            [FieldOffset(4)] public HARDWAREINPUT hi;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private const int INPUT_MOUSE = 0;
        private const int INPUT_KEYBOARD = 1;
        private const int INPUT_HARDWARE = 2;
        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const uint KEYEVENTF_UNICODE = 0x0004;
        private const uint KEYEVENTF_SCANCODE = 0x0008;
        private const uint XBUTTON1 = 0x0001;
        private const uint XBUTTON2 = 0x0002;
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const uint MOUSEEVENTF_XDOWN = 0x0080;
        private const uint MOUSEEVENTF_XUP = 0x0100;
        private const uint MOUSEEVENTF_WHEEL = 0x0800;
        private const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        #endregion

        #region эмул€ци€ движени€ мыши
        // emullate move to selected point 	
        static public bool Move(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            return true;
        }
        #endregion

        #region эмул€ци€ работы с левой кнопкой мыши
        // emullate click to selected point
        static public bool Click(int X, int Y)
        {
            // зададим позицию
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[2];
            input[0].type = input[1].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // структура дл€ отжать левую кнопку
            input[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;
            input[1].mi.dwExtraInfo = new IntPtr(0);
            input[1].mi.mouseData = 0;
            input[1].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 2;
        }
        // emullate left button down 
        static public bool LeftButtonDown(int X, int Y)
        {
            // зададим позицию
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[1];
            input[0].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 1;
        }
        // emullate left button up 
        static public bool LeftButtonUp(int X, int Y)
        {
            // зададим позицию
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[1];
            input[0].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_LEFTUP;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 1;
        }
        // emullate double click
        static public bool DoubleClick(int X, int Y)
        {
            // зададим позицию
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[4];
            input[0].type = input[1].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // структура дл€ отжать левую кнопку
            input[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;
            input[1].mi.dwExtraInfo = new IntPtr(0);
            input[1].mi.mouseData = 0;
            input[1].mi.time = 10;

            input[3].type = input[4].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[3].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            input[3].mi.dwExtraInfo = new IntPtr(0);
            input[3].mi.mouseData = 0;
            input[3].mi.time = 10;

            // структура дл€ отжать левую кнопку
            input[4].mi.dwFlags = MOUSEEVENTF_LEFTUP;
            input[4].mi.dwExtraInfo = new IntPtr(0);
            input[4].mi.mouseData = 0;
            input[4].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 4;
        }
        #endregion

        #region эмул€ци€ работы с правой кнопкой мыши
        // emullate right button click
        static public bool RightButtonClick(int X, int Y)
        {
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[2];
            input[0].type = input[1].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // структура дл€ отжать левую кнопку
            input[1].mi.dwFlags = MOUSEEVENTF_RIGHTUP;
            input[1].mi.dwExtraInfo = new IntPtr(0);
            input[1].mi.mouseData = 0;
            input[1].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 2;
        }

        // emullate right button down
        static public bool RightButtonDown(int X, int Y)
        {
            Move(X,Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[1];
            input[0].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 1;
        }

        // emullate right button up
        static public bool RightButtonUp(int X, int Y)
        {
            // зададим позицию
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[1];
            input[0].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_RIGHTUP;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = 10;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 1;
        }
        #endregion

        #region эмул€ци€ работы с колесом мыши
        // emullate move wheel
        static public bool Wheel(int iTime, int X, int Y)
        {
            // зададим позицию
            Move(X, Y);

            // сформируем структуру дл€ подачи в очередь устройства
            INPUT[] input = new INPUT[1];
            input[0].type = INPUT_MOUSE;

            // структура дл€ нажать левую кнопку
            input[0].mi.dwFlags = MOUSEEVENTF_WHEEL;
            input[0].mi.dwExtraInfo = new IntPtr(0);
            input[0].mi.mouseData = 0;
            input[0].mi.time = (uint)iTime;

            // пошлем команду на устройство
            uint res = SendInput(input.Length, input, Marshal.SizeOf(input[0].GetType()));
            return res == 1;
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace XHE._Helper.Tools.Keyboard
{
    public class KeyboardTools
    {
        #region Win32

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, IntPtr dwExtraInfo);

        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;

        #endregion

        #region работа с рабочими клавишами
        // emulate key up
        static public bool KeyUp(char Key)
        {
            // код клавиши
            byte Lo = Convert.ToByte(Key & 0xFF);
            byte Hi = Convert.ToByte(Key >> 8);

            // нажать шифт если надо
            if ((Hi & 1) != 0)
                keybd_event(Convert.ToByte(Keys.Shift), 0, KEYEVENTF_KEYUP, new IntPtr(0));

            // нажать клавишу
            keybd_event(Lo, 0, KEYEVENTF_KEYUP, new IntPtr(0));

            return true;
        }

        // emulate key down
        static public bool KeyDown(char Key)
        {
            // код клавиши
            byte Lo = Convert.ToByte(Key & 0xFF);
            byte Hi = Convert.ToByte(Key >> 8);

            // нажать шифт если надо
            if ((Hi & 1) != 0)
                keybd_event(Convert.ToByte(Keys.Shift), 0, 0, new IntPtr(0));

            // нажать клавишу
            keybd_event(Lo, 0, 0, new IntPtr(0));

            return true;
        }
        #endregion

        #region работа с управл€ющими клавишами

        // set control key prefix (on/of)
        static public bool SetControlKeyPrefix(bool bPress,Keys Key)
        {
            // держать либо отпустить
            if (bPress)
                keybd_event(Convert.ToByte(Key), 0x45, KEYEVENTF_EXTENDEDKEY, new IntPtr(0));
            else
                keybd_event(Convert.ToByte(Key), 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, new IntPtr(0));

            return true;
        }

        // emulate press Indicate key
        static public bool PressIndicateKey(Keys Key)
        {
            keybd_event(Convert.ToByte(Key), 0x45, KEYEVENTF_EXTENDEDKEY, new IntPtr(0));
            keybd_event(Convert.ToByte(Key), 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, new IntPtr(0));
            return true;
        }

        #endregion
    }
}

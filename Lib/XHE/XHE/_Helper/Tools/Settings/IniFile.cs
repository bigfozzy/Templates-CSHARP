using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace XHE._Helper.Tools.Settings
{
    public class IniFile
    {
        [DllImport("kernel32", SetLastError = true)]
        private static extern int WritePrivateProfileString(string psSection, string psKey, string psValue, string psFile);
        [DllImport("kernel32", SetLastError = true)]
        private static extern int GetPrivateProfileString(string psSection, string psKey, string psDefault, byte[] psrReturn, int piBufferLen, string psFile);
        private string m_Filename;
        private int m_iBufferLen = 10000;

        public IniFile(string strFilename)
        {
            m_Filename = strFilename;
        }

        public string ReadValue(string strSection, string strKey, string strDefault)
        {
            byte[] sGetBuffer = new byte[this.m_iBufferLen];
            ASCIIEncoding oAscii = new ASCIIEncoding();
            int i = GetPrivateProfileString(strSection, strKey, strDefault, sGetBuffer, this.m_iBufferLen, this.m_Filename);
            return oAscii.GetString(sGetBuffer, 0, i);
        }

        public void WriteValue(string strSection, string strKey, string strValue)
        {
            WritePrivateProfileString(strSection, strKey, strValue, this.m_Filename);
        }

        public void ReadValues(string strSection, ref Array arrValues)
        {
            byte[] sGetBuffer = new byte[this.m_iBufferLen];
            int i = GetPrivateProfileString(strSection, null, null, sGetBuffer, this.m_iBufferLen, this.m_Filename);
            if (i != 0)
            {
                ASCIIEncoding oAscii = new ASCIIEncoding();
                arrValues = oAscii.GetString(sGetBuffer, 0, i - 1).Split((char)0);
            }
        }

        public void ReadSections(ref Array arrSections)
        {
            byte[] sGetBuffer = new byte[this.m_iBufferLen];
            int i = GetPrivateProfileString(null, null, null, sGetBuffer, this.m_iBufferLen, this.m_Filename);
            if (i != 0)
            {
                ASCIIEncoding oAscii = new ASCIIEncoding();
                arrSections = oAscii.GetString(sGetBuffer, 0, i - 1).Split((char)0);
            }
        }

        public void RemoveSection(string strSection)
        {
            WritePrivateProfileString(strSection, null, null, this.m_Filename);
        }

    }

}

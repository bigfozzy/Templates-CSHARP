using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace XHE
{
    // base class for script
    public class XHEScriptBase
    {
        // закладка сервера
        public int server_tab = -1;

        #region other

        // пазуа
        static public void sleep(int iSecond)
        {
            Thread.Sleep(iSecond * 1000);
        }
        // пазуа
        static public void Sleep(int iSecond)
        {
            Thread.Sleep(iSecond * 1000);
        }
        // convert string to int
        static public int ToInt(string sString)
        {
            return Convert.ToInt32(sString);
        }

        #endregion

        #region echo

        // echo string to console
        static public void echo(string sText)
        {
            Console.Write(sText);
        }
        // echo bool to console
        static public void echo(bool bText)
        {
            Console.Write(bText.ToString());
        }
        // echo double to console
        static public void echo(double dText)
        {
            Console.Write(dText.ToString());
        }
        // echo float to console
        static public void echo(float fText)
        {
            Console.Write(fText.ToString());
        }
        // echo string[] to console
        static public void echo(string[] sString)
        {
            if (sString != null)
            {
                for (int i = 0; i < sString.Length; i++)
                    Console.Write("[" + i.ToString() + "] = [" + sString[i] + "]\n");

                if (sString.Length == 0)
                    Console.WriteLine("[empty]");
            }
            else
                Console.WriteLine("[null]");
        }
        // echo List<string> to console
        static public void echo(List<string> sString)
        {
            if (sString != null)
            {
                for (int i = 0; i < sString.Count; i++)
                    Console.Write("[" + i.ToString() + "] = [" + sString[i] + "]\n");

                if (sString.Count == 0)
                    Console.WriteLine("[empty]");
            }
            else
                Console.WriteLine("[null]");
        }
        // echo List<bool> to console
        static public void echo(List<bool> bString)
        {
            if (bString != null)
            {
                for (int i = 0; i < bString.Count; i++)
                    Console.Write("[" + i.ToString() + "] = [" + bString[i] + "]\n");

                if (bString.Count == 0)
                    Console.WriteLine("[empty]");
            }
            else
                Console.WriteLine("[null]");
        }
        // echo List<int> to console
        static public void echo(List<int> bString)
        {
            if (bString != null)
            {
                for (int i = 0; i < bString.Count; i++)
                    Console.Write("[" + i.ToString() + "] = [" + bString[i].ToString() + "]\n");

                if (bString.Count == 0)
                    Console.WriteLine("[empty]");
            }
            else
                Console.WriteLine("[null]");
        }

        #endregion
    }
}

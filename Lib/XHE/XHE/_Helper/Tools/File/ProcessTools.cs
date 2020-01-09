using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XHE._Helper.Tools.File
{
    public class ProcessTools
    {
        #region WinAPI

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        #endregion

        /// <summary>
        /// удалить процесс по заданому имени
        /// </summary>
        /// <returns></returns>
        public static bool KillProcess(string name)
        {
            // получим процессы с заданым именем
            var processes = Process.GetProcesses().
                Where(pr => pr.ProcessName == name);

            // удалим их
            foreach (var process in processes)
                process.Kill();

            // результат            
            return true;
        }

        /// <summary>
        /// Launch the legacy application with some options set.
        /// </summary>
        public static bool RunApp(string path,string args,bool bShow=true,bool bWaitForExec=true)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = path;
            startInfo.Verb = "runas";
            startInfo.WindowStyle = (bShow) ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;            
            startInfo.Arguments = args;

            try
            {
                // Start the process with the info we specified. Call WaitForExit and then the using statement will close.
                Process exeProcess = Process.Start(startInfo);
                if (bWaitForExec)
                    exeProcess.WaitForExit();
                return true;
            }
            catch
            {
                return false;
            }            
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using XHE._Helper.Tools.File;

namespace XHE._Helper.Tools.Log
{
    /// <summary>
    /// tools of loging
    /// </summary>
    public class LogTools
    {
        #region variables

        // TextBox for output log
        public static TextBox tbLog = null;

        #endregion

        #region log events

        static Object lockLog=new Object();

        /// <summary>
        /// write event to main log
        /// </summary>
        /// <param name="_event">log event</param>        
        public static void LogEvent(string _event)
        {
            lock (lockLog)
            {
                // log string
                string logEvent = DateTime.Now + "   :   " + _event + "\r\n";

                // add event to TextBox
                if (tbLog != null)
                {
                    if (tbLog.Text.Length > 90000)
                        tbLog.Text = "<Cleared>";
                    tbLog.Text = tbLog.Text + logEvent;
                    tbLog.Select(tbLog.Text.Length - 1, tbLog.Text.Length - 1);
                    tbLog.ScrollToCaret();
                    Application.DoEvents();
                }

                // log file path
                if (!Directory.Exists(Application.StartupPath + "\\Logs\\"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Logs\\");
                string sLogFilePath = Application.StartupPath + "\\Logs\\log.txt";

                // add event to file                    
                TextFileTools.AddTextToFile(sLogFilePath, logEvent);
            }
        }
        /// <summary>
        /// write event to any log file
        /// </summary>
        /// <param name="_event">log event</param>
        /// <param name="logFilePath">log file path</param>
        public static void LogEventToFile(string _event, string logFilePath)
        {
            lock (lockLog)
            {
                string logEvent = DateTime.Now + "   :   " + _event + "\r\n";

                // add event to file                    
                TextFileTools.AddTextToFile(logFilePath, logEvent);
            }
        }
        #endregion

        #region operations

        /// <summary>
        /// show text log trought shell
        /// </summary>
        /// <param name="logFilePath">log file path</param>
        public static void ShowTextLog(string logFilePath)
        {
            lock (lockLog)
            {
                if (System.IO.File.Exists(logFilePath))
                    FileTools.ShowFile(logFilePath);
                else
                    MessageBox.Show("Log: " + logFilePath + " is empty");
            }
        }

        #endregion
    }
}

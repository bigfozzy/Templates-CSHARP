using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XHE._Helper.Tools.File;
using XHE._Helper.Tools.Folder;
using XHE._Helper.Tools.GUI;

namespace XHE
{
    // приложение
    public class XHEApp
    {
        // путь
        private string path;
        // порт
        private int port;
        public int GetPort()
        {
            try
            {
                string portFile = FileTools.GetFileFolder(path) + "port.txt";
                string portStr = TextFileTools.ReadFile(portFile, "windows-1251");
                port = Convert.ToInt32(portStr);
            }
            catch (Exception)
            {
                port = 7010;
            }
            return port;
        }

        /// <summary>
        /// статус что прямо сейчас запущен
        /// </summary>
        public bool IsStarted { get; set; }

        /// <summary>
        /// подготовить папку XHE для заданного порта
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        bool PrepareXHEFolder(int port)
        {

            // папки
            string srcFolder = Application.StartupPath + "\\XHE\\Src\\";
            string targedFolder = Application.StartupPath + "\\XHE\\" + port.ToString() + "\\";

            // удалим XHE - если такой запущен
            ProcessTools.KillProcess(targedFolder + port.ToString() + ".exe");

            // очистим папку            
            FolderTools.ClearFolder(targedFolder);
            // скоипруем
            FolderTools.Copy(srcFolder, targedFolder, true);

            // укажем порт
            TextFileTools.WriteFile(targedFolder + "port.txt", port.ToString(), "windows-1251");
            // переименуем XHE
            try
            {
                File.Move(targedFolder + "XHE.exe", targedFolder + port.ToString() + ".exe");
            }
            catch (Exception)
            {

            }

            // укажем что папка подготовлена
            TextFileTools.WriteFile(targedFolder + port.ToString() + ".exe.ready", "folder ready", "windows-1251");
            // лог
            //onScriptLog?.Invoke(this, "поток подготовлен");

            return true;
        }

        // конструткор (создать и запустить хуман из заданного пути на заданнм порту)
        public XHEApp(string path,int port)
        {
            // данные о приложении
            this.path = path;
            this.port = port;

            // проверим что папка готова
            if (!File.Exists(path + ".ready"))
                PrepareXHEFolder(port);

            // не запущен
            IsStarted = false;

            // подготовим аргументы
            string args = "/port:\"" + port.ToString() + "\"";
            // запустим хуман
            if (File.Exists(path))
            {
                try
                {
                    // удалим процесс - если он был запущен
                    ProcessTools.KillProcess(port.ToString());
                }
                catch (Exception)
                {

                }
                // запустим процесс по новой
                IsStarted = ProcessTools.RunApp(path, args, true, false);                
            }
            else
                ShowMessage.ShowWarningMessage("Human Emulator not found for path : " + path);
        }
    }
}

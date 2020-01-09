using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using XHE;

namespace XHE._Helper.Tools.File
{
    /// <summary>
    /// инструменты для работы с фалом
    /// </summary>
    public class FileTools
    {

        #region выбор файла

        /// <summary>
        /// выбрать файл с диска
        /// </summary>
        /// <param name="dlg">стандартный диалог</param>
        /// <param name="sRegName">путь в реестре для запоминания предыдущего выбора</param>
        /// <param name="sPath">выбраный путь</param>
        /// <returns>true - если выбрали</returns>
        public static bool SelectFile(FileDialog dlg, string regName, ref string path)
        {
            //dlg.FileName = Application..GetValue(regName, path) as string;
            dlg.FileName = path;
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                path = "";
                return false;
            }
            //Application.CommonAppDataRegistry.SetValue(regName, dlg.FileName);
            path = dlg.FileName;
            return true;
        }

        /// <summary>
        /// выбрать файл по кнопке диалога
        /// </summary>
        /// <param name="path">исходный путь</param>
        /// <param name="functionName">имя операции</param>
        /// <param name="tbSettings">текстовое окно</param>
        /// <param name="dlgOpenFile">диалог открытия</param>
        /// <returns>true - если все ок</returns>
        static public bool SelectFileForTextBox(string path, string functionName, TextBox tbSettings, OpenFileDialog dlgOpenFile)
        {
            // выбор файла
            if (!SelectFile(dlgOpenFile, functionName, ref path))
                return false;

            tbSettings.Text = path;
            return true;

        }

        #endregion

        #region получение инфы по файлу

        /// <summary>
        /// вернуть размер файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>размер файла</returns>
        static public long GetSize(string path)
        {
            if (System.IO.File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                return fi.Length;
            }
            else
                return -1;
        }
        /// <summary>
        /// вернуть дату создания файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>размер файла</returns>
        static public string GetCreationDate(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.CreationTime.ToString();
        }
        /// <summary>
        /// вернуть дату последнего доступа файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>размер файла</returns>
        static public string GetAccessDate(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.LastAccessTime.ToString();
        }
        /// <summary>
        /// вернуть дату последнего изменения файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>размер файла</returns>
        static public string GetModificationDate(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.LastWriteTime.ToString();
        }
        /// <summary>
        /// получить папку файла по его пути
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>возвращает папку файла</returns>
        public static string GetFileFolder(string path)
        {
            // сортировка
            string sFolder = path;
            int iIndex = sFolder.LastIndexOf('\\');
            sFolder = sFolder.Substring(0, iIndex + 1);
            return sFolder;
        }
        /// <summary>
        /// получить имя файла по его пути
        /// </summary>
        /// <param name="sPath">путь к файлу</param>
        /// <returns>возвращает имя файла (и расширение)</returns>
        public static string GetFileName(string path)
        {
            // сортировка
            string sName = path;
            int iIndex = sName.LastIndexOf('\\');
            sName = sName.Substring(iIndex + 1, sName.Length - iIndex - 1);
            return sName;
        }
        /// <summary>
        /// получить расширение файла по его пути
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>возвращает расширение файла</returns>
        public static string GetFileExtension(string path)
        {
            // проверка
            if (path == null)
                return null;

            // сортировка
            string sExt = path;
            int iIndex = sExt.LastIndexOf('.');
            if (iIndex != -1)
                sExt = sExt.Substring(iIndex + 1, sExt.Length - iIndex - 1);
            else
                sExt = "";
            return sExt;
        }

        #endregion

        #region операции с файлом

        /// <summary>
        /// открыть и показать файл, ассоциированной с ним в системе программой
        /// </summary>
        /// <param name="path"></param>
        public static bool ShowFile(string path)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.Arguments=" /C start" + " " + path;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = true;            
            return proc.Start();
        }

        /// <summary>
        /// распаковать rar - архив в заданную папку
        /// </summary>
        /// <param name="rarFilePath">путь к рар - архиву</param>
        /// <param name="toFolder">папка, куда распаковывать</param>
        /// <returns></returns>
        static public bool UnpackFile(string rarFilePath, string toFolder)
        {
            // скопируем файл что надо распоковать в нужную папку
            string sCopyFilePath = toFolder + GetFileName(rarFilePath);
            int i = 0;
            while (System.IO.File.Exists(sCopyFilePath))
            {
                sCopyFilePath += toFolder + i.ToString() + GetFileName(rarFilePath);
                i++;
            }

            System.IO.File.Copy(rarFilePath, sCopyFilePath, false);
            rarFilePath = sCopyFilePath;

            ///// создадим bat - файл для распаковки
            // путь к bat-файлу
            string sBatPath = toFolder + "unrar.bat";

            // содержимое bat фай-ла
            string sBatContent = "rar.exe x -ac \"" + rarFilePath + "\"\r\n";
            sBatContent += "del \"" + sBatPath + "\"\r\n";

            // сохраним bat- файл
            TextFileTools.WriteFile(sBatPath, sBatContent);

            ///// выполним распаковку
            Process proc = new Process();
            proc.StartInfo.FileName = sBatPath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.WorkingDirectory = toFolder;
            proc.Start();
            proc.WaitForExit();

            // удалим лишние файлы
            System.IO.File.Delete(sBatPath);
            System.IO.File.Delete(rarFilePath);

            return true;
        }
        /// <summary>
        /// запишем файл
        /// </summary>
        /// <param name="path">путь к файл</param>
        /// <param name="aContent">содержимое файла</param>
        /// <returns>true - если все ok</returns>
        public static bool WriteFile(string path, byte[] aContent)
        {
            FileStream FS = new FileStream(path, FileMode.OpenOrCreate);
            FS.Write(aContent, 0, aContent.Length);
            FS.Close();

            return true;
        }
        /// <summary>
        /// прочитаем содержимое файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>содержимое файла или null</returns>
        public static byte[] ReadFile(string path)
        {
            FileStream FS = new FileStream(path, FileMode.OpenOrCreate);
            byte[] aContent = new byte[FS.Length];
            FS.Read(aContent, 0, aContent.Length);
            FS.Close();

            return aContent;
        }
        /// <summary>
        /// удалим файлы
        /// </summary>
        /// <param name="aFilesPaths">пути к файлам</param>
        /// <returns>true - если все ok</returns>
        public static bool DeleteFiles(string[] aFilesPaths)
        {
            // удалим
            foreach (string sPath in aFilesPaths)
                System.IO.File.Delete(sPath);

            // ok
            return true;
        }

        #endregion
    }
}

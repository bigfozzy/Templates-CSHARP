using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using XHE._Helper.Tools.Log;
using XHE._Helper.Tools.File;

namespace XHE._Helper.Tools.Folder
{
    /// <summary>
    /// класс инструментов для работы с папкой текстовых файлов
    /// </summary>
    public class FolderTextFilesTools
    {
        #region операции файлы в файл

        /// <summary>
        /// соединить все тектсовые файлы в один файл
        /// </summary>
        /// <param name="aFiles">массив с путями к файлам</param>
        /// <param name="sDestinationPath">путь к результирующему файлу</param>
        /// <returns>если все OK то true</returns>
        public static bool CombineFiles(string[] aFiles, string sDestinationPath)
        {
            // куда писать
            if (System.IO.File.Exists(sDestinationPath))
            {
                MessageBox.Show("Destination file " + sDestinationPath + " already exist");
                return false;
            }
            // проверим что есть что писать
            if (aFiles.Length == 0)
            {
                MessageBox.Show("Files list is empty for combining");
                return false;
            }

            // скопируем 1 файл
            System.IO.File.Copy(aFiles[0], sDestinationPath);

            // откроем на дозаполнение 
            FileStream fs = new FileStream(sDestinationPath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("windows-1251"));

            // пройдемся по файлам
            Application.UseWaitCursor = true;
            string sFilePath = "";
            for (int i = 1; i < aFiles.Length; i++)
            {
                // события
                Application.DoEvents();

                // начнем чтение
                sFilePath = aFiles[i];
                using (StreamReader sr = new StreamReader(sFilePath, Encoding.GetEncoding("windows-1251")))
                {
                    string line;
                    while (true)
                    {
                        // прочитаем
                        line = sr.ReadLine();

                        // если пусто - перейдем к следующему файлу
                        if (line == null)
                        {
                            sr.Close();
                            break;
                        }

                        // запишем
                        sw.WriteLine(line);
                    }
                }
            }
            Application.UseWaitCursor = false;

            // закрыть куда писать
            sw.Close();
            fs.Close();

            return true;
        }

        /// <summary>
        /// собрать текстовые файлы в папке и ее подпапках в один файл
        /// </summary>
        /// <param name="sInFolderPath"></param>
        /// <param name="sOutFilePath"></param>
        /// <returns></returns>
        public static int CollectFromFoldersToFile(string sInFolderPath, string sOutFilePath)
        {
            Application.UseWaitCursor = true;

            // получим все файлы
            List<string> aPaths = new List<string>();
            FolderTools.GetAllFilesInFolder(sInFolderPath, "*.txt", true, false, true, aPaths);

            // куда писать
            FileStream fs = new FileStream(sOutFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("windows-1251"));

            // пройдемся по всем путям
            int iNum = -1;
            foreach (string sFilePath in aPaths)
            {
                if (Directory.Exists(sFilePath))
                    continue;
                iNum++;

                Application.DoEvents();
                // начнем чтение
                using (StreamReader sr = new StreamReader(sFilePath, Encoding.GetEncoding("windows-1251")))
                {
                    string line;
                    while (true)
                    {
                        line = sr.ReadLine();
                        // если пусто - перейдем к следующему файлу
                        if (line == null)
                        {
                            sr.Close();
                            break;
                        }
                        sw.WriteLine(line);
                    }
                }
            }

            // закрыть куда писать
            sw.Close();
            fs.Close();

            Application.UseWaitCursor = false;
            // число файлов
            return iNum + 1;
        }

        #endregion

        #region операции файлы в файлы

        /// <summary>
        /// убрать дубликаты файлов
        /// </summary>
        /// <param name="aFiles"></param>
        /// <param name="sDestinationPath"></param>
        /// <returns></returns>
        public static bool DedupeFiles(string[] aFiles, string sDestinationPath, bool bIsSorted)
        {
            // проверка что нужно что-то делать
            if (aFiles.Length == 0)
            {
                LogTools.LogEvent("No files");
                return false;
            }
            Application.UseWaitCursor = true;

            // выходной путь
            if (sDestinationPath == "")
            {
                sDestinationPath = FileTools.GetFileFolder(aFiles[0]) + "Deduped\\";
                Directory.CreateDirectory(sDestinationPath);
            }

            // пройдемся по файлам
            foreach (string sFilePath in aFiles)
            {
                Application.DoEvents();

                // путь, куда записать файл
                string sDestinationFile = sDestinationPath + FileTools.GetFileName(sFilePath);
                if (TextFileTools.DedupeFile(sFilePath, sDestinationFile, bIsSorted))
                    LogTools.LogEvent("Result save to: " + sDestinationFile);
                else
                    LogTools.LogEvent("Not maked. Error");
            }
            return true;
        }

        #endregion

    }
}

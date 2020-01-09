using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using XHE._Helper.Tools.Log;

namespace XHE._Helper.Tools.File
{
    /// <summary>
    /// инстрцументы для работы с текстовым файлом
    /// </summary>
    public class TextFileTools
    {

        #region настройки

        // плохие символы
        public static char[] aBad = new char[]
            {
                'џ', 'ў', 'ј', 'ї', 'і','ѕ','є','ґ'
            };
        // символы перевода строки
        public static char[] aCarrets = new char[]
            {
                '\n', '\r'
            };

        #endregion

        #region получить информацию

        /// <summary>
        /// получить число строк в файле
        /// </summary>
        /// <param name="path">путь к текстовому файлу</param>
        /// <returns>число строк в файле/returns>
        public static Int64 GetLinesCount(string path,string encoding= "windows-1251")
        {
            // результат
            Int64 lineCount = -1;

            // проверить существование
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("File " + path + " is not exist");
                return lineCount;
            }

            // получить число строк
            lineCount = 0;            
            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(encoding)))
            {
                while ((sr.ReadLine()) != null)
                    lineCount++;
                sr.Close();
            }            
            
            // вернем
            return lineCount;
        }

        #endregion

        #region чтение и запись

        /// <summary>
        /// записать текстовый файл
        /// </summary>
        /// <param name="path">путь к текстовому файлу</param>
        /// <param name="content">новое содержимое</param>
        /// <param name="encoding">кодировка содержимого</param>
        /// <returns>true - если все ok</returns>
        public static bool WriteFile(string path, string content, string encoding= "windows-1251")
        {
            try
            {
                // удалим старый файл
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                // запишем
                FileStream FS = new FileStream(path, FileMode.CreateNew);
                StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding(encoding));
                SW.Write(content);
                SW.Close();
                FS.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// добавить текст к текстовому файлу
        /// </summary>
        /// <param name="path">путь к текстовому файлу</param>
        /// <param name="content">добавляемое содержимое</param>
        /// <param name="encoding">кодировка содержимого</param>
        /// <returns>true - если все ok</returns>
        public static bool AddTextToFile(string path, string content, string encoding= "windows-1251")
        {
            // создадим файл - если не существует
            if (!System.IO.File.Exists(path))
                System.IO.File.Create(path);

            // добавим
            FileStream FS = new FileStream(path, FileMode.Append);
            StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding(encoding));
            SW.Write(content);
            SW.Close();
            FS.Close();

            return true;
        }

        /// <summary>
        /// прочитать текстовый файл
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="encoding">кодировка</param>
        /// <returns>содержимое файла или null - если его нет</returns>
        public static string ReadFile(string path, string encoding= "windows-1251")
        {
            // проверить существования файла
            if (!System.IO.File.Exists(path))
                return null;

            // считать файл
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(encoding));
            string sRes = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();

            // вернем результат
            return sRes;
        }

        // прочитать заданную строку из файла ($path- путь к файлу , $line - номер строки в файле с нуля)
        public static string GetLine(string path,long line, string encoding = "windows-1251")
        {
            if (!System.IO.File.Exists(path))
                return null;

		    string result = null;

            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(encoding)))
            {
                int iLineCount = 0; string tmp;
                while (true)
                {
                    tmp = sr.ReadLine();
                    if (tmp == null)
                        break;
                    if (iLineCount == line)
                    {
                        result = tmp;
                        break;
                    }
                    iLineCount++;
                }
                sr.Close();
            }

            // уберем лишнее
            if (result != null)
                result = result.Trim(aCarrets);
            // вернем результат
            return result;
        }

        // прочитать случайную строку из файла ($path- путь к файлу)
        public static string GetRandomLine(string path)
        {
            return GetLine(path, new Random().Next(0, Convert.ToInt32(GetLinesCount(path)) - 1));
        }

        #endregion

        #region операции файл - в файл

        /// <summary>
        /// сортировать текстовый файл построчно
        /// </summary>
        /// <param name="sSourcePath">путь к исходнуму файлу</param>
        /// <param name="sDestinationPath">путь куда записать результат</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true- если все ок</returns>
        public static bool SortFile(string sSourcePath, string sDestinationPath)
        {
            // прверим что пути разные
            if (sSourcePath == sDestinationPath)
            {
                MessageBox.Show("Source path equal destination path it's not good");
                return false;
            }
            // проверим что есть что сортированть
            if (!System.IO.File.Exists(sSourcePath))
            {
                MessageBox.Show("File " + sSourcePath + " is not exist");
                return false;
            }
            // проверим и удалим если занято куда сортировать
            if (System.IO.File.Exists(sDestinationPath))
            {
                LogTools.LogEvent("Destination file: " + sDestinationPath + " is exist . Now it deleted");
                // удалим файл назначения
                System.IO.File.Delete(sDestinationPath);
            }

            // создадим bat - файл для сортировки (функция sort)
            string sTmpBatPath = "c:\\1.bat";
            string sBatFile = "sort \"" + sSourcePath + "\" /o \"" + sDestinationPath + "\" /rec 65535 /t " + Application.StartupPath + "\\Temp\n";
            sBatFile += "del \"" + sTmpBatPath + "\"";
            FileStream FS = new FileStream(sTmpBatPath, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS);
            SW.WriteLine(sBatFile);
            SW.Close();
            FS.Close();

            // лог начала
            LogTools.LogEvent("Begin sorting " + sSourcePath + " to " + sDestinationPath);

            // запустим на сортировку            
            Process procSort = Process.Start(sTmpBatPath);
            procSort.WaitForExit();
            Thread.Sleep(1000);            

            // проверим что все окей
            if (procSort.ExitCode == 0 || procSort.ExitCode == 1)
            {
                // проверим что файл создан
                if (System.IO.File.Exists(sDestinationPath))
                {
                    // лог начала
                    LogTools.LogEvent("End sorting " + sSourcePath + " to " + sDestinationPath + " (succesfull)");
                    return true;
                }
                else
                {
                    // лог начала
                    LogTools.LogEvent("End sorting " + sSourcePath + " to " + sDestinationPath + " (destination file is not exist)");
                    return false;
                }
            }
            else
            {
                // лог начала
                LogTools.LogEvent("End sorting " + sSourcePath + " to " + sDestinationPath + " (sorting process exit with code: " + procSort.ExitCode.ToString() + ")");
                return false;
            }
        }

        /// <summary>
        /// убрать дубликаты в текстовом файле
        /// </summary>
        /// <param name="sSourcePath">путь к исходнуму файлу</param>
        /// <param name="sDestinationPath">путь куда записать результат</param>
        /// <param name="bIsSorted">сортирован ли исходный файл</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true - если все удалось</returns>
        public static bool DedupeFile(string sSourcePath, string sDestinationPath, bool bIsSorted)
        {
            // проверим что есть что сортировать
            if (!System.IO.File.Exists(sSourcePath))
            {
                MessageBox.Show("File " + sSourcePath + " is not exist");
                return false;
            }

            // отсортируем
            if (!bIsSorted)
            {
                if (!SortFile(sSourcePath, Application.StartupPath + "\\sorted.txt"))
                    return false;
                sSourcePath = Application.StartupPath + "\\sorted.txt";
            }

            // откроем файлы            
            FileStream FS = new FileStream(sDestinationPath, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding("windows-1251"));
            StreamReader sr = new StreamReader(sSourcePath, Encoding.GetEncoding("windows-1251"));

            // прочитаем и запишем превую строчку
            string line0 = sr.ReadLine();
            SW.WriteLine(line0);

            // построчно читаем из файла и пишем только не повторяющиеся строки            
            string line1;
            while ((line1 = sr.ReadLine()) != null)
            {
                if (line1 == line0 || line1 == "")
                    continue;
                SW.WriteLine(line1);
                line0 = line1;
            }            

            // закроем все файлы 
            sr.Close();
            SW.Close();
            FS.Close();

            // удалим промежуточный сортировочный файл
            if (!bIsSorted)
                System.IO.File.Delete(sSourcePath);

            // отсортили
            return true;
        }

        /// <summary>
        /// рандомизировать текстовый файл и записать другой файл
        /// </summary>
        /// <param name="sSourcePath">исходный файл</param>
        /// <param name="sDestinationPath">результирующий файл</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true - если все окей</returns>
        public static bool RandomizeTo(string sSourcePath, string sDestinationPath)
        {
            // массив строк                       
            List<string> aStrings = new List<string>();

            // прочитаем файл в массив
            LogTools.LogEvent("Begin read from file : " + sSourcePath + " to memory");            
            StreamReader sr = new StreamReader(sSourcePath, Encoding.GetEncoding("windows-1251"));
            string line;
            while (true)
            {
                line = sr.ReadLine();
                if (line == null)
                    break;
                aStrings.Add(line);
            }
            sr.Close();
            LogTools.LogEvent("End read file to memory (" + aStrings.Count.ToString() + " lines found)");

            // раскидаем из массива в файл
            FileStream fs = new FileStream(sDestinationPath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("windows-1251"));
            Random lRandom = new Random();
            while (aStrings.Count > 0)
            {
                int iNumber = lRandom.Next(0, aStrings.Count - 1);
                sw.WriteLine(aStrings[iNumber]);
                aStrings.RemoveAt(iNumber);
                if (aStrings.Count % 10000 == 0)
                    LogTools.LogEvent("Leave randomize (" + aStrings.Count.ToString() + " lines )");
            }
            sw.Close();
            fs.Close();            
            LogTools.LogEvent("Ramdomize complete and file save to " + sDestinationPath);

            // вес окей
            return true;
        }

        /// <summary>
        /// заменить заданную строку в текстовом файлеп другой строкой
        /// </summary>
        /// <param name="sSourcePath">путь к исходнуму файлу</param>
        /// <param name="sDestinationPath">путь куда записать результат</param>
        /// <param name="sSrc">исходная строка</param>
        /// <param name="sDest">строка на котрую заменяем</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true- если все ок</returns>
        public static bool ReplaceString(string sSourcePath, string sDestinationPath, string sSrc, string sDest)
        {
            // проверим что есть что сортированть
            if (!System.IO.File.Exists(sSourcePath))
            {
                MessageBox.Show("File " + sSourcePath + " is not exist");
                return false;
            }
            // проверим и удалим если занято куда сортировать
            if (System.IO.File.Exists(sDestinationPath))
            {
                LogTools.LogEvent("Destination file: " + sDestinationPath + " is exist . Now it deleted");
                // удалим файл назначения
                System.IO.File.Delete(sDestinationPath);
            }

            // откроем файлы            
            FileStream FS = new FileStream(sDestinationPath, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding("windows-1251"));
            StreamReader sr = new StreamReader(sSourcePath, Encoding.GetEncoding("windows-1251"));

            // построчно читаем из файла и делаем замену            
            string line1;
            while ((line1 = sr.ReadLine()) != null)
            {
                line1 = line1.Replace(sSrc, sDest);
                SW.WriteLine(line1);
            }            

            // закроем все файлы 
            sr.Close();
            SW.Close();
            FS.Close();

            return true;
        }

        /// <summary>
        /// получить строки из файла в дургой файл. начиная с заданной строки
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fromLine"></param>
        /// <param name="pathNewDatas"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        static public bool GetStringsToFile(string pathNewDatas,string path, int fromLine, int lineCount=-1, string encoding = "windows-1251")
        {
            // проверим что есть что сортированть
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("File " + path + " is not exist");
                return false;
            }
            // проверим и удалим если занято куда сортировать
            if (System.IO.File.Exists(pathNewDatas))
            {
                // удалим файл назначения
                System.IO.File.Delete(pathNewDatas);
            }

            // откроем файлы            
            FileStream FS = new FileStream(pathNewDatas, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding(encoding));
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(encoding));

            // построчно читаем из файла и делаем замену            
            string line1; int lineNum = 0;
            while ((line1 = sr.ReadLine()) != null)
            {
                lineNum++;
                if (lineNum >= fromLine)
                {
                    if (lineCount != -1)
                        lineCount--;
                    if (lineCount == 0)
                        break;
                    SW.WriteLine(line1);
                }
            }

            // закроем все файлы 
            sr.Close();
            SW.Close();
            FS.Close();

            return true;
        }

        // перенести или добавть файл
        public static bool MoveOrAppend(string sSrcPath, string sDestPath, string sEncoding = "windows-1251")
        {
            if (System.IO.File.Exists(sDestPath) == false)
                System.IO.File.Move(sSrcPath, sDestPath);
            else
            {
                StreamReader sr = new StreamReader(sSrcPath, Encoding.GetEncoding(sEncoding));
                StreamWriter sw = new StreamWriter(sDestPath, true, Encoding.GetEncoding(sEncoding));
                while (true)
                {
                    string sContent = sr.ReadLine();
                    if (sContent == null)
                        break;
                    sw.WriteLine(sContent);
                }
                sr.Close();
                sw.Close();
                System.IO.File.Delete(sSrcPath);
            }

            // ok
            return true;
        }

        // скопировать или добавть файл
        public static bool CopyOrAppend(string sSrcPath, string sDestPath, string sEncoding = "windows-1251")
        {
            if (System.IO.File.Exists(sDestPath) == false)
                System.IO.File.Copy(sSrcPath, sDestPath);
            else
            {
                StreamReader sr = new StreamReader(sSrcPath, Encoding.GetEncoding(sEncoding));
                StreamWriter sw = new StreamWriter(sDestPath, true, Encoding.GetEncoding(sEncoding));
                while (true)
                {
                    string sContent = sr.ReadLine();
                    if (sContent == null)
                        break;
                    sw.WriteLine(sContent);
                }
                sr.Close();
                sw.Close();
                System.IO.File.Delete(sSrcPath);
            }

            // ok
            return true;
        }

        #endregion

        #region операции файл - в файлы

        /// <summary>
        /// разделить файл на заданное количество частей
        /// </summary>
        /// <param name="sSourcePath">путь к файлу</param>
        /// <param name="sSourcePath">каталог где будут созданы файлы-части</param>
        /// <param name="iNumParts">на сколько частей делить</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns></returns>
        public static bool SplitFileOnPart(string sSourcePath, string sDestinationPath, int iNumParts, string sEncoding = "windows-1251")
        {
            // проверим что есть что делить
            if (!System.IO.File.Exists(sSourcePath))
            {
                MessageBox.Show("File " + sSourcePath + " is not exist");
                return false;
            }

            // число строк в файле
            Int64 iLineCount = GetLinesCount(sSourcePath);
            // число строк на часть
            Int64 iLinesPerPart = iLineCount / iNumParts;

            // лог начала
            //LogTools.LogEvent("Begin split file " + sSourcePath + " to folder " + sDestinationPath);
            //LogTools.LogEvent("File " + sSourcePath + " has " + iLineCount.ToString() + " lines");

            // пройдем по файлу и разделим его на части            
            StreamReader sr = new StreamReader(sSourcePath, Encoding.GetEncoding(sEncoding));
            string line; int iNumber = 0;
            for (int i = 1; i <= iNumParts; i++)
            {
                // имя i части
                Application.DoEvents();
                string sPartPath = sDestinationPath + FileTools.GetFileName(sSourcePath) + ".part_" + i.ToString() + ".txt";
                //LogTools.LogEvent("Phase " + i.ToString() + " begin create " + sPartPath);

                // запишем i часть
                FileStream fs = new FileStream(sPartPath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(sEncoding));
                while (true)
                {
                    // очередная строка
                    line = sr.ReadLine();

                    // конец файла
                    if (line == null)
                    {
                        sr.Close();
                        sw.Close();
                        fs.Close();                       
                        //LogTools.LogEvent("Successfull. Result save to " + sDestinationPath);
                        return true;
                    }

                    // запишем
                    sw.WriteLine(line);
                    iNumber++;

                    // конец части
                    if (iNumber == iLinesPerPart && i != iNumParts)
                    {
                        iNumber = 0;
                        break;
                    }
                }
                sw.Close();
                fs.Close();
            }
            sr.Close();            

            // все ок - хотя сюда не должно идти
            //LogTools.LogEvent("Successfull ???! . Result save to " + sDestinationPath);
            return true;
        }

        #endregion

        #region операции файлы в файл

        /// <summary>
        /// исключить строки файла из другого файла (файлы дюб отсортированы и без дуюликатов)
        /// </summary>
        /// <param name="sSourceFilePath">путь к файлу из которого надо исключить</param>
        /// <param name="sNeedExcludeFilePath">путь к файлу содержащему строки что нужно исключить</param>
        /// <param name="sDestinationFilePath">результирующий файл</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true - если все ok</returns>
        static public bool ExcludeFileFromFile(string sSourceFilePath, string sNeedExcludeFilePath, string sDestinationFilePath)
        {
            // проверим что есть что сортировать
            if (!System.IO.File.Exists(sSourceFilePath))
            {
                MessageBox.Show("File " + sSourceFilePath + " is not exist");
                return false;
            }
            // проверим что есть что сортировать
            if (!System.IO.File.Exists(sNeedExcludeFilePath))
            {
                MessageBox.Show("File " + sNeedExcludeFilePath + " is not exist");
                return false;
            }

            // откроем файлы            
            FileStream FS = new FileStream(sDestinationFilePath, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS, Encoding.ASCII);
            StreamReader srSource = new StreamReader(sSourceFilePath, Encoding.ASCII);
            StreamReader srExclude = new StreamReader(sNeedExcludeFilePath, Encoding.GetEncoding("windows-1251"));


        // идем по файлу исключений
        string lineExlude = ""; string lineSrc = "";
            bool bNeedReadSrc = true;
            bool bNeedReadExclude = true;
            while (true)
            {
                // прочитаем строку из файла исключений
                if (bNeedReadExclude)
                {
                    lineExlude = srExclude.ReadLine();
                    if (lineExlude == "")
                        lineExlude = srExclude.ReadLine();
                    // хуевые слова - пропустим
                    while (lineExlude.IndexOfAny(aBad) != -1)
                        lineExlude = srExclude.ReadLine();
                }
                // прочитаем строку из исходного файла
                if (bNeedReadSrc)
                {
                    lineSrc = srSource.ReadLine();
                    if (lineSrc == "")
                        lineSrc = srSource.ReadLine();
                    // хуевые слова - пропустим
                    while (lineSrc.IndexOfAny(aBad) != -1)
                        lineSrc = srSource.ReadLine();
                }

                // если закончился исходный - все сделали 
                if (lineSrc == null)
                    break;
                // если закончился файл исключпений - запишем все оставшееся из исходного и все сделали
                if (lineExlude == null)
                {
                    bNeedReadSrc = true;
                    SW.WriteLine(lineSrc);
                    continue;
                }

                // сравним две строки
                int iRes = lineSrc.CompareTo(lineExlude);

                // совпадают - читаем дальше
                if (iRes == 0)
                {
                    bNeedReadSrc = true;
                    bNeedReadExclude = true;
                    continue;
                }

                // исходная строка меньше - запишем ее и идем дальше
                if (iRes < 0)
                {
                    bNeedReadSrc = true;
                    bNeedReadExclude = false;
                    SW.WriteLine(lineSrc);
                    continue;
                }


                // исходная строка больше - читаем дальше что нужно исключить
                if (iRes > 0)
                {
                    bNeedReadSrc = false;
                    bNeedReadExclude = true;
                    continue;
                }
            }            

            // закроем все файлы 
            srSource.Close();
            srExclude.Close();
            SW.Close();
            FS.Close();

            return true;
        }

        #endregion
    }
}

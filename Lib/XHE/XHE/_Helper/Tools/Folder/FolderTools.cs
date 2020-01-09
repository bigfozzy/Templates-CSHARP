using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using XHE._Helper.Tools.Log;
using XHE._Helper.Tools.File;
using XHE._Helper.Tools.String;

namespace XHE._Helper.Tools.Folder
{
    /// <summary>
    /// класс инструментов по работе с папкой
    /// </summary>
    public class FolderTools
    {
        #region работа с GUI

        /// <summary>
        /// выбрать имени папки
        /// </summary>
        /// <param name="dlg">стандартный диалог выбора файла</param>
        /// <param name="sRegName">путь в реестре для хранения предыдущего значения</param>
        /// <param name="sPath">выходной путь</param>
        /// <returns>если выбор сделано то возвращает true</returns>
        public static bool SelectFolder(FolderBrowserDialog dlg, string sRegName, ref string sPath)
        {
            dlg.SelectedPath = Application.CommonAppDataRegistry.GetValue(sRegName, sPath) as string;
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                sPath = "";
                return false;
            }
            if (dlg.SelectedPath[dlg.SelectedPath.Length - 1] != '\\')
                dlg.SelectedPath += "\\";

            Application.CommonAppDataRegistry.SetValue(sRegName, dlg.SelectedPath);
            sPath = dlg.SelectedPath;
            return true;
        }

        /// <summary>
        /// выбрать фолдер по кнопке в текстбокс
        /// </summary>
        /// <param name="sSourceFolder">исходная папка</param>
        /// <param name="sFunctionName">операция</param>
        /// <param name="tbSettings">текстбокс</param>
        /// <param name="dlgOpenFolder">диалог выбора папки</param>
        /// <returns>true - если выбрали</returns>
        static public bool SelectFolderForTextBox(string sSourceFolder, string sFunctionName, TextBox tbSettings, FolderBrowserDialog dlgOpenFolder)
        {
            // выбор файла
            if (!SelectFolder(dlgOpenFolder, sFunctionName, ref sSourceFolder))
                return false;

            tbSettings.Text = sSourceFolder;
            return true;

        }

        /// <summary>
        /// выбрать каталог и получить в нем все файлы
        /// </summary>
        /// <param name="dlg">диалог выбора</param>
        /// <param name="sRegName">операция</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>файлы либо null</returns>
        static public string[] SelectFolderAndGetFiles(FolderBrowserDialog dlg, string sRegName)
        {
            // выбор файла
            string sSourceFolder = "";
            if (!SelectFolder(dlg, sRegName, ref sSourceFolder))
                return null;

            // получим файлы
            string[] aFiles = Directory.GetFiles(sSourceFolder, "*.txt");
            // лог
            if (aFiles.Length == 0)
                LogTools.LogEvent("Folder " + sSourceFolder + " is empty !");
            return aFiles;
        }

        #endregion

        #region получение информации по папке

        /// <summary>
        /// проверить пустая ли папка
        /// </summary>
        /// <param name="sFolder">папка</param>
        /// <returns>true - если папка не содержит ни файлов ни папок</returns>
        static public bool IsFolderEmpty(string sFolder)
        {
            int iNumSubItems = Directory.GetFiles(sFolder).Length + Directory.GetDirectories(sFolder).Length;
            return iNumSubItems == 0;
        }

        /// <summary>
        /// получить пути всех файлов и(или) папок в заданной директории по маске
        /// </summary>
        /// <param name="sFolder"></param>
        /// <param name="sFileMask"></param>
        /// <param name="bIncludeSubFolder"></param>
        /// <param name="bOnlyFolders"></param>
        /// <returns></returns>
        public static void GetAllFilesInFolder(string sFolder, string sFileMask, bool bIncludeSubFolder,
                                               bool bOnlyFolders, bool bOnlyFiles, List<string> aPaths)
        {
            // если не папка - то выйдем
            if (!Directory.Exists(sFolder))
                return;

            // получим список файлов в папке
            string[] aFiles = Directory.GetFiles(sFolder, sFileMask);
            foreach (string sPath in aFiles)
            {
                if (!bOnlyFolders)
                    aPaths.Add(sPath);
            }

            // получим список папок в папке
            string[] aFolders = Directory.GetDirectories(sFolder);
            foreach (string sPath in aFolders)
            {
                if (!bOnlyFiles)
                    aPaths.Add(sPath);
                if (bIncludeSubFolder)
                    GetAllFilesInFolder(sPath, sFileMask, bIncludeSubFolder, bOnlyFolders, bOnlyFiles, aPaths);
            }
        }

        /// <summary>
        /// получить последнюю папку в пути
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        static public string GetLastFolderInPath(string sPath)
        {
            string sLastFolder = "";
            string[] aFolders = sPath.Split('\\');
            if (aFolders.Length != 0)
                sLastFolder = aFolders[aFolders.Length - 1];
            return sLastFolder;
        }

        /// <summary>
        /// получить последние папки в путь
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="sRootFolder"></param>
        /// <returns></returns>
        static public string GeLastNFoldersInPath(string sPath, string sRootFolder)
        {
            if (sRootFolder[sRootFolder.Length - 1] != '\\')
                sRootFolder += '\\';
            return sPath.Replace(sRootFolder, "");
        }


        #endregion

        #region операции над одной папкой

        /// <summary>
        /// удалить все содержимрое папки
        /// </summary>
        /// <param name="sFolder"></param>
        /// <returns></returns>
        public static bool ClearFolder(string sFolder)
        {
            if (!Directory.Exists(sFolder))
                return false;
            
            foreach (string sFilePath in Directory.GetFiles(sFolder))
            {
                try
                {
                    System.IO.File.Delete(sFilePath);
                }
                catch (Exception)
                {                    
                }
                
            }
            foreach (string sSubFolderPath in Directory.GetDirectories(sFolder))
            {
                try
                {
                    Directory.Delete(sSubFolderPath);
                }
                catch (Exception)
                {
                }
            }
            return true;
        }

        /// <summary>
        /// удалить папку со всем содержимым
        /// </summary>
        /// <param name="sFolder"></param>
        /// <returns></returns>
        public static bool DeleteFolder(string sFolder)
        {
            Directory.Delete(sFolder, true);
            return true;
        }



        #endregion

        #region операции папка - папка

        public static bool Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                return false;
                /*throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);*/
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                try
                {
                    file.CopyTo(temppath, false);
                }
                catch (Exception)
                {

                }
            }

            // If copying subdirectories, copy them and their contents to new location.            
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    try
                    {
                        Copy(subdir.FullName, temppath, copySubDirs);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return true;
        }
    
        /// <summary>
        /// собрать файлы с заданной папки и ее подпапок в заданную папку
        /// </summary>
        /// <param name="sInFolderPath"></param>
        /// <param name="sOutFolderPath"></param>
        /// <param name="bMove"></param>
        /// <returns></returns>
        public static int CollectFromFoldersToFolder(string sInFolderPath, string sOutFolderPath, string sExt,bool bMove)
        {
            // получим все файлы
            List<string> aPaths = new List<string>();
            GetAllFilesInFolder(sInFolderPath, "*." + sExt, true, false, true, aPaths);

            // пройдемся по всем путям
            int iNum = -1;
            foreach (string sPath in aPaths)
            {
                if (Directory.Exists(sPath))
                    continue;
                iNum++;

                // путь
                string sNewPath = sOutFolderPath + "file_" + StringTools.GetNumberAsString(iNum, 4) + "." + sExt;
                // скопируем или переместим                               
                if (bMove)
                {
                    System.IO.File.Move(sPath, sNewPath);
                    LogTools.LogEvent("File " + sPath + " moved to " + sNewPath);
                }
                else
                {
                    System.IO.File.Copy(sPath, sNewPath);
                    LogTools.LogEvent("File " + sPath + " copied to " + sNewPath);
                }
            }

            // вернем число обработанных файлов
            return iNum + 1;
        }

        /// <summary>
        /// собрать все подпапки первого уровня из подпапок в папке в заданную подпапку
        /// </summary>
        /// <param name="sSourceFolder">папка с подпапками (котрые содержат еще подпапки)</param>
        /// <param name="sDestinationFolder">папка куда все собирать</param>
        /// <param name="bDeleteAfterProceed">удалять ли после обработки</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true - если все ok</returns>
        static public bool CollectFoldersLevel1FromFolder(string sSourceFolder, string sDestinationFolder, bool bDeleteAfterProceed)
        {
            // пройдем по всем поддиректориям
            int iNum = 0;
            string[] aFolders = Directory.GetDirectories(sSourceFolder);
            foreach (string sFolderPath in aFolders)
            {
                // пройдем по всем подпапкам и выложим их в корневые папки
                string[] aFoldersLevel1 = Directory.GetDirectories(sFolderPath);
                foreach (string sSubFolder in aFoldersLevel1)
                {
                    // имя подпкпаи
                    string sSubFolderName = FileTools.GetFileName(sSubFolder);

                    // создадим корневую папку по имени подпапки, если еще пок ане создали
                    if (!Directory.Exists(sDestinationFolder + sSubFolderName))
                        Directory.CreateDirectory(sDestinationFolder + sSubFolderName);

                    // перенесем подпапку в соответствующую коневую папку
                    Directory.Move(sSubFolder, sDestinationFolder + sSubFolderName + "\\" + iNum.ToString());
                }

                // удалим обработанную подпапку
                if (bDeleteAfterProceed)
                    Directory.Delete(sFolderPath);

                // следующая
                iNum++;

            }

            // лог об окночании
            LogTools.LogEvent("End collect subfolders to sample folders in  : " + sDestinationFolder + "\r\n");
            return true;
        }

        /// <summary>
        /// распаковать архивы из папки в подпапки с порядковыми номерами
        /// </summary>
        /// <param name="sSourceFolderPath">папка с архивами</param>
        /// <param name="sDestinationFolderPath">папка куда распаковывать</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true - если все ok</returns>
        static public bool UnpackRarArchivesToFolder(string sSourceFolderPath, string sDestinationFolderPath, ref int iNumFiles, bool bCheckEmptyFolder)
        {
            // проверим что папка Unpack - пустая
            if (bCheckEmptyFolder && !IsFolderEmpty(sDestinationFolderPath))
            {
                MessageBox.Show("(Unpack rar files) Destination folder " + sDestinationFolderPath + " is not empty. This not good");
                return false;
            }

            // получим все rar файлы в папке закачек
            string[] aRarFiles = Directory.GetFiles(sSourceFolderPath, "*.rar");
            if (aRarFiles.Length == 0)
            {
                MessageBox.Show("(Unpack rar files) Rar files not found in " + sSourceFolderPath);
                return false;
            }
            LogTools.LogEvent("Begin unpack : " + aRarFiles.Length.ToString() + " archives");

            // распакуем все файлы  - каждый в отдельную папку
            iNumFiles = 0;
            foreach (string sFilePath in aRarFiles)
            {
                // // создадим директорию для распаковки
                string sNumDir = sDestinationFolderPath + iNumFiles.ToString() + "\\";
                Directory.CreateDirectory(sNumDir);

                // распакуем
                FileTools.UnpackFile(sFilePath, sNumDir);
                LogTools.LogEvent("Succesfull unpack : " + sFilePath + " to " + sNumDir);

                // следующий
                iNumFiles++;
            }

            // лог об окончании
            LogTools.LogEvent("End unpack - all results saved to  : " + sDestinationFolderPath + "\r\n");
            return true;
        }

        /// <summary>
        /// перенести заданные файлы в архив
        /// </summary>
        /// <param name="sSourceFolderPath">папка где лежат файлы</param>
        /// <param name="sMatch">условия подбора файлов</param>
        /// <param name="sArchiveFolderPath">архивная пака</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true - если все ок</returns>
        static public bool MoveFilesToArchive(string sSourceFolderPath, string sMatch, string sArchiveFolderPath)
        {
            // создадим папку по текущей дате
            string sCurDateTime = DateTime.Now.ToString("u");
            sCurDateTime = sCurDateTime.Replace(":", "-");
            sCurDateTime = sCurDateTime.Substring(0, sCurDateTime.Length - 1);
            sArchiveFolderPath += sCurDateTime + "\\";
            Directory.CreateDirectory(sArchiveFolderPath);

            // перенесем все нужные файлы
            string[] aRarFiles = Directory.GetFiles(sSourceFolderPath, sMatch);
            foreach (string sFilePath in aRarFiles)
                System.IO.File.Move(sFilePath, sArchiveFolderPath + FileTools.GetFileName(sFilePath));

            // лог об окончании
            LogTools.LogEvent("End move rar archives to : " + sArchiveFolderPath + " folder");
            return true;
        }

        /// <summary>
        /// сделать структуру подпапко папки простой (выложить все вложеные файлы в одну директорию)
        /// </summary>
        /// <param name="sFolderPath">путь к папке, содержащей подпапки</param>
        /// <param name="bNeedReplace">заменять или коипровать подпапки</param>
        /// <param name="bNeedAddAction">надо ли доп действия (для яндекса в базах)</param>
        /// <param name="tbLog">лог</param>
        /// <returns>true - если все ok</returns>
        public static bool KeepASampleFoldersInFolder(string sFolderPath, bool bNeedReplace, bool bNeedAddAction)
        {
            // пройдем по всем подпапкам в папке
            string[] aRootFolders = Directory.GetDirectories(sFolderPath);
            foreach (string sFolder in aRootFolders)
            {
                // чистое имя подпапки
                string sFolderName = FileTools.GetFileName(sFolder);
                // путь куда выкладывать
                string sToProccedFolder = sFolderPath + sFolderName + " Preproceed1";

                // сделаем имя папки уникальное
                while (Directory.Exists(sToProccedFolder))
                    sToProccedFolder += "_1";

                // соберем из подпапки все файлы
                Directory.CreateDirectory(sToProccedFolder);
                CollectFromFoldersToFolder(sFolder, sToProccedFolder + "\\", "txt", true);

                // заменим если надо
                if (bNeedReplace)
                {
                    DeleteFolder(sFolder);
                    Directory.Move(sToProccedFolder, sFolder);
                }
            }

            // дообработаем папку яндекса (надо для баз)
            if (bNeedAddAction && Directory.Exists(sFolderPath + "Yandex Suggest Dig"))
            {
                if (!Directory.Exists(sFolderPath + "Yandex Suggest"))
                {
                    Directory.Move(sFolderPath + "Yandex Suggest Dig", sFolderPath + "Yandex Suggest");
                }
                else
                {
                    Directory.Move(sFolderPath + "Yandex Suggest Dig", sFolderPath + "Yandex Suggest\\Dig");
                    string sToProccedFolder = sFolderPath + "Yandex Suggest Dig" + " Preproceed1";
                    Directory.CreateDirectory(sToProccedFolder);
                    CollectFromFoldersToFolder(sFolderPath + "Yandex Suggest", sToProccedFolder + "\\", "txt", true);
                    DeleteFolder(sFolderPath + "Yandex Suggest");
                    Directory.Move(sToProccedFolder, sFolderPath + "Yandex Suggest");
                }
            }

            // лог об окончании
            LogTools.LogEvent("End make a sample folders in  : " + sFolderPath + "\r\n");
            return true;
        }

        #endregion

        #region операции папка - файл

        /// <summary>
        /// запаковать подпапки 1 уровня в заданной папке
        /// </summary>
        /// <param name="sFolderPath">папка с подпапками</param>
        /// <param name="bNeedDelete">надо ли удалячть после запаковки</param>
        /// <param name="tbLog">окно лога</param>
        /// <returns>true  - если все ok </returns>
        public static bool PackSubfoldersLevel1(string sFolderPath, bool bNeedDelete)
        {
            // получим все подпапки
            List<string> aFilesPaths = new List<string>();
            GetAllFilesInFolder(sFolderPath, "*.*", false, true, false, aFilesPaths);
            LogTools.LogEvent("Begin pack subfolder level 1 in folder " + sFolderPath + " ( " + aFilesPaths.Count.ToString() + " files ) ");

            foreach (string sFolder in aFilesPaths)
            {
                // путь к bat-файлу
                string sBatPath = sFolderPath + "for_rar.bat";

                // содержимое bat фай-ла
                string sBatContent = "rar.exe a -r -ep1 -s -m5 \"" + sFolder + "\"\r\n";
                if (bNeedDelete)
                    sBatContent = "rar.exe a -ep1 -r -df -s -m5 \"" + sFolder + "\"\r\n";
                sBatContent += "del \"" + sBatPath + "\"\r\n";

                // сохраним bat- файл
                TextFileTools.WriteFile(sBatPath, sBatContent);

                ///// выполним распаковку
                Process proc = new Process();
                proc.StartInfo.FileName = sBatPath;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.WorkingDirectory = sFolder;
                proc.Start();
                proc.WaitForExit();

                // удалим лишние файлы
                System.IO.File.Delete(sBatPath);
                if (bNeedDelete)
                    DeleteFolder(sFolder);

                // лог
                LogTools.LogEvent("Complete packing folder: " + sFolder);
            }

            return true;
        }

        #endregion
    }
}

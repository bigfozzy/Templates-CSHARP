using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_System
{
    //////////////////////////////////////////////////// Textfile ///////////////////////////////////////////////
    public class XHETextFile : XHEBaseObject
    {
        ////////////////////////////////////// SERVICVE FUNCTIONS ///////////////////////////////////////////
        // server initialization
        public XHETextFile(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "TextFile";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить папку файла
        public string get_file_folder(string path, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // получить число строк в файле
        public int get_lines_count(string path, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // создать каталог 
        public bool create_folder(string path, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // собрать файлы из подпапок в один файл 
        public bool collect_from_folders_to_file(string infolderpath, string outfilepath, int timeout = 60, string extension = "txt")
        {
            string[,] aParams = new string[,] { { "infolderpath", infolderpath }, { "outfilepath", outfilepath }, { "extension", extension } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // получить все имена файлов в папке 
        public string get_all_files_in_folder(string path, string file = "", bool include_subfolders = false, bool only_folders = false, int timeout = 60, string extension = "")
        {
            string[,] aParams = new string[,] { { "path", path }, { "file", file }, { "include_subfolders", include_subfolders.ToString() }, { "only_folders", only_folders.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // разбить файл по папкам из первых букв по строковому файлу 
        public bool generate_folders_by_strings_file(string file, string folder, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "file", file }, { "folder", folder } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // разделить файл на части 
        public bool split_to_part(string infilepath, string outfilepath, int numparts, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infilepath", infilepath }, { "outfilepath", outfilepath }, { "numparts", numparts.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // собрать файлы из подпапок в одну папку
        public bool collect_from_folders_to_folder(string infolderpath, string outfolderpath, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infolderpath", infolderpath }, { "outfolderpath", outfolderpath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // отсортировать файл построчно
        public bool sort(string infilepath, string outfilepath, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infilepath", infilepath }, { "outfilepath", outfilepath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // убрать дубликаты из файла
        public bool dedupe(string infilepath, string outfilepath, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infilepath", infilepath }, { "outfilepath", outfilepath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // рандомизировать файл
        public bool randomize_to(string infilepath, string outfilepath, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infilepath", infilepath }, { "outfilepath", outfilepath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // форматировать случайные строки в текстовом файле
        bool file_links(string infilepath, string outfilepath, int num_lines, string type_make = "L", int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infilepath", infilepath }, { "outfilepath", outfilepath }, { "num_lines", num_lines.ToString() }, { "type_make", type_make } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // записать файл
        public bool write_file(string file, string content, int timeout = 60, bool create_folders = false)
        {
            string[,] aParams = new string[,] { { "file", file }, { "content", content }, { "create_folders", create_folders.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // задать строки в заданном файле
        public bool set_string_to_file(string file, string str, int line, bool add = true, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "file", file }, { "str", str }, { "line", line.ToString() }, { "add", add.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // добавить строку в файл
        public bool add_string_to_file(string file, string str, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "file", file }, { "str", str } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // прочитать файл
        public string read_file(string file, int timeout = 60, string encoding = "windows-1251")
        {
            string[,] aParams = new string[,] { { "file", file } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);

            // PHP PART
            /*global $bUTF8Ver;
            if ($bUTF8Ver)
                $res_1251=iconv($encoding, "utf-8", $res);
            else
                $res_1251=iconv($encoding, "windows-1251", $res);
            return $res_1251;*/
            return res;
        }
        // поменять порядок строк в текстовом файле 
        public bool revert_strings_file(string infile, string outfile, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "infile", infile }, { "outfile", outfile } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // заменить строки в текстовом файле
        public bool replace_string(string infile, string outfile, string old_str, string new_str, int timeout)
        {
            string[,] aParams = new string[,] { { "infile", infile }, { "outfile", outfile }, { "old_str", old_str }, { "new_str", new_str } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // убрать строки из файла
        public bool exclude_strings_file_from_file(string infile, string excluding_file, string outfile, int timeout)
        {
            string[,] aParams = new string[,] { { "infile", infile }, { "excluding_file", excluding_file }, { "outfile", outfile } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить строку из файла
        public string get_line_from_file(string file, bool rand, int line, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "file", file }, { "rand", rand.ToString() }, { "line", line.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // удалить строку из файла
        public bool delete_line_from_file(string file, int line, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "file", file }, { "line", line.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // get lines from file
        public string get_lines_from_file(string file, int beg_line, int lines_count, int timeout)
        {
            string[,] aParams = new string[,] { { "file", file }, { "beg_line", beg_line.ToString() }, { "lines_count", lines_count.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
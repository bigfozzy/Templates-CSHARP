using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;

namespace XHE.XHE_System
{
    ////////////////////////////////////////////// Sound ////////////////////////////////////////////////////////
    public class XHESound : XHEBaseObject
    {
        ///////////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////////
        // server initialization
        public XHESound(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Sound";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // подать звуковой сигнал 
        public bool beep()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проиграть звуковой файл
        public bool play_sound(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // конвертировать файл в другой звуковой формат
        public bool convert_file(string src_path, string new_path, string Hz = "", int timeout = 60)
        {
            string[,] aParams = new string[,] { { "src_path", src_path }, { "new_path", new_path }, { "Hz", Hz }, { "timeout", timeout.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // распознать звуковой файл, состо€щих из звуков английских цифр (0-9)
        public string recognize_file_with_digits(string path, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "timeout", timeout.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // распознать произвольный звуковой файл, использу€ механизм CMU Sphynx
        public string recognize_file(string path, string dict, string jsgf, string hmm, string add_params = "", int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "dict", dict }, { "jsgf", jsgf }, { "hmm", hmm }, { "add_params", add_params }, { "timeout", timeout.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

    };
}
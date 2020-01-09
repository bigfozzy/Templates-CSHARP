using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;
using System.Collections.Specialized;

namespace XHE.XHE_Web
{
    //////////////////////////////////////////////////// Anticapcha /////////////////////////////////////////////////
    public class XHEAnticapcha : XHEBaseAnticaptcha_Type_1
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // constructor
        public XHEAnticapcha(string server,XHEScriptBase script)
            : base(server)
        {
            _Script = script;
            m_Server = server;
            soft_id = "15";            
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string recognize(string filename, string apikey, string path = "http://www.anti-captcha.com", bool is_verbose = true, int rtimeout = 3000, int mtimeout = 3000, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, int is_russian = 0)
        {
            return recognize_(filename, apikey, path, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, is_russian);
        }
    };
}
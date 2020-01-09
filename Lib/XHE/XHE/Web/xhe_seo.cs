using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;


namespace XHE.XHE_Web
{
    /////////////////////////////////////////// Seo ////////////////////////////////////////////////////
    public class XHESEO : XHEBaseObject
    {
        /////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////
        // server initialization
        public XHESEO(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Seo";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////

        // получить ранг сайта по алексе
        public string get_alexa_rank(string site)
        {
            string[,] aParams = new string[,] { { "site", site } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // сохранить карту заданного сайта в xml
        public string get_sitemap(string site, string file, int timeout = 99999)
        {
            string[,] aParams = new string[,] { { "site", site }, { "file", file } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // сохранить все внутренние ссылки заданного сайта в файл
        public string get_all_sitemap_links(string site, string file, int timeout = 99999)
        {
            string[,] aParams = new string[,] { { "site", site }, { "file", file } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // сохранить все внешние ссылки заданного сайта в файл
        public string get_all_outside_links(string site, string file, int timeout = 99999, string separator = "<br>")
        {
            string[,] aParams = new string[,] { { "site", site }, { "file", file }, { "separator", separator } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}
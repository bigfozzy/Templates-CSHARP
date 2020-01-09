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
    /////////////////////////////////////////// Submitter /////////////////////////////////////////////////////
    public class XHESubmitter : XHEBaseObject
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // server initialization
        public XHESubmitter(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Submitter";
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // получить случайное имя
        public string generate_random_name(string lang = "EN", string sex_for_RU = "man")
        {
            string[,] aParams = new string[,] { { "lang", lang }, { "sex_for_RU", sex_for_RU } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить случайное второе имя (фамилию)
        public string generate_random_second_name(string lang = "EN", string sex_for_RU = "man")
        {
            string[,] aParams = new string[,] { { "lang", lang }, { "sex_for_RU", sex_for_RU } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить случайный ник
        public string generate_random_nick_name(int len)
        {
            string[,] aParams = new string[,] { { "len", len.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // получить случайную улицу
        public string generate_random_street(string lang)
        {
            string[,] aParams = new string[,] { { "lang", lang } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить случайный город
        public string generate_random_city(string lang)
        {
            string[,] aParams = new string[,] { { "lang", lang } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить случайный регион
        public string generate_random_region(string lang)
        {
            string[,] aParams = new string[,] { { "lang", lang } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить случайную страну
        public string generate_random_country(string lang)
        {
            string[,] aParams = new string[,] { { "lang", lang } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // получить случайный номер
        public string generate_random_number(int min, int max, bool as_int = false)
        {
            string[,] aParams = new string[,] { { "min", min.ToString() }, { "max", max.ToString() }, { "as_int", as_int.ToString() } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            res = res.Replace(",", "");
            if (as_int)
            {
                res=res.Replace(".", ",");
                return Math.Round(Convert.ToDouble(res)).ToString();
            }
            else
                return res;
        }
        // получить случайный текст
        public string generate_random_text(int len, int type)
        {
            string[,] aParams = new string[,] { { "len", len.ToString() }, { "type", type.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
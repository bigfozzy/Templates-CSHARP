using System;
using System.IO;
using System.Net;
using System.Text;

namespace XHE._Helper.Tools.Web
{
    public class HttpTools
    {
        #region получение информации
        
        /// <summary>
        /// получить веб страницу в виде строки
        /// </summary>
        /// <param name="sUrl">урл страницы</param>
        /// <returns>тело страницы</returns>
        public static string GetWebPage(string sUrl)
        {
            // получим по Get
            HttpWebRequest myRequest = (HttpWebRequest) WebRequest.Create(sUrl);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }

        /// <summary>
        /// получить веб ресурс в виде массива байт
        /// </summary>
        /// <param name="sUrl">урл ресурса</param>
        /// <returns>массив байт ресурса</returns>
        public static byte[] GetWebResource(string sUrl)
        {
            // загрузим
            string sWebPage = GetWebPage(sUrl);
    
            // вернм в байтах
            return Encoding.UTF8.GetBytes(sWebPage);
        }

        #endregion

        #region посылка стандартных запросов
        
        // послать POST запрос
        public static string SendPostQuery(string sUrl, string sDatas, string sRefferer)
        {
            PostSubmitter post = new PostSubmitter();
            post.Url = sUrl;
            post.Type=PostSubmitter.PostTypeEnum.Post;
            string result = post.PostData(sUrl, sDatas);
            return result;
        }

        // послать GET запрос
        public static string SendGetQuery(string sUrl, string sDatas, string sRefferer)
        {
            return "";
        }

        #endregion

        #region работа в связке с пхп
        
        // послать команду в пхп страницу
        static public string RunCommand(string sUrl,string sPost)
        {
            // TODO доделать
            string sRet = "";
            return sRet;
        }
        
        #endregion
    }
}
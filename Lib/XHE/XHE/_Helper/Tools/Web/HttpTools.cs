using System;
using System.IO;
using System.Net;
using System.Text;

namespace XHE._Helper.Tools.Web
{
    public class HttpTools
    {
        #region ��������� ����������
        
        /// <summary>
        /// �������� ��� �������� � ���� ������
        /// </summary>
        /// <param name="sUrl">��� ��������</param>
        /// <returns>���� ��������</returns>
        public static string GetWebPage(string sUrl)
        {
            // ������� �� Get
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
        /// �������� ��� ������ � ���� ������� ����
        /// </summary>
        /// <param name="sUrl">��� �������</param>
        /// <returns>������ ���� �������</returns>
        public static byte[] GetWebResource(string sUrl)
        {
            // ��������
            string sWebPage = GetWebPage(sUrl);
    
            // ����� � ������
            return Encoding.UTF8.GetBytes(sWebPage);
        }

        #endregion

        #region ������� ����������� ��������
        
        // ������� POST ������
        public static string SendPostQuery(string sUrl, string sDatas, string sRefferer)
        {
            PostSubmitter post = new PostSubmitter();
            post.Url = sUrl;
            post.Type=PostSubmitter.PostTypeEnum.Post;
            string result = post.PostData(sUrl, sDatas);
            return result;
        }

        // ������� GET ������
        public static string SendGetQuery(string sUrl, string sDatas, string sRefferer)
        {
            return "";
        }

        #endregion

        #region ������ � ������ � ���
        
        // ������� ������� � ��� ��������
        static public string RunCommand(string sUrl,string sPost)
        {
            // TODO ��������
            string sRet = "";
            return sRet;
        }
        
        #endregion
    }
}
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using XHE.XHE_Web;
using XHE.XHE_System;
using System.Threading;

namespace XHE
{
    // class for store intermedia objects
    public class XHEIntermediaObjects
    {
        // mouse
        public XHEMouse m_mouse=null;
        // browser
        public XHEBrowser m_browser =null;

        // constructor
        public XHEIntermediaObjects(XHEMouse mouse, XHEBrowser browser)
        {
            m_browser = browser;
            m_mouse = mouse;
        }
    }    

    // base class
    public class XHEBaseObject
    {
        private static Object thisLock = new Object();
        // скрипт
        public XHEScriptBase Script=null;

        ///////////////////////////////////////////////////////// SERVICVE VARIABLES /////////////////////////////////////////////////////////////
        private static Dictionary<string, XHEIntermediaObjects> m_commonObjects = new Dictionary<string, XHEIntermediaObjects>();

        // use from XHE Shell
        public static bool CSHARP_Use_Trought_Shell = true;
        // time of commnad execution
        public static int COMMAND_TIME = 60;

        // server address and port
        protected string m_Server;
        // server password
        protected string m_Password;
        // command prefix
        protected string m_Prefix;	    

        // get mouse for current server
        protected XHEMouse GetMouse()
        {
            XHEIntermediaObjects res =null;
            if (m_commonObjects.TryGetValue(m_Server, out res))
                return res.m_mouse;
            else
                throw new Exception("mouse not found. server : " + m_Server);
        }
        // get browser for current server
        protected XHEBrowser GetBrowser()
        {
            XHEIntermediaObjects res = null;
            if (m_commonObjects.TryGetValue(m_Server, out res))
                return res.m_browser;
            else
                throw new Exception("browser not found. server : " + m_Server);
        }
	    // add intermedia objects
	    public void AddIntermedaiObjects(XHEMouse mouse, XHEBrowser browser)
	    {
            lock (thisLock)
            {
                if (m_commonObjects.ContainsKey(m_Server))
                    return;

                XHEIntermediaObjects imdObjects = new XHEIntermediaObjects(mouse, browser);
                m_commonObjects.Add(m_Server, imdObjects);
            }
	    }
        // remove intermedia objects
        public void RemoveIntermedaiObjects()
        {
            m_commonObjects.Remove(m_Server);            
        }

        ///////////////////////////////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////////////////
        // server initialization
        public XHEBaseObject(string server, string password = "")
        {
            m_Server = server;
            m_Password = password;
        }
        private string html;
        public Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
        {
            html+=System.Text.Encoding.UTF8.GetString(buf);
            return size * nmemb;
        }
        // call a command on the server
        protected string call_function(string sCommand, int iTimeout = 60 /*COMMAND_TIME*/)
        {
            // call server and return its answer
            string sUrl = "http://" + m_Server + "/" + sCommand;
            if (m_Password.Length != 0)
            {
                if (sUrl.IndexOfAny(new char[] { '&', '?' }) != -1)
                    sUrl += "&password=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(m_Password));
                else
                    sUrl += "?password=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(m_Password));
            }
            if (Script!=null && Script.server_tab != -1)
            {
                if (sUrl.IndexOfAny(new char[] { '&', '?' }) != -1)
                    sUrl += "&server_tab=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(Script.server_tab.ToString()));
                else
                    sUrl += "?server_tab=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(Script.server_tab.ToString()));
            }

            string sPostvars = "";
            if (sUrl.IndexOf('?') != -1)
            {
                int iIndexPost = sUrl.IndexOf('?');
                sPostvars = sUrl.Substring(iIndexPost + 1);
                sUrl = sUrl.Substring(0, iIndexPost);
            }
            sPostvars += "\r\n";

            string responseFromServer = "";
            lock (thisLock)
            {
                try
                {
                    //ПРоверяем доступен ли сервер Хумана. Если не доступен, то отменяем операцию
                    try
                    {
                        using (var client = new TcpClient())
                        {
                            var items = m_Server.Split(':');
                            var result = client.BeginConnect(items[0], int.Parse(items[1]), null, null);
                            var success = result.AsyncWaitHandle.WaitOne(100);
                            if (!success)
                            {
                                return "false";
                            }

                            client.EndConnect(result);
                        }
                    }
                    catch
                    {
                        return "false";
                    }

                    // Create POST data and convert it to a byte array.
                    string postData = sPostvars;
                    byte[] byteArray = Encoding.ASCII.GetBytes(postData);

                    // Create a request using a URL that can receive a post. 
                    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(sUrl);
                    // Set the Method property of the request to POST.
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;

                    //request.ServicePoint.Expect100Continue = false;
                    request.Timeout = iTimeout * 1000;

                    // Write data  
                    using (Stream postStream = request.GetRequestStream())
                    {
                        // Write the data to the request stream.
                        postStream.Write(byteArray, 0, byteArray.Length);
                        //postStream.Flush();
                        //Thread.Sleep(200);
                    }

                    using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                    {
                    //WebResponse response = await request.GetResponseAsync();

                    // Get the response stream  
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseFromServer = reader.ReadToEnd();
                        }
                    }

                    //request.Abort();
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Status);
                    if (ex.Response != null)
                    {
                        // can use ex.Response.Status, .StatusDescription
                        if (ex.Response.ContentLength != 0)
                        {
                            using (var stream = ex.Response.GetResponseStream())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    Console.WriteLine(reader.ReadToEnd());
                                }
                            }
                        }
                    }
                }
            }

            //html = "";
                //    try
                //    {
                //        CURLcode code = CURLcode.CURLE_GOT_NOTHING;
                //        using (Easy easy = new Easy())
                //        {
                //            easy.SetOpt(CURLoption.CURLOPT_URL, sUrl);
                //            easy.SetOpt(CURLoption.CURLOPT_POST, 1);
                //            easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, sPostvars);
                //            //easy.SetOpt(CURLoption.CURLOPT_RETURNTRANSFER, 1);  
                //            easy.SetOpt(CURLoption.CURLOPT_TIMEOUT, iTimeout);
                //            Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);
                //            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                //            code = easy.Perform();
                //        }
                //        if (code == CURLcode.CURLE_OK)
                //            responseFromServer = html;
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.ToString());
                //    }
                //}
            return responseFromServer.Trim();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // call a command on the server
        protected bool call_boolean(string sCommand, string[,] aParams, int iTimeout = 60/*COMMAND_TIME*/)
        {
            // call
            if (call_function(get_command_string(sCommand, aParams), iTimeout) == "true")
                return true;
            else
                return false;
        }
        // call a command on the server
        protected string call_get(string sCommand, string[,] aParams, int iTimeout = 60)
        {
            // call
            string res = call_function(get_command_string(sCommand, aParams), iTimeout);
            return res;
        }
        // call a command on the server
        protected int call_int(string sCommand, string[,] aParams, int iTimeout = 60)
        {
            // call
            string res = call_function(get_command_string(sCommand, aParams), iTimeout);
            if (res == "" || res == "false")
                return -1;
            if (res == "Ignore")
                return -1;
            else
            {
                try
                {
                    return Convert.ToInt32(res);
                }
                catch (Exception )
                {
                    Console.WriteLine("warning: "+res+"not correct result for "+ get_command_string(sCommand, aParams));
                    return -1;
                }
            }
        }
        // call a command on the server
        protected long call_long(string sCommand, string[,] aParams, int iTimeout = 60)
        {
            // call
            string res = call_function(get_command_string(sCommand, aParams), iTimeout);
            if (res == "" || res == "false")
                return -1;
            if (res == "Ignore")
                return -1;
            else
                return Convert.ToInt64(res);
        }
        // get command string
        protected string get_command_string(string sCommand, string[,] aParams)
        {

            string sSend_command = m_Prefix + "." + sCommand;
            string sParams = "";
            if (aParams != null)
            {                
                for (int i = 0; i < aParams.Length / 2; i++)
                {                    
                    if (i == 0)
                        sParams = sParams + "?";
                    else
                        sParams = sParams + "&";
                    sParams += aParams[i, 0] + "=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(aParams[i, 1]));
                }
            }
            sSend_command += sParams;
            return sSend_command;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
 
        // сравниваем строки
        public bool compare_string(bool exactly, string string_1, string string_2)
        {
            if (exactly == true)
            {
                if (string_1 == string_2)
                    return true;
            }
            else if (exactly == false)
            {
                if (string_1.IndexOf(string_2) == -1)
                    return false;
                else
                    return true;
            }
            return false;
        }

    }
}
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
    /////////////////////////////////////////// Raw ////////////////////////////////////////////////////
    public class XHEProxyCheker : XHEBaseObject
    {
        //////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEProxyCheker(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "ProxyCheker";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ������������
        public bool run(bool is_wait = false)
        {
            string[,] aParams = new string[,] { { "is_wait", is_wait.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            // ����� ��������� ������������
            while (is_wait && is_running())
                Thread.Sleep(10000);

            return res;
        }
        // ���������� ������������
        public bool stop()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        // ��������� �������� �� ������ ������������
        public bool is_running()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        // ������ �������� ������������
        public bool set_speed_testing(int speed)
        {
            string[,] aParams = new string[,] { { "speed", speed.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ �������� ������������
        public bool set_quality_testing(int quality)
        {
            string[,] aParams = new string[,] { { "quality", quality.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ������ � ������
        public bool add_proxy(string str_proxy)
        {
            string[,] aParams = new string[,] { { "str_proxy", str_proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������ � ������ �� �����
        public bool add_proxy_from_file(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������ �� ���� � ������
        public bool add_proxy_from_url(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������� ������ ��������� ���� �� ������
        public bool delete_proxy(string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "param_proxy", param_proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // s��������� ������ ��������� ���� � ����
        public bool save_proxy(string path, string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "path", path }, { "param_proxy", param_proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������ ��������� �� ������ ������
        public bool dedupe_proxy()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ���������� ������ ��������� ����
        public int get_count_proxy(string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "param_proxy", param_proxy } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������ ��������� ����
        public string get_proxy(int n, string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "n", n.ToString() }, { "param_proxy", param_proxy } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� ������� ������ ��������� ����
        public string get_fastest_proxy(string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "param_proxy", param_proxy } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}
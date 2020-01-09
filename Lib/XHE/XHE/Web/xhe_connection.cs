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
    /////////////////////////////////////// Connection ////////////////////////////////////////////////////
    public class XHEConnection : XHEBaseObject
    {
        ////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////
        // server initialization
        public XHEConnection(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Connection";
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� RAS ����������
        public bool dial_ras(string name, string login, string password)
        {
            string[,] aParams = new string[,] { { "name", name }, { "login", login }, { "password", password } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� RAS ����������
        public bool hang_up_ras()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // �������� ��� RAS ���������� �� ��� ������
        public string get_name_by_number_ras(int number)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� ���� RAS ���������� (����������� - "<br>" )
        public string get_all_connection_ras()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
	// ������� VPN ����������
        public bool create_vpn(string name,string server,string user,string password,string psk,int type)
	{
            string[,] aParams = new string[,] { { "name", name } , { "server", server } , { "user", user } , { "password", password } ,{ "psk", psk } , { "type", type.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // ������������� LAN ���������� �� �����
        public bool restart_lan_by_name(string name)
        {
            string[,] aParams = new string[,] { { "name", name } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������������� LAN ���������� �� ������
        public bool restart_lan_by_number(int number)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ������� ��������� ��-�� �����
        public string get_local_ip()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // ������ ������� ��������� ��-�� �����
        public bool set_local_ip(int number,string ip,string subnetMask="",string gateway="", string defaultDNS="",string subDNS="")
        {
            string[,] aParams = new string[,] { { "number", number.ToString() } , { "ip", ip } , { "subnetMask", subnetMask } , { "gateway", gateway } , { "defaultDNS", defaultDNS } , { "subDNS", subDNS } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            Thread.Sleep(5000);
            return res;
        }
        // �������� ������� ������� ��-�� �����
        public string get_real_ip()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

	// �������� ��� ����� �� ������
	public string get_mac_address_by_number(int number)
	{
            string[,] aParams = new string[,] { { "number", number.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	}
	// ������ ��� ����� �� ������
	public bool set_mac_address_by_number(int number, string mac )
	{
            string[,] aParams = new string[,] { { "number", number.ToString() } , { "mac", mac }};
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	    Thread.Sleep(3000);
	    return res;
	}

        // ������������ �������� ����
        public bool check_ping_site(string site)
        {
            string[,] aParams = new string[,] { { "site", site } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���������� � ����������
        public bool is_connect_to_internet()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // �������� ��������� ���������� � ����������
        public string get_connection_parameters()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // ������ ������ �� �������� ����������
        public bool enable_proxy(string connection, string proxy)
        {
            string[,] aParams = new string[,] { { "connection", connection }, { "proxy", proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ ������ � ��������� ����������
        public bool disable_proxy(string connection)
        {
            string[,] aParams = new string[,] { { "connection", connection } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������� ������
        public string get_current_proxy(string connection)
        {
            string[,] aParams = new string[,] { { "connection", connection } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
    };
}
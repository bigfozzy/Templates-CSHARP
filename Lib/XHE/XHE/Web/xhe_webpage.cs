using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;
using XHE.XHE_DOM;
using XHE.XHE_System;
using System.Globalization;
using System.Drawing;

namespace XHE.XHE_Web
{
    //////////////////////////////////////////// Webpage //////////////////////////////////////////////////////
    public class XHEPosition
    {
        public int x;
        public int y;
        public XHEPosition(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public XHEPosition(string x,string y)
        {
            try
            {
                this.x = Convert.ToInt32(x);
                this.y = Convert.ToInt32(y);
            }
            catch
            {
                this.x=-1;
                this.y=-1;
            }
        }
    }
    public class XHEWebPage : XHEBaseObject
    {        
        ////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////
        // server initialization
        public XHEWebPage(XHEMouse mouse,string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "WebPage";
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ��������� ��������� ��������
        public XHEInterface get_active_element()
        {
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, null);

            return new XHEInterface(internal_number, m_Server, m_Password);
        }
        // �������� ��������� �������� �� �����������
        public XHEInterface get_element_from_point(int x, int y)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number, m_Server, m_Password);
        }
        // �������� ��������� �������� (<title> �� ��������)
        public string get_title()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // �������� ������� ��� ��������
        public string get_location_url()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // �������� ������� ��� ��������
        public string get_url()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // �������� ������� ��������� ��������
        public string get_encoding()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // ������ ��������� ��������
        public bool set_encoding(string encoding)
        {
            string[,] aParams = new string[,] { { "encoding", encoding } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� �������� ������� �������� � ��������
        public string get_source()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // �������� ������ ��������� ������� ��������
        public int get_source_length()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // ��������� �������� ����� ������� �������� � ����
        public bool save_source_to_file(string filepath)
        {
            string[,] aParams = new string[,] { { "filepath", filepath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ���� ������� �������� (source ����� ��������� ���������)
        public string get_body()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // ������ ���� ������� ��������
        public bool set_body(string body)
        {
            body = Convert.ToBase64String(Encoding.UTF8.GetBytes(body));
            string[,] aParams = new string[,] { { "body", body } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ��������� ������� �������� (��� ����� ��� ����)
        public string get_document_body(bool as_html)
        {
            string[,] aParams = new string[,] { { "as_html", as_html.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ������� �������� ����� �������� ���������
        public string get_body_before_prefix(string prefix, bool as_html = true)
        {
            string[,] aParams = new string[,] { { "prefix", prefix }, { "as_html", as_html.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ������� �������� ����� ��������� ��������
        public string get_body_after_prefix(string prefix, bool as_html = true)
        {
            string[,] aParams = new string[,] { { "prefix", prefix }, { "as_html", as_html.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ������� �������� ������ �������� ��������� (������ ���������)
        public string get_body_inter_prefix(string prefix1, string prefix2, bool as_html = true)
        {
            string[,] aParams = new string[,] { { "prefix1", prefix1 }, { "prefix2", prefix2 }, { "as_html", as_html.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ������� �������� ������ �������� ��������� (��� ���������)
        public string get_body_inter_prefix_all(string prefix1, string prefix2, bool as_html = true, int shift1 = 0, int shift2 = 0, string separator = "<br>")
        {
            string[,] aParams = new string[,] { { "prefix1", prefix1 }, { "prefix2", prefix2 }, { "as_html", as_html.ToString() }, { "shift1", shift1.ToString() }, { "shift2", shift2.ToString() }, { "separator", separator } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� �������� �������� ����� ������� �������� � ����-��������
        public bool print_screen(string filepath, int xl = -1, int yt = -1, int xr = -1, int yb = -1, bool as_gray = false)
        {
            string[,] aParams = new string[,] { { "filepath", filepath }, { "xl", xl.ToString() }, { "yt", yt.ToString() }, { "xr", xr.ToString() }, { "yb", yb.ToString() } , { "as_gray", as_gray.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� �������� ���� �������� � pdf
        public bool print_to_pdf(string filepath)
        {
            string[,] aParams = new string[,] { { "filepath", filepath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� �������� �������� ����� ���� �������� � ����-��������
        public bool print_body(string filepath, int xl = -1, int yt = -1, int xr = -1, int yb = -1, bool as_gray = false)
        {
            string[,] aParams = new string[,] { { "filepath", filepath }, { "xl", xl.ToString() }, { "yt", yt.ToString() }, { "xr", xr.ToString() }, { "yb", yb.ToString() } , { "as_gray", as_gray.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
	
        // �������� X - ���������� �������� �������� �� ��������
        public int get_x_in_webpage_picture(string picture_filepath, double similar_koeff = 0.95 , int similar_algoritm = 5 )
        {
            string[,] aParams = new string[,] { { "picture_filepath", picture_filepath } , { "similar_koeff", similar_koeff.ToString() } , { "similar_algoritm", similar_algoritm.ToString() }};
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� Y - ���������� �������� �������� �� ��������	
        public int get_y_in_webpage_picture(string picture_filepath, double similar_koeff = 0.95 , int similar_algoritm = 5 )
        {
            string[,] aParams = new string[,] { { "picture_filepath", picture_filepath } , { "similar_koeff", similar_koeff.ToString() } , { "similar_algoritm", similar_algoritm.ToString() }};
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������� �������� �������� �� ��������	
        public Point get_pos_in_webpage_picture(string picture_filepath, double similar_koeff = 0.95 , int similar_algoritm = 5 )
        {
            string[,] aParams = new string[,] { { "picture_filepath", picture_filepath } , { "similar_koeff", similar_koeff.ToString() } , { "similar_algoritm", similar_algoritm.ToString() }};
            string[] res= call_get(MethodBase.GetCurrentMethod().Name, aParams).Split(';');
            return new Point(Convert.ToInt32(res[0]),Convert.ToInt32(res[1]));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ������ ����������� ������������� ���� (�� ���������)
        public int get_url_size(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� �������� �� ������������� ����
        public string load_web_page(string url,int size=0)
        {
            string[,] aParams = new string[,] { { "url", url } , { "size", size.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ��� ������ ��� �������� �������� �� ������������� ����
        public string get_web_page_code(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���������� ������������� ���� � ����
        public bool save_url_to_file(string url, string filepath, int timeout = 9999)
        {
            string[,] aParams = new string[,] { { "url", url }, { "filepath", filepath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // �������� ����� �� ������������� ����
        public string get_domain(string url = "", int level = -1)
        {
            if (url == "")
                url = get_location_url();
            url = url.Replace("http://", "");
            url = url.Replace("https://", "");
            url = url.Replace("www.", "");
            string[] domens = url.Split('/');
            string domen = domens[0];
            string[] parts = domen.Split('.');
            if (parts.Length >= level && level != -1)
            {
                string res = "";
                for (int i = 0; i < level; i++)
                {
                    res = parts[parts.Length - i - 1] + res;
                    if (i < level - 1)
                        res = "." + res;
                }
                return res;
            }
            else
                return domen;
        }
        // ���e����� ����� � idn ������ (�������� ���� ��) 
	public string convert_to_idn(string domain)
	{
		IdnMapping idn = new IdnMapping();
		return idn.GetAscii(domain);
	}
        // ���e����� ����� �� idn ������� (�������� ���� ��)
	public string convert_from_idn(string domain)
	{
		IdnMapping idn = new IdnMapping();
		return idn.GetUnicode(domain);
	}		

        ///////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
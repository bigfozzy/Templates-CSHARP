using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;using System.Reflection;

namespace XHE
{
    //////////////////////////////////////////////////// Interface //////////////////////////////////////////////
    public class XHEBaseInterface : XHEBaseObject
    {
        /////////////////////////////////////// SERVICE VARIABLES ///////////////////////////////////////////
        // ���������� �����
        public string inner_number;
        /////////////////////////////////////// SERVICE FUNCTIONS ///////////////////////////////////////////

        // �������������
        public XHEBaseInterface(string inner_number, string server, string password = "")
            : base(server, password)
        {
            m_Server = server;
            m_Password = password;
            this.inner_number = inner_number;
            m_Prefix = "Interface";
        }
        // ���������� (��� ������� ������)
        ~XHEBaseInterface()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            /* regognize humen this command */
        }
        // ����������� ��������� � DOM	
        public virtual XHEBaseInterface get_clone_()
        {
            return null;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
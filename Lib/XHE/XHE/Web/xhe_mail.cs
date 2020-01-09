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
    /////////////////////////////////////////// Mail ////////////////////////////////////////////////////
    public class XHEMail : XHEBaseObject
    {
        /////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
        // server initialization
        public XHEMail(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Mail";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        // задать прокси (пример socks5://xx.xx.xx.xx:pp или socks5://xx.xx.xx.xx:pp;login;password)
        public bool set_proxy(string proxy)
        {
            string[,] aParams = new string[,] { { "proxy", proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // соединится с SMTP сервером
        public bool smtp_connect(string server, int port, string login, string password, int ssl_option = 1, string cert_type = "s, c, h, e", int timeout = 3000)
        {
            string[,] aParams = new string[,] { { "server", server }, { "port", port.ToString() }, { "ssl_option", ssl_option.ToString() }, { "cert_type", cert_type }, { "login", login }, { "password", password }, { "timeout", timeout.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отсоединится от SMTP сервера
        public bool smtp_disconnect()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // отправить сообщение через smtp
        public bool send_mail_via_smtp(string from, string to, string subject, string message, string type)
        {
            string[,] aParams = new string[,] { { "from", from }, { "to", to }, { "subject", subject }, { "message", message }, { "type", type } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // соединиться с POP3 сервером
        public bool pop3_connect(string server, int port, string login, string password, int ssl_option = 1, string cert_type = "s, c, h, e", int timeout = 3000)
        {
            string[,] aParams = new string[,] { { "server", server }, { "port", port.ToString() }, { "ssl_option", ssl_option.ToString() }, { "cert_type", cert_type }, { "login", login }, { "password", password }, { "timeout", timeout.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отсоединиться от POP3 сервера
        public bool pop3_disconnect()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить число писем в ящике через POP3
        public int get_message_count_via_pop3()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }

        // получить письмо с заданным номером через POP3
        public XHEMailMessage get_message_by_number_via_pop3(int number)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }
        // получить письмо с заданной темой через POP3
        public XHEMailMessage get_message_by_subject_via_pop3(string subject, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "subject", subject }, { "exactly", exactly.ToString() }, { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }
        // получить письмо от заданного отправителя через POP3
        public XHEMailMessage get_message_by_from_via_pop3(string from, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "from", from }, { "exactly", exactly.ToString() }, { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }
        // получить письмо с заданным текстом через POP3
        public XHEMailMessage get_message_by_text_via_pop3(string text, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }

        // удалить письмо с заданным номером через POP3
        public bool delete_message_by_number_via_pop3(int number)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить письмо с заданным from через POP3
        public bool delete_message_by_from_via_pop3(string from, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "from", from }, { "exactly", exactly.ToString() }, { "number", number.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить письмо с заданным subject через POP3
        public bool delete_message_by_subject_via_pop3(string subject, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "subject", subject }, { "exactly", exactly.ToString() }, { "number", number.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить письмо с заданным текстом через POP3
        public bool delete_message_by_text_via_pop3(string text, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "number", number.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // удалить все письма на почте через POP3
        public bool delete_all_messages_via_pop3()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // соединиться с IMAP сервером
        public bool imap_connect(string server, int port, string login, string password, int ssl_option = 1, string cert_type = "s, c, h, e", int timeout = 3000)
        {
            string[,] aParams = new string[,] { { "server", server }, { "port", port.ToString() }, { "ssl_option", ssl_option.ToString() }, { "cert_type", cert_type }, { "login", login }, { "password", password }, { "timeout", timeout.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отсоединиться от IMAP сервера
        public bool imap_disconnect()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить число писем в ящике через IMAP
        public int get_message_count_via_imap(string folder = "")
        {
            string[,] aParams = new string[,] { { "folder", folder } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить письмо с заданным номером через IMAP
        public XHEMailMessage get_message_by_number_via_imap(string folder, int number)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "folder", folder } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }
        // получить письмо с заданной темой через IMAP
        public XHEMailMessage get_message_by_subject_via_imap(string folder, string subject, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "subject", subject }, { "exactly", exactly.ToString() }, { "folder", folder }, { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }
        // получить письмо от заданного отправителя через IMAP
        public XHEMailMessage get_message_by_from_via_imap(string folder, string from, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "from", from }, { "exactly", exactly.ToString() }, { "folder", folder }, { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }
        // получить письмо от с заданным текстом через IMAP
        public XHEMailMessage get_message_by_text_via_imap(string folder, string text, bool exactly = false, int number = 0)
        {
            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "folder", folder }, { "number", number.ToString() } };
            return new XHEMailMessage(call_get(MethodBase.GetCurrentMethod().Name, aParams));
        }

        // удалить письмо с заданным номером через IMAP
        public bool delete_message_by_number_via_imap(string folder, int number)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "folder", folder } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить все письма из заданной папки через IMAP
        public bool delete_all_messages_via_imap(string folder)
        {
            string[,] aParams = new string[,] { { "folder", folder } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}
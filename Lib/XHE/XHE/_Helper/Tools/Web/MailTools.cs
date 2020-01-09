using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using XHE._Helper.Tools.GUI;

namespace XHE._Helper.Tools.Web
{
    /// <summary>
    /// инструменты работы с мылом
    /// </summary>
    public class MailTools
    {
        /// <summary>
        /// послать хтмл с заданого адреса
        /// </summary>
        /// <param name="html"></param>
        /// <param name="subjectmstring"></param>
        /// <param name=""></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool SendHtmlMail(string html,string subject,string to,string login,string password)
        {
            if (to == "" || login == "" || password == "")
            {
                ShowMessage.ShowInfoMessage("Не задана информация о том как отсылать письмо");
                return false;
            }

            int index = login.IndexOf("@");
            string smtp = "smtp." + login.Substring(index+1);
            // отправим через яндекс
            var client = new SmtpClient(smtp);
            client.Credentials = new NetworkCredential(login, password);
            client.Port = 25;
            client.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(login);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = html;
            mail.IsBodyHtml = true;
            try
            {
                client.Send(mail);
                //TextFileTools.WriteFile("c:\\1\\1.html",html);
                //FileTools.ShowFile("c:\\1\\1.html");
            }
            catch (Exception exception)
            {
                ShowMessage.ShowInfoMessage(exception.Message);
                return false;
            }

            return true;
        }
    }
}

using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;
using System.Collections.Specialized;

namespace XHE.XHE_Web
{
    public class XHEBaseSMS
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // скрипт
        protected XHEScriptBase _Script = null;

        // server address
        public string m_Server;

        // сервис
        public string servis;
        // ключ сервиса
        public string api_key;
        // id операции 
        public string id;
        // номер телефона
        public string number;
        // статус активации
        public string status;
        // код
        public string code;
        // код ответа
        public string answer;
        // реф код для программы для сервиса
        public string refCode;

        public XHEBaseSMS(string api = "", string servis = "http://sms-activate.ru", string refCode = "humanemulator")
        {
            this.api_key = api;
            this.servis = servis;
            this.refCode = refCode;
        }

        // изменить сервис
        public bool change_service(string api, string servis, string refCode)
        {
            this.api_key = api;
            this.servis = servis;
            this.refCode = refCode;

            if (servis == "http://sms-activate.ru")
                this.refCode = "humanemulator";
            else if (servis == "https://cheapsms.ru")
                this.refCode = "humanem";
            else if (servis == "https://5sim.net")
                this.refCode = "ze7luo";

            return true;
        }

        // запрос количества доступных номеров:
        public string get_numbers_status(string country = "0", string smsOperator = "any")
        {
            string str_url = this.servis + "/stubs/handler_api.php?api_key="+this.api_key+"&action=getNumbersStatus&country="+country+"&operator="+smsOperator;
            //this.answer = file_get_contents(str_url);

            using (var webClient = new WebClient())
            {
                this.answer = webClient.DownloadString(str_url);
            }

            //obj=json_decode(this.answer);
            return this.answer;
        }

        // получить балланас
        public string get_balance()
        {
            string str_url = this.servis + "/stubs/handler_api.php?api_key=" + this.api_key + "&action=getBalance";
            //this.answer = file_get_contents(str_url);
            using (var webClient = new WebClient())
            {
                this.answer = webClient.DownloadString(str_url);
            }

            if (this.answer.IndexOf("ACCESS_BALANCE") != -1)
            {
                String[] items = this.answer.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                return items[1];
            }

            return this.answer;
        }

        // получить номер телефона   
        public bool get_phone_number(string service = "ot", string smsOperator = "any", string country = "0")
        {
            string str_url = this.servis + "/stubs/handler_api.php?api_key=" + this.api_key + "&action=getNumber&service="+service+"&operator="+smsOperator+"&country="+country+"&ref=" + this.refCode;

            using (var webClient = new WebClient())
            {
                this.answer = webClient.DownloadString(str_url);
            }

            if (this.answer.IndexOf("ACCESS_NUMBER") == -1)
            {
                //Console.WriteLine("ОШИБКА: this.servis ответ this.answer<br>");
                Console.WriteLine("ОШИБКА:" + this.servis + " ответ " + this.answer + "<br>");
                return false;
            }

            String[] arr_phone = this.answer.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            this.id = arr_phone[1].Trim();
            this.number = arr_phone[2].Trim();

            Console.WriteLine(this.servis + " номер : " + this.number + " id : " + this.id + "<br>");
            return true;
        }

        // получить смс с кодом 
        public bool get_code(int wt = 10)
        {
            Console.WriteLine("Получить смс код с телефона " + this.number + "<br>");

            string str_url = this.servis + "/stubs/handler_api.php?api_key=" + this.api_key + "&action=getStatus&id=" + this.id;

            using (var webClient = new WebClient())
            {
                this.answer = webClient.DownloadString(str_url);
            }

            for (int i = 0; i < wt; i++)
            {
                if (this.answer != "STATUS_WAIT_CODE") break;

                if (this.answer == "STATUS_WAIT_CODE")
                {
                    Console.WriteLine("Ждем смс телефона.." + this.servis + " ответ от сервера " + this.answer + "<br>");
                    Thread.Sleep(10 * 1000);

                    str_url = this.servis + "/stubs/handler_api.php?api_key=" + this.api_key + "&action=getStatus&id=" + this.id;

                    using (var webClient = new WebClient())
                    {
                        this.answer = webClient.DownloadString(str_url);
                    }
                }
            }
            // контрольный
            if (this.answer == "STATUS_WAIT_CODE")
            {
                Console.WriteLine("this.servis Контрольная проверка на ожидание ..<br>");
                Thread.Sleep(10 * 1000);

                str_url = this.servis + "/stubs/handler_api.php?api_key=" + this.api_key + "&action=getStatus&id=" + this.id;

                using (var webClient = new WebClient())
                {
                    this.answer = webClient.DownloadString(str_url);
                }

                if (this.answer == "STATUS_WAIT_CODE")
                {
                    Console.WriteLine("Слишком долго ждем смс. " + this.servis + " ответ от сервера " + this.answer + "<br>");
                    return false;
                }
            }

            Console.WriteLine("this.servis Получили ответ this.answer<br>");
            // разбираем полученные данные
            String[] arr_answer = this.answer.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            // если пришел номер телефона
            if (arr_answer[0].Trim() == "STATUS_OK")
            {
                Console.WriteLine(this.servis + " Получили код телефона " + arr_answer[arr_answer.Length-1].Trim() + ", вводим");

                this.code = arr_answer[arr_answer.Length-1].Trim(); // arr[arr.Length-1]
            }
            else
            {
                Console.WriteLine("this.servis. Ответ " + this.answer + "<br>");
                return false;
            }

            return true;

        }
        /*
            -1 - отменить активацию
            1 - сообщить о готовности номера (смс на номер отправлено)
            3 - запросить еще один код (бесплатно)
            6 - завершить активацию(если был статус "код получен" - помечает успешно и завершает, если был "подготовка" - удаляет и помечает ошибка, если был статус "ожидает повтора" - переводит активацию в ожидание смс)
            8 - сообщить о том, что номер использован и отменить активацию

            Ответы сервиса:
            ACCESS_READY - готовность номера подтверждена
            ACCESS_RETRY_GET - ожидание нового смс
            ACCESS_ACTIVATION - сервис успешно активирован
            ACCESS_CANCEL - активация отменена
        */
        // сообщить статус активации
        public bool set_status(string status = "6")
        {
            Console.WriteLine("сообщаем статус активации c "+this.servis+"<br>");

            string str_url = this.servis + "/stubs/handler_api.php?api_key=" + this.api_key + "&action=setStatus&status=" + status + "&id=" + this.id;

            using (var webClient = new WebClient())
            {
                this.answer = webClient.DownloadString(str_url);
            }

            // если пришел номер телефона
            if (this.answer == "ACCESS_READY")
            {
                Console.WriteLine(this.servis + " готовность номера подтверждена ответ от сервера " + this.answer + "<br>");
            }
            else
            {
                Console.WriteLine("ОШИБКА: Ответ серсвиса " + this.answer + "<br>");
                return false;
            }

            return true;
        }
    }
}
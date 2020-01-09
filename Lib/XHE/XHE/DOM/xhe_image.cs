using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;
using System.Reflection;
using XHE.XHE_Web;
using System.Drawing;
using System.Collections.Generic;

namespace XHE.XHE_DOM
{
    ///////////////////////////////////////////////// Image /////////////////////////////////////////////////////
    public class XHEImage : XHEBaseDOMVisual
    {
        // for call of XHEAnticapcha
        public XHEAnticapcha m_anticaptcha = null;
        // for call of XHERucapcha
        public XHERucapcha m_rucaptcha = null;
        // for call of XHECaptcha24
        public XHECaptcha24 m_captcha24 = null;
        // for call of XHERipcaptcha
        public XHERipcaptcha m_ripcaptcha = null;
        // for call of XHEBypasscaptcha
        public XHEBypasscaptcha m_bypasscaptcha = null;
        // for call of XHECaptchabot
        public XHECaptchabot m_captchabot = null;

        ////////////////////////////////// SERVICVE FUNCTIONS ///////////////////////////////////////////////
        // server initialization
        public XHEImage(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Image";
        }
        // initialize anticaptyhca services
        public void InitAntiCaptchas(XHEAnticapcha anticaptcha,XHERucapcha rucaptcha,XHECaptcha24 captcha24,XHERipcaptcha ripcaptcha,XHEBypasscaptcha bypasscaptcha,XHECaptchabot captchabot)
        {
            m_anticaptcha = anticaptcha;
            m_rucaptcha = rucaptcha;
            m_captcha24 = captcha24;
            m_ripcaptcha = ripcaptcha;
            m_bypasscaptcha = bypasscaptcha;
            m_captchabot = captchabot;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // показать картинку с заданным номером
        public bool show_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать картинку с заданным именем
        public bool show_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать картинку с заданным src
        public bool show_by_src(string src, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать картинку с заданным alt
        public bool show_by_alt(string alt, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute("alt", alt, exactly, frame);

            string[,] aParams = new string[,] { { "alt", alt }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать картинку с заданным значением аттрибута
        public bool show_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверить что картинка с заданным номером уже загружена
        public bool is_complete_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверить что картинка с заданным именем уже загружена
        public bool is_complete_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить дату создания картинки по её номеру
        public string get_file_create_date_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить дату создания картинки по её имени
        public string get_file_create_date_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить дату последнего изменения картинки по её номеру
        public string get_file_modification_date_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить дату последнего изменения картинки по её имени
        public string get_file_modification_date_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить размер картинки по её номеру
        public int get_file_size_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить размер картинки по её имени
        public int get_file_size_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // распознать капчу из картинки встроенными функциями
        public string recognize_captcha(string file_path, int type)
        {
            string[,] aParams = new string[,] { { "file_path", file_path }, { "type", type.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // распознать капчу из картинки через сервис antigate.com
        public string recognize_by_anticaptcha(string src, string file_path, string key, string path = "http://antigate.com", bool is_verbose = true, int rtimeout = 5, int mtimeout = 120, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, string frame = "-1", int is_russian = 0)
        {
            // save
            if (src != "")
            {
                wait_element_exist_by_attribute("src", src, 0, frame);

                if (!screenshot_by_src(file_path, src, 0, frame))
                    return null;
            }

            // recognize            
            return m_anticaptcha.recognize(file_path,key,path,is_verbose,rtimeout,mtimeout,is_phrase,is_regsense,is_numeric,min_len,max_len,is_russian);            
        }
        // распознать капчу из картинки через сервис rucaptcha.com
        public string recognize_by_rucaptcha(string src, string file_path, string key, string path = "http://rucaptcha.com", bool is_verbose = true, int rtimeout = 5, int mtimeout = 120, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, string frame = "-1", int is_russian = 0)
        {
            // save
            if (src != "")
            {
                wait_element_exist_by_attribute("src", src, 0, frame);

                if (!screenshot_by_src(file_path, src, 0, frame))
                    return null;
            }

            // recognize
            return m_rucaptcha.recognize(file_path,key,path,is_verbose,rtimeout,mtimeout,is_phrase,is_regsense,is_numeric,min_len,max_len,is_russian);
        }
        // распознать капчу из картинки через сервис captcha24.com
        public string recognize_by_captcha24(string src, string file_path, string key, string path = "http://captcha24.com", bool is_verbose = true, int rtimeout = 5, int mtimeout = 120, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, string frame = "-1", int is_russian = 0)
        {
            // save
            if (src != "")
            {
                wait_element_exist_by_attribute("src", src, 0, frame);

                if (!screenshot_by_src(file_path, src, 0, frame))
                    return null;
            }

            // recognize
            return m_captcha24.recognize(file_path,key,path,is_verbose,rtimeout,mtimeout,is_phrase,is_regsense,is_numeric,min_len,max_len,is_russian);            
        }
        // распознать капчу из картинки через сервис ripcaptcha.com
        public string recognize_by_ripcaptcha(string src, string file_path, string key, string path = "http://ripcaptcha.com", bool is_verbose = true, int rtimeout = 5, int mtimeout = 120, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, string frame = "-1", int is_russian = 0)
        {
            // save
            if (src != "")
            {
                wait_element_exist_by_attribute("src", src, 0, frame);

                if (!screenshot_by_src(file_path, src, 0, frame))
                    return null;
            }

            // recognize
            return m_ripcaptcha.recognize(file_path,key,path,is_verbose,rtimeout,mtimeout,is_phrase,is_regsense,is_numeric,min_len,max_len,is_russian);            
        }
        // распознать капчу из картинки через сервис bypasscaptcha.com
        public string recognize_by_bypasscaptcha(string systemkey, string file_path, string src = "", string frame = "-1")
        {
            // save
            if (src != "")
            {
                wait_element_exist_by_attribute("src", src, 0, frame);

                if (!screenshot_by_src(file_path, src, 0, frame))
                    return null;
            }


            // recognize
            m_bypasscaptcha.set_system_key(systemkey);
            return m_bypasscaptcha.recognize(file_path);            
        }
        // распознать капчу из картинки через сервис captchabot.com
        public string recognize_by_captchabot(string systemkey, string file_path, string src = "", int code = 0, string frame = "-1")
        {
            // save
            if (src != "")
            {
                wait_element_exist_by_attribute("src", src, 0, frame);

                if (!screenshot_by_src(file_path, src, 0, frame))
                    return null;
            }


            // recognize
            m_captchabot.set_system_key(systemkey);
            return m_captchabot.recognize(file_path,code);            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить новую картинку - как часть заданной
        public bool get_image(string src_path,string image_path,int x,int y,int width,int height)
        {
            string[,] aParams = new string[,] { { "src_path", src_path }, { "image_path", image_path }, { "x", x.ToString() }, { "y", y.ToString() },{ "width", width.ToString() },{ "height", height.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }        	
        // получить x - координату вхождения заданной картинки
        public int get_x_of_image(string src_path,string image_path,double koeff=0.95)
        {
            string[,] aParams = new string[,] { { "src_path", src_path }, { "image_path", image_path }, { "koeff", koeff.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }        	
        // получить y - координату вхождения заданной картинки
        public int get_y_of_image(string src_path,string image_path,double koeff=0.95)
        {
            string[,] aParams = new string[,] { { "src_path", src_path }, { "image_path", image_path }, { "koeff", koeff.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }        	
        // получить позицию вхождения заданной картинки
        public Point get_pos_of_image(string src_path,string image_path,double koeff=0.95)
        {
            string[,] aParams = new string[,] { { "src_path", src_path }, { "image_path", image_path }, { "koeff", koeff.ToString() }};
            string[] res = call_get(MethodBase.GetCurrentMethod().Name, aParams).Split('@');
            return new Point(Convert.ToInt32(res[0]), Convert.ToInt32(res[1]));
        }        	
        // получить позицию вхождения заданной картинки
        public List<Point> get_all_pos_of_image(string src_path,string image_path,double koeff=0.95)
        {
		List<Point> outRes = new List<Point>();
		string[,] aParams = new string[,] { { "src_path", src_path }, { "image_path", image_path }, { "koeff", koeff.ToString() }};
		string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
		if (res=="")
			return outRes;
		string[] resa=res.Split('@');
		for (int i=0;i<resa.Length;i++)
		{
			string[] pp=resa[i].Split(':');
			outRes.Add(new Point(Convert.ToInt32(pp[0]),Convert.ToInt32(pp[1])));
		}
		return outRes;
        }        	
        // добавить картинку к заданной
        public bool add_image(string src_path,string image_path,string side="right")
        {
            string[,] aParams = new string[,] { { "src_path", src_path }, { "image_path", image_path } , { "side", side }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }        	
	

        /////////////////////////////////////////////////////////////////////////////////////////////////////
   };
}
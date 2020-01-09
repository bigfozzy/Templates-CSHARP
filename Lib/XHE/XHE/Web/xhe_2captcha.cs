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
    //////////////////////////////////////////////////// Anticapcha /////////////////////////////////////////////////
    public class XHE2capcha : XHEBaseAnticaptcha_Type_1
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // constructor
        public XHE2capcha(string server, XHEScriptBase script)
            : base(server)
        {
            _Script = script;
            soft_id = "293";
            m_Server = server;            
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string recognize(string filename, string apikey="", string path = "http://rucaptcha.com", bool is_verbose = true, int rtimeout = 3, int mtimeout = 3, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, int is_russian = 0)
        {
            return recognize_(filename, apikey, path, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, is_russian);
        }
        // распознать капчу из текста 
        public string recognize_text(string text)
        {
            return recognize_("", api_key, "http://www." + m_Server, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, language, is_question, is_calc, instructions, text);

        }
        // распознать картинки похощие на заданные
        public string recognize_like_images(string filename)
        {
            return recognize_(filename, api_key, "http://www." + m_Server, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, language, is_question, is_calc, instructions, "", 23, false);
        }
        // распознать кассовый чек
        public string recognize_invoice(string filename)
        {
            return recognize_(filename, api_key, "http://www." + m_Server, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, language, is_question, is_calc, instructions, "", 0, true);
        }
        // распознать ReCaptcha v2 (ASIRA) c текстовыми инструкциями
        public string recognize_recaptcha_2_with_text(string filename, string textinstructions)
        {
            return recognize_(filename, api_key, "http://www." + m_Server, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, language, is_question, is_calc, instructions, "", 23, false,true, textinstructions, "");
        }
        // распознать ReCaptcha v2 (ASIRA) 
        public string recognize_recaptcha_2_with_image(string filename, string imageinstructions)
        {
            return recognize_(filename, api_key, "http://www." + m_Server, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, language, is_question, is_calc, instructions, "", 23, false, true, "", imageinstructions);
        }
        // распознать ClickCaptcha (в том числе ReCaptcha v2)
        public string recognize_click_captcha(string filename, string textinstructions = "")
        {
            return recognize_(filename, api_key, "http://www." + m_Server, is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len, language, is_question, is_calc, instructions, "", 0, false, false, textinstructions, "", 1);
        }
        // распознать RotateCaptcha (в том числе FunCaptcha)
        public string recognize_rotate_captcha(string filename, string file_1, string file_2 = "", string file_3 = "",int angle= 40)
        {
            return recognize_(filename, api_key, "http://www."+m_Server,  is_verbose, rtimeout, mtimeout, is_phrase, is_regsense, is_numeric, min_len, max_len,language,is_question,is_calc,instructions, "", 0, false, false,textinstructions, "", 0, "rotatecaptcha",angle,file_1,file_2,file_3);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // распознать капчу рекапча v2
        public string recognize_recaptcha_v2(string pageurl, string googlekey, bool invisible=false,string proxy= "",string proxytype= "")
        {
            // распознать капчу рекапча
            return recognize_userrecaptcha(api_key, "http://www."+m_Server, pageurl, googlekey, invisible, proxy, proxytype);
        }

        // распознать geetest капчу
        public string recognize_geetest(string pageurl, string gt, string challenge, string api_server = "", string proxy = "", string proxytype = "")
        {
            // распознать geetest капчу
            return recognize_geetest_captcha(api_key, "http://www."+m_Server, pageurl, gt, challenge, api_server, proxy, proxytype);
        }
    };
}
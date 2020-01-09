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
using XHE._Helper.Tools.String;

namespace XHE.XHE_Web
{
    //////////////////////////////////////////////////// Anticapcha /////////////////////////////////////////////////
    public class XHEBaseAnticaptcha_Type_1
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ������
        protected XHEScriptBase _Script = null;

        // server address
        public string m_Server;

        // ���� api 
        public string api_key = "";

        // ���������� �� ������� ����������� (���)
        public bool is_verbose = true;
        // ������������ ����� ������� ��������� � �������� (� ������ ttimeout)
        public int max_try = 10;

        // ������� ����� ��������� ��������� ������������� ����� (� ��������)
        public int rtimeout = 5;
        // ������� ����� �������� ��������� ����� �� ������
        public int ttimeout = 20;
        // ������������ ����� ��� ��������� ����� (� ��������)
        public int mtimeout = 120;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 0;1	0 = ���� ����� (�������� �� ���������) 1 = ����� ����� ��� �����
        public bool is_phrase = false;
        // 0 = ������� ������ �� ����� �������� (�������� �� ��������� ) 1 = ������� ������ ����� ��������
        public bool is_regsense = false;
        // 0 = �������� �� ������������ (�������� �� ��������� ) 1 = �� ����������� ����� ������, �������� ������ �������� �����
        public bool is_question = false;
        // 0 = �������� �� ������������ (�������� �� ���������) 1 = ����� ������� ������ �� ���� (� ���������� ��� ��������� ��������: 2 = ����� ������� ������ �� ���� 3 = ����� ������� ���� ������ �� ����, ���� ������ �� ����.)
        public bool is_numeric = false;
        // 0 = �������� �� ������������ (�������� �� ���������) 1 = ��������� ����� ��������� �������������� �������� � �����
        public bool is_calc = false;
        // 0 = �������� �� ������������ (�������� �� ���������) 1..20 = ����������� ���������� ������ � ������
        public int min_len = 0;
        // 0 = �������� �� ������������ (�������� �� ���������)	1..20 = ������������ ���������� ������ � ������
        public int max_len = 0;
        // 0 = �������� �� ������������ (�������� �� ���������) 1 = �� ����� ������ ������������� ����� (� ��������� ��� ��������� �������� 2 = �� ����� ������ ��������� �����)
        public int language = 0;

        // �����, ������� ����� ������� ���������. ����� ��������� � ���� ���������� �� �������� �����. ����������� - 140 ��������. ����� ���������� ����� � ��������� UTF-8. (�������� ��� ��������� ����� ��������)
        public string instructions ="";

        // �������� �� ����� - ��������
        public bool is_recaptcha =false;
        // ��������� ���������� � �������
        public string textinstructions ="";
        // �������� ���������� � �������
        public string imginstructions ="";

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // capcha id
        public string last_capcha_id;
        // capcha file
        public string last_capcha_filename;
        // capcha reuslt
        public string last_capcha_result;
        // capcha error
        public string last_capcha_error;

        protected string soft_id="";

        int try_count = 30;

        // constructor
        public XHEBaseAnticaptcha_Type_1(string server)
        {
            m_Server = server;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // get last capcha id
        public string get_last_capcha_id()
        {
            return last_capcha_id;
        }
        // get last capcha file
        public string get_last_capcha_filename()
        {
            return last_capcha_filename;
        }
        // get last capcha error
        public string get_last_capcha_error()
        {
            return last_capcha_error;
        }
        // get last capcha result
        public string get_last_capcha_result()
        {
            return last_capcha_result;
        }
        // report bug capcha
        public string report_bug_capcha(string key,string id)
        {
            string result;
            using (var webClient = new WebClient())
            {
                result = webClient.DownloadString(string.Format("http://{0}/res.php?key={1}&action=reportbad&id={2}", m_Server, key, id));
            }
            return result;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] get_post_file(string filename)
        {
            if (filename == "")
                return null;

            byte[] imageData;
            if (filename.Contains("://"))
            {
                using (var webClient = new WebClient())
                {
                    imageData = webClient.DownloadData(filename);
                }
            }
            else
            {
                if (!File.Exists(filename))
                {
                    return null;
                }

                imageData = File.ReadAllBytes(filename);
            }

            return imageData;
        }

        // ���������� ������� �����
        protected string recognize_(string filename, string apikey, string path="",bool is_verbose = true, int rtimeout = 3, int mtimeout = 3, bool is_phrase = false, bool is_regsense = false, bool is_numeric = false, int min_len = 0, int max_len = 0, int is_russian = 0, bool is_question= false,bool is_calc= false, string instructions= "", string textcaptcha= "",int id_constructor= 0, bool is_invoice= false,
		bool is_recaptcha= false,string textinstructions= "",string imginstructions= "",int coordinatescaptcha=0,string method= "",int angle= 0, string file_1= "",string file_2= "",string file_3= "",bool is_audio_recaptcha= false ,bool is_solveaudio= false)
        {

            // �������� apikey
            if (apikey == "")
            {
                if (api_key == "")
                {
                    XHEScriptBase.echo("API key is not setted\n");
                    return "API_KEY_NOT_SET";
                }
                else
                    apikey = api_key;
            }
            // ������� ��������
            if (rtimeout == 3)
                rtimeout = this.rtimeout;

            if (mtimeout == 3)
                mtimeout = this.mtimeout;

            // ������� ������ �� ��������� �����
            last_capcha_id = "-1";
            last_capcha_filename = filename;
            // 
            byte[] imageData =  get_post_file(filename);

            if (imageData == null && textcaptcha=="")
            {
                XHEScriptBase.echo("image file not found\n");
                return "ERROR_IMAGE_FILE_NOT_FOUND";
            }

            byte[] imginstructions_file = null;
            if (imginstructions != "")
            {
                // ���������� ���� ����������� ���������� � �������
                imginstructions_file = get_post_file(imginstructions);
                if (imginstructions_file == null)
                {
                    // ���
                    if (is_verbose)
                        XHEScriptBase.echo("file imginstructions not found\n");
                    last_capcha_result = "";
                    return "ERROR_FILE_IMGINSTRUCTIONS_NOT_FOUND";
                }
            }
            // ���������� ���� 1 rotate captcha
            byte[] file_1_file = null;
            if(file_1 != "")
               file_1_file = get_post_file(file_1);

            // ���������� ���� 2 rotate captcha
            byte[] file_2_file = null;
            if (file_2 != "")
               file_2_file = get_post_file(file_2);

            // ���������� ���� 3 rotate captcha
            byte[] file_3_file = null;
            if (file_3 != "")
                file_3_file = get_post_file(file_3);
           
            var postValues = new NameValueCollection
            {
                { "key", apikey },
                { "method", "base64" },
                { "soft_id", soft_id },
            };
            if(imageData!=null) postValues.Add("body", Convert.ToBase64String(imageData));
            if (min_len > 0) postValues.Add("min_len", min_len.ToString());
            if (max_len > 0) postValues.Add("max_len", max_len.ToString());
            if (is_numeric) postValues.Add("numeric", "1");
            if (is_phrase) postValues.Add("phrase", "1");
            if (is_regsense) postValues.Add("regsense", "1");
            if (is_calc) postValues.Add("calc", "1");
            if (is_russian != 0)
            {
                postValues.Add("language", is_russian.ToString());
                postValues.Add("is_russian", is_russian.ToString());
            }

            if (imginstructions != "")
                postValues.Add("imginstructions", Convert.ToBase64String(imginstructions_file));

            if (instructions != "")
                postValues.Add("textinstructions", instructions);

            if (textcaptcha != "")
                postValues.Add("textcaptcha", textcaptcha);
            if (id_constructor!=0)
                postValues.Add("id_constructor", id_constructor.ToString());
            if (is_recaptcha)
                postValues.Add("is_recaptcha", "1");

            if (textinstructions != "")
                postValues.Add("textinstructions", textinstructions);

            if (coordinatescaptcha != 0)
                postValues.Add("coordinatescaptcha", coordinatescaptcha.ToString());
            if (method != "")
                postValues.Add("method", method);
            if (angle != 0)
                postValues.Add("angle", angle.ToString());
            if (file_1!="")
                postValues.Add("file_1", Convert.ToBase64String(file_1_file));
            if (file_2 != "")
                postValues.Add("file_2", Convert.ToBase64String(file_2_file));
            if (file_3 != "")
                postValues.Add("file_3", Convert.ToBase64String(file_3_file));
            if (is_audio_recaptcha)
                postValues.Add("recaptchavoice", "1");
            else if (is_solveaudio)
                postValues.Add("solveaudio", "1");

            // ��� �������
            /*
            if (is_verbose)
            {
                Console.WriteLine("post argumnets: \n");
                StringTools.PrintKeysAndValues2(postValues);
            }*/

            var result = "";
            using (var webClient = new WebClient())
            {
                for (int i = 0; i < try_count; i++)
                {
                    result = Encoding.UTF8.GetString(webClient.UploadValues("http://" + m_Server + "/in.php", postValues));
                    if (result.Contains("OK|")) break;
                    if (result.Contains("ERROR_NO_SLOT_AVAILABLE"))
                    {
                        if (is_verbose)
                        {
                            XHEScriptBase.echo("ERROR_NO_SLOT_AVAILABLE => try_" + (i + 1) + " ");
                            XHEScriptBase.echo("waiting for " + ttimeout + " seconds\n");
                        }

                        Thread.Sleep(ttimeout * 1000);
                        continue;
                    }
                    if (result.Contains("ERROR_"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (result.Contains("IP_BANNED"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned banned: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (!result.Contains("OK|"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return "UNKNOWN_ERROR: " + result;
                    }
                }

                if (result.Contains("ERROR_"))
                {
                    if (is_verbose)
                        XHEScriptBase.echo("server returned error: " + result + "\n");

                    last_capcha_error = result;
                    last_capcha_result = result;
                    return result;
                }

                var captchaId = result.Replace("OK|", "").Trim();
                last_capcha_id = captchaId;

                if (is_verbose)
                    XHEScriptBase.echo("captcha sent, got captcha ID: " + last_capcha_id + "\n");

                while(true)
                {
                   // Thread.Sleep(mtimeout);
                    result = webClient.DownloadString(string.Format("{0}/res.php?key={1}&action=get&id={2}", path, apikey, captchaId));

                    if (result.Contains("ERROR_"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (result.Contains("CAPCHA_NOT_READY"))
                    {
                        if (is_verbose) XHEScriptBase.echo("captcha is not ready yet\n");
                        int waittime = 0;
                        waittime += rtimeout;
                        if (waittime>mtimeout) 
            			{
                            if (is_verbose)
                                XHEScriptBase.echo("timelimit ("+mtimeout.ToString()+") hit\n");

                            break;
                        }

                        if (is_verbose)
                            XHEScriptBase.echo("waiting for "+rtimeout.ToString()+" seconds\n");

                        Thread.Sleep(rtimeout * 1000);

				        continue;
                    }                
                   
                    if (result.Contains("OK|"))
                    {
                        last_capcha_error = "";
                        last_capcha_result = result;
                        return result.Replace("OK|", "").Trim();
                    }
                }
            }

            last_capcha_result = result;
            return result;
        }

       
        // ���������� ����� �������
        /*
        method	������	��	userrecaptcha � ����������, ��� �� ������� ReCaptcha V2 � ������� ������ ������
        googlekey	������	��	�������� ��������� k ��� data-sitekey, ������� �� ����� � ���� ��������
        pageurl	������	��	������ URL ��������, �� ������� �� ������� ReCaptcha V2
        invisible	�����
        �� ���������: 0	���	1 � ������� ���, ��� �� ����� ��������� ReCaptcha. 0 � ������� ReCaptcha.
        proxy	������	���	��� ������������� �� IP: IP_�����:����
        ������: proxy=123.123.123.123:3128
        ��� ������������� �� ������ � ������: �����:������@IP_�����:����
        ������: proxy=proxyuser:strongPassword@123.123.123.123:3128
        proxytype	������	���	��� ������ ������: HTTP, HTTPS, SOCKS4, SOCKS5.
        ������: proxytype=SOCKS4
        */
        public string recognize_userrecaptcha(string apikey,string path = "", string pageurl="", string googlekey="", bool invisible= false, string proxy = "", string proxytype = "", string method = "userrecaptcha")
        {
            // �������� apikey
            if (apikey == "")
            {
                if (api_key == "")
                {
                    XHEScriptBase.echo("API key is not setted\n");
                    return "API_KEY_NOT_SET";
                }
                else
                    apikey = api_key;
            }

            // ��������� $pageurl
            if (pageurl == "")
            {
                XHEScriptBase.echo("pageurl is not setted\n");
                return "PAGEURL_NOT_SET";
            }
            // ��������� $pageurl
            if (googlekey == "")
            {
                XHEScriptBase.echo("googlekey is not setted\n");
                return "GOOGLE_KEY_NOT_SET";
            }

            // ������� ������ �� ��������� �����
            last_capcha_id = "-1";

            var postValues = new NameValueCollection
            {
                { "key", apikey },
                { "method", method },
                { "soft_id", soft_id },
            };

            postValues.Add("pageurl", pageurl);
            postValues.Add("googlekey", googlekey);

            // �� ������� ������� v2
            if (invisible)
                postValues.Add("invisible", "1");


            // ������������ ������ 
            if (proxy != "")
            {
                postValues.Add("proxy", proxy);

                if (proxytype == "")
                    postValues.Add("proxytype", "HTTP");
                else
                    postValues.Add("proxytype", proxytype);

            }

            // ��� �������
            if (is_verbose)
            {
                Console.WriteLine("post argumnets: \n");
                StringTools.PrintKeysAndValues2(postValues);
            }

            var result = "";
            using (var webClient = new WebClient())
            {
                for (int i = 0; i < try_count; i++)
                {
                    result = Encoding.UTF8.GetString(webClient.UploadValues("http://" + m_Server + "/in.php", postValues));
                    if (result.Contains("OK|")) break;
                    if (result.Contains("ERROR_NO_SLOT_AVAILABLE"))
                    {
                        if (is_verbose)
                        {
                            XHEScriptBase.echo("ERROR_NO_SLOT_AVAILABLE => try_" + (i + 1) + " ");
                            XHEScriptBase.echo("waiting for " + ttimeout + " seconds\n");
                        }

                        Thread.Sleep(ttimeout * 1000);
                        continue;
                    }
                    if (result.Contains("ERROR_"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (result.Contains("IP_BANNED"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned banned: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (!result.Contains("OK|"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return "UNKNOWN_ERROR: " + result;
                    }
                }

                if (result.Contains("ERROR_"))
                {
                    if (is_verbose)
                        XHEScriptBase.echo("server returned error: " + result + "\n");

                    last_capcha_error = result;
                    last_capcha_result = result;
                    return result;
                }

                var captchaId = result.Replace("OK|", "").Trim();
                last_capcha_id = captchaId;

                if (is_verbose)
                    XHEScriptBase.echo("captcha sent, got captcha ID: " + last_capcha_id + "\n");

                while (true)
                {
                    //Thread.Sleep(mtimeout);
                    result = webClient.DownloadString(string.Format("{0}/res.php?key={1}&action=get&id={2}", path, apikey, captchaId));

                    if (result.Contains("ERROR_"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (result.Contains("CAPCHA_NOT_READY"))
                    {
                        if (is_verbose) XHEScriptBase.echo("captcha is not ready yet\n");
                        int waittime = 0;
                        waittime += rtimeout;
                        if (waittime > mtimeout)
                        {
                            if (is_verbose)
                                XHEScriptBase.echo("timelimit (" + mtimeout.ToString() + ") hit\n");
                            break;
                        }
                        if (is_verbose)
                            XHEScriptBase.echo("waiting for " + rtimeout.ToString() + " seconds\n");

                        Thread.Sleep(rtimeout*1000);

                        continue;
                    }

                    if (result.Contains("OK|"))
                    {
                        last_capcha_error = "";
                        last_capcha_result = result;
                        return result.Replace("OK|", "").Trim();
                    }
                }
            }

            last_capcha_result = result;
            return result;
        }

        // ���������� geetest
        public string recognize_geetest_captcha(string apikey, string path = "", string pageurl="", string gt="", string challenge="", string api_server = "", string proxy = "", string proxytype = "", string method = "geetest")
        {
            // �������� apikey
            if (apikey == "")
            {
                if (api_key == "")
                {
                    XHEScriptBase.echo("API key is not setted\n");
                    return "API_KEY_NOT_SET";
                }
                else
                    apikey = api_key;
            }

            // ��������� $pageurl
            if (pageurl == "")
            {
                XHEScriptBase.echo("pageurl is not setted\n");
                return "PAGEURL_NOT_SET";
            }
            // ��������� gt
            if (gt == "")
            {
                XHEScriptBase.echo("gt is not setted\n");
                return "GT_NOT_SET";
            }

            // ��������� gt
            if (challenge == "")
            {
                XHEScriptBase.echo("challenge is not setted\n");
                return "CHALLENGE_NOT_SET";
            }

            // ������� ������ �� ��������� �����
            last_capcha_id = "-1";

            var postValues = new NameValueCollection
            {
                { "key", apikey },
                { "method", method },
                { "soft_id", soft_id },
            };

            postValues.Add("gt", gt);
            postValues.Add("pageurl", pageurl);
            postValues.Add("challenge", challenge);
            postValues.Add("api_server", api_server);


            // ������������ ������ 
            if (proxy != "")
            {
                postValues.Add("proxy", proxy);

                if (proxytype == "")
                    postValues.Add("proxytype", "HTTP");
                else
                    postValues.Add("proxytype", proxytype);

            }

            // ��� �������
            if (is_verbose)
            {
                Console.WriteLine("post argumnets: \n");
                StringTools.PrintKeysAndValues2(postValues);
            }

            var result = "";
            using (var webClient = new WebClient())
            {
                for (int i = 0; i < try_count; i++)
                {
                    result = Encoding.UTF8.GetString(webClient.UploadValues("http://" + m_Server + "/in.php", postValues));
                    if (result.Contains("OK|")) break;
                    if (result.Contains("ERROR_NO_SLOT_AVAILABLE"))
                    {
                        if (is_verbose)
                        {
                            XHEScriptBase.echo("ERROR_NO_SLOT_AVAILABLE => try_" + (i + 1) + " ");
                            XHEScriptBase.echo("waiting for " + ttimeout + " seconds\n");
                        }

                        Thread.Sleep(ttimeout * 1000);
                        continue;
                    }
                    if (result.Contains("ERROR_"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (result.Contains("IP_BANNED"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned banned: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (!result.Contains("OK|"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return "UNKNOWN_ERROR: " + result;
                    }
                }

                if (result.Contains("ERROR_"))
                {
                    if (is_verbose)
                        XHEScriptBase.echo("server returned error: " + result + "\n");

                    last_capcha_error = result;
                    last_capcha_result = result;
                    return result;
                }

                var captchaId = result.Replace("OK|", "").Trim();
                last_capcha_id = captchaId;

                if (is_verbose)
                    XHEScriptBase.echo("captcha sent, got captcha ID: " + last_capcha_id + "\n");

                while (true)
                {
                    //Thread.Sleep(mtimeout);
                    result = webClient.DownloadString(string.Format("{0}/res.php?key={1}&action=get&id={2}", path, apikey, captchaId));

                    if (result.Contains("ERROR_"))
                    {
                        if (is_verbose)
                            XHEScriptBase.echo("server returned error: " + result + "\n");

                        last_capcha_error = result;
                        last_capcha_result = result;
                        return result;
                    }

                    if (result.Contains("CAPCHA_NOT_READY"))
                    {
                        if (is_verbose) XHEScriptBase.echo("captcha is not ready yet\n");
                        int waittime = 0;
                        waittime += rtimeout;
                        if (waittime > mtimeout)
                        {
                            if (is_verbose)
                                XHEScriptBase.echo("timelimit (" + mtimeout.ToString() + ") hit\n");
                            break;
                        }
                        if (is_verbose)
                            XHEScriptBase.echo("waiting for " + rtimeout.ToString() + " seconds\n");

                        Thread.Sleep(rtimeout * 1000);

                        continue;
                    }

                    if (result.Contains("OK|"))
                    {
                        last_capcha_error = "";
                        last_capcha_result = result;
                        return result.Replace("OK|", "").Trim();
                    }
                }
            }

            last_capcha_result = result;
            return result;

        }

            /*
       
        // ���������� geetest
        function recognize_geetest_captcha($apikey,$path = '',$pageurl, $gt, $challenge, $api_server= "", $proxy= "", $proxytype= "", $method= "geetest")
        {
            // �������� apikey
            if ($apikey == "")
		{
                if ($this->api_key == "")
			{
                    echo "API key is not setted\n";
                    return false;
                }
			else
				$apikey =$this->api_key;
            }

            // ��������� $pageurl
            if ($pageurl == "")
        {
                echo "pageurl is not setted\n";
                return false;
            }
            // ��������� $gt
            if ($gt == "")
        {
                echo "gt is not setted\n";
                return false;
            }

            // ��������� $gt
            if ($challenge == "")
        {
                echo "challenge is not setted\n";
                return false;
            }
        
		// ������� ������ �� ��������� �����
		$this->last_capcha_id = -1;
		$this->last_capcha_filename =$pageurl;
		
		// ������������ post ���������
		$postdata = array(
            'key'       => $apikey,
            'soft_id'	=> $this->soft_id);
		// �������������� post ���������
		
		$postdata['pageurl'] = $pageurl;
		$postdata['gt'] = $gt;
        $postdata['challenge'] = $challenge;
        $postdata['api_server'] = $api_server;

            if ($method != "")
			$postdata['method'] = $method;

            // ������������ ������ 
            if ($proxy != "")
		{
			$postdata['proxy'] = $proxy;

                if ($proxytype == "")
			   $postdata['proxytype'] = 'HTTP';
			else
			   $postdata['proxytype'] = $proxytype;
		}

		$result = "";
		for ($i=0;$i<$this->max_try;$i++)
		{
			// ������� ������
			$ch = curl_init();
			
			curl_setopt($ch, CURLOPT_URL,             $path.'/in.php');
			curl_setopt($ch, CURLOPT_RETURNTRANSFER,     1);
			curl_setopt($ch, CURLOPT_TIMEOUT,             60);
			curl_setopt($ch, CURLOPT_POST,                 1);
			curl_setopt($ch, CURLOPT_POSTFIELDS,         $postdata);
			$result = curl_exec($ch);

            print_r($postdata);

			// �� ����� ������� ��������� ����
			if (curl_errno($ch)) 
			{
				// ���
				if ($this->is_verbose) 
				  echo "CURL returned error: ".curl_error($ch)."\n";

				$this->last_capcha_result=false;
				return false;
			}

			// ������� ������
			curl_close($ch);

			// ��� ��������� ������
			if (strpos($result, "ERROR_NO_SLOT_AVAILABLE")!==false)
			{
				// ���
    			if ($this->is_verbose)
                { 
					echo " ERROR_NO_SLOT_AVAILABLE => try_".($i+1)." ";
					echo "waiting for $this->ttimeout seconds\n";
                }
				sleep($this->ttimeout);
                continue;
			}
			// ������ ������ ������ ����������
			if (strpos($result, "ERROR")!==false)
			{
				// ���
    				if ($this->is_verbose) 
					echo "server returned error: $result\n";
				$this->last_capcha_result=false;
				return false;
			}
			// ������ ������ ������ - ��������
			if (strpos($result, 'IP_BANNED')!==false)
			{
				// ���
	       			if ($this->is_verbose) 
					echo "server returned banned: $result\n";
				$this->last_capcha_result=false;
				return false;
			}
			break;
		}
		
		$ex = explode("|", $result);		
		if ($this->is_verbose)
			echo $result."\n";
		if ($ex[0]!="OK")
		{
			// ���
				if ($this->is_verbose) 
				echo "server not return captcha id: $result\n";
			$this->last_capcha_result=false;
			return false;
		}
		$captcha_id = $ex[1];

		if ($this->is_verbose) 
				echo "captcha id: $captcha_id\n";
		$this->last_capcha_id=$captcha_id;

		// ���
    		if ($this->is_verbose) 
			echo "captcha sent, got captcha ID $captcha_id\n";

		// ���� ������� 1
		$waittime = 0;
		if ($this->is_verbose) 
			echo "waiting for $this->ttimeout seconds\n";
		
		sleep($this->ttimeout);
        // ������� �����
		$result="";

		// ������� ��� ����� (�����)
		while(true)
		{
			// �������� ��������� ����������� �����
			if(strpos($result, 'OK|')===false)
			{
				$result = file_get_contents($path."/res.php?key=".$apikey."&soft_id=".$this->soft_id."&action=get&id=".$captcha_id);
			}
            else
            {
                $ex = explode("|", $result);	

                $this->last_capcha_result=$ex[1];
				return trim($this->last_capcha_result);
            }

        	// ���
            if ($this->is_verbose) 
				echo "server returned answer: $result\n";


			// ������ ������ ������ ���������� 
			if (strpos($result, 'ERROR')!==false)
			{
				// ���
            			if ($this->is_verbose) 
					echo "server returned error: $result\n";
				$this->last_capcha_result=false;
				return false;
			}
			
			if (strpos($result, 'CAPCHA_NOT_READY')!==false)
			{
            			if ($this->is_verbose) echo "captcha is not ready yet\n";
            			$waittime += $this->rtimeout;
            			if ($waittime>$this->mtimeout) 
            			{
            				if ($this->is_verbose) 
						        echo "timelimit ($this->mtimeout) hit\n";				
            				break;
            			}
        			if ($this->is_verbose) 
					echo "waiting for $this->rtimeout seconds\n";
				
            	    sleep($this->rtimeout);
                    
				continue;
			}

			if (strpos($result, 'status":1')!==false)
			{
				if ($this->is_verbose) 
				    echo "last capcha resul $result\n";
				   
				$this->last_capcha_result=$result;
				return trim($this->last_capcha_result);
			}
			
		}
        
		// �� ���������
		$this->last_capcha_result=false;
		return false;
		
	}*/
    };
}
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
    /////////////////////////////////////// Browser ////////////////////////////////////////////////////
    public class XHEBrowser : XHEBaseObject
    {
        public int Wait_Try_Navigate_Second = 30;
        public int Wait_Try_Navigate_Count = 1;

        ////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
        // server initialization
        public XHEBrowser(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Browser";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать число закладок
        public bool set_count(int count)
        {
            string[,] aParams = new string[,] { { "count", count.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить число закладок
        public int get_count()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить активную закладку 
        public int get_active_browser()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать активную закладку 
        public bool set_active_browser(int num, bool activate = true)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() }, { "activate", activate.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // добавить закладку браузера
        public bool add_tab()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // закрыть текущую закладку (Main не закрывается)
        public bool close()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // закрыть все открытые закладки (Main или Active не закрывается)
        public bool close_all_tabs(string close_type="")
        {
            string[,] aParams = new string[,] { { "close_type", close_type } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// перейти на заданный урл
        /// </summary>
        /// <param name="url"></param>
        /// <param name="use_cache"></param>
        /// <param name="bUse_wait"></param>
        /// <returns></returns>
        public bool navigate(string url, bool use_cache = true, bool bUse_wait = true)
        {
            string[,] aParams = new string[,] { { "url", url }, { "use_cache", use_cache.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            //if (bUse_wait)
            wait_for();
            if (this.get_last_navigation_error() != "")
                return false;
            return true;
        }
        /// <summary>
        /// получить ошибку последней навигации
        /// </summary>
        /// <returns></returns>
        public string get_last_navigation_error()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        /// <summary>
        /// обновить текущую страницу
        /// </summary>
        /// <returns></returns>
        public bool refresh(bool ignore_cache = true)
        {
            string[,] aParams = new string[,] { { "ignore_cache", ignore_cache.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            wait_for();
            return res;
        }
        // остановить текущий переход
        public bool stop()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // перейти на предыдущую страницу
        public bool go_back()
        {
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);
            wait_for();
            return res;
        }
        // перейти на следующую страницу
        public bool go_forward()
        {
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);
            wait_for();
            return res;
        }
        // задать домашнюю страницу
        public bool set_home_page(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // перейти на домашнюю страницу
        public bool navigate_to_home_page()
        {
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);
            wait_for();
            return res;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // ожидание загрузки страницы в браузере в течении заданного времени и заданного числа повторов
        public bool wait_for(int Try_Navigate_Second = 15, int Try_Navigate_Count = 1)
        {
            if (Try_Navigate_Second == 0)
                return true;
            if (Wait_Try_Navigate_Second != -1)
                Try_Navigate_Second = Wait_Try_Navigate_Second;
            if (Wait_Try_Navigate_Count != -1)
                Try_Navigate_Count = Wait_Try_Navigate_Count;

            int count = 0;
            double second = 0.5;

            Thread.Sleep(500);
            bool is_bused = this.is_busy();

            while (is_bused)
            {
                if ((int)second >= (int)Try_Navigate_Second)
                {
                    second = 0;
                    count++;
                    if ((int)count >= (int)Try_Navigate_Count)
                    {
                        return false;
                    }

                    // повторим попытку
                    navigate(call_function("WebPage.get_location_url"));
                    Thread.Sleep(500);
                }
                else
                {
                    Thread.Sleep(500);
                    second = second + 0.5;
                }

                is_bused = this.is_busy();
            }
            return true;
        }

        // ожидание отработки JS в браузере в течении заданного времени
        public bool wait_js(int Try_Second = 30)
        {
            Thread.Sleep(1000);
            int second = 1;
            bool is_completed = call_function("ScriptElement.is_all_completed") == "true";
            while (is_completed == false)
            {
                Thread.Sleep(1000);
                second = second + 1;
                is_completed = call_function("ScriptElement.is_all_completed") == "true";
                if ((int)second >= (int)Try_Second)
                    return is_completed;
            }
            return true;
        }
        // ожидание загрузки страницы в браузере
        public bool wait(int num = 1)
        {
            bool is_busy = this.is_busy(num);
            while (is_busy)
            {
                Thread.Sleep(num);
                is_busy = this.is_busy(num);
            }
            return true;

        }
        // проверка занятости заданого браузера
        public bool is_busy(int num = -1)
        {
            if (call_function("Browser.IsBusy?num=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(num.ToString()))) == "true")
                return true;
            else
                return false;

        }
        // получить состояние занятости браузера
        public string get_ready_state()
        {
            return call_function("Browser.GetReadyState");
        }

        // задать парметры ожидания навигации (без параметров - сброс)
        public bool set_wait_params(int Try_Navigate_Second = -1, int Try_Navigate_Count = -1)
        {
            Wait_Try_Navigate_Second = Try_Navigate_Second;
            Wait_Try_Navigate_Count = Try_Navigate_Count;
            return true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // разрешить или запретить поп-апы
        public bool enable_popup(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить картинки
        public bool enable_images(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить ActiveX
        public bool enable_activex(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить Java Script's
        public bool enable_java_script(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            Thread.Sleep(1000);
            return res;
        }
        // включить или выключить звуки
        public bool enable_sounds(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить видео
        public bool enable_video(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить Java
        public bool enable_java(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить фреймы
        public bool enable_frames(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить шрифты
        public bool enable_fonts(bool enable = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить удаленные шрифты
        public bool enable_remote_fonts(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить кэш
        public bool enable_cache(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить dom storage
        public bool enable_dom_storage(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить callback
        public bool enable_callback(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить просмотр JSON
        public bool enable_view_json(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // запретить сообщения о ошибках JS
        public bool disable_script_error(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // запретить диалоги-сообщения о проблемах безопасности
        public bool disable_security_problem_dialogs(bool disable = true)
        {
            string[,] aParams = new string[,] { { "disable", disable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить тихий режим браузера (без интерактивности с пользователем)
        public bool enable_quiet_regime(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить веб сокеты
        public bool enable_web_socket(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить режим - общий кэш и куки для всех копий xhe (как в IE)
        public bool enable_common_cache_and_cookies(bool enable = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить отрисовку картинок через DirextX
        public bool enable_directx(bool enable = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить отрисовку страницы через GPU
        public bool enable_gpu_rendering(bool enable = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить или выключить browser notification
        public bool enable_browser_notification(bool enable = true, bool show = true, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } , { "show", show.ToString() } , { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // проверка включенности поп-апов
        public bool is_enable_popup()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включены ли картинки
        public bool is_enable_images()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включены ли ActiveX
        public bool is_enable_activex()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включенность Java Script
        public bool is_enable_java_script()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить что кэш доступен
        public bool is_enable_cache()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить что dom storage доступен
        public bool is_enable_dom_storage()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить что callback доступен
        public bool is_enable_callback()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить что просмотр json включен
        public bool is_enable_view_json()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включены ли звуки
        public bool is_enable_sounds()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включены ли видео
        bool is_enable_video()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включена ли Java
        public bool is_enable_java()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить включены ли фреймы
        public bool is_enable_frames()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверка включенности сообщений об ошибках JS
        public bool is_disable_script_error()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверка включенности тихого режима
        public bool is_enable_quiet_regime()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверка того что вебсокеты включены
        public bool is_enable_web_socket()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверка того что xhe в режиме общие кэш и куки для всех копий (как в IE)
        public bool is_enable_common_cache_and_cookies()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // вызвать существующий JS
        public bool call_java_script(string func, string parametrs)
        {
            string[,] aParams = new string[,] { { "func", func }, { "parametrs", parametrs } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить произвольный JS
        public bool run_java_script(string script_text, string add_file)
        {
            string[,] aParams = new string[,] { { "script_text", script_text }, { "add_file", add_file } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать начальный JS
        public bool set_init_java_script(string script_text, string add_file)
        {
            string[,] aParams = new string[,] { { "script_text", script_text }, { "add_file", add_file } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать JS, который вызывается после Document Complete
        public bool set_document_complete_java_script(string script_text, string add_file)
        {
            string[,] aParams = new string[,] { { "script_text", script_text }, { "add_file", add_file } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить произвольный JQuery (используя заданную версию jQuery 1,2,3)
        public bool run_jquery(string script_text, string ver = "3")
        {
            string[,] aParams = new string[,] { { "script_text", script_text }, { "ver", ver } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить произвольный Dojo
        public bool run_dojo(string script_text)
        {
            string[,] aParams = new string[,] { { "script_text", script_text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // установить прокси
        public bool enable_proxy(string connection, string proxy, bool need_recreate = true)
        {
            string[,] aParams = new string[,] { { "connection", connection }, { "proxy", proxy } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (need_recreate)
            {
                recreate();
                wait_for();
            }
            return res;

        }
        // убрать прокси
        public bool disable_proxy(string connection, bool need_recreate = true)
        {
            string[,] aParams = new string[,] { { "connection", connection } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (need_recreate)
            {
                recreate();
                wait_for();
            }
            return res;
        }
        // получить текущий прокси
        public string get_current_proxy(string connection="",bool with_auth=false)
        {
            string[,] aParams = new string[,] { { "connection", connection } , { "with_auth", with_auth.ToString() }};
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить версию браузера
        public string get_version(bool numerica = true)
        {
            string[,] aParams = new string[,] { { "numerica", numerica.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить user agent
        public string get_user_agent()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить модель браузера
        public string get_model()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить папку куков
        public string get_cookies_folder()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить папку кэша
        public string get_cache_folder()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать папку куков
        public bool set_cookies_folder(string folder, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "folder", folder }, { "refresh", refresh.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (refresh)
                Thread.Sleep(1000);
            return res;
        }
        // задать папку кэша
        public bool set_cache_folder(string folder, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "folder", folder }, { "refresh", refresh.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (refresh)
                Thread.Sleep(1000);
            return res;
        }
        // сохранить флэш куки
        public bool flash_cookies_save(string folder, string site = "")
        {
            string[,] aParams = new string[,] { { "folder", folder }, { "site", site } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // восстановить флэш куки
        public bool flash_cookies_restore(string folder, string site = "")
        {
            string[,] aParams = new string[,] { { "folder", folder }, { "site", site } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить флэш куки
        public bool flash_cookies_delete(string site = "")
        {
            string[,] aParams = new string[,] { { "site", site } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать user-agent
        public bool set_user_agent(string agent_string, bool refresh = true)
        {
            string[,] aParams = new string[,] { { "agent_string", agent_string }, { "refresh", refresh.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать модель браузера
        public bool set_model(string model)
        {
            string[,] aParams = new string[,] { { "model", model } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // получить ширину страницы
        public int get_page_width()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить высоту страницы
        public int get_page_height()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить ширину окна браузера
        public int get_window_width()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // поулчить высоту окна браузера
        public int get_window_height()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить выбранный текст в браузере
        public string get_selected_text(bool as_html)
        {
            string[,] aParams = new string[,] { { "as_html", as_html.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать ширину браузера
        public bool set_width(int width)
        {
            string[,] aParams = new string[,] { { "width", width.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать высоту браузера
        public bool set_height(int height)
        {
            string[,] aParams = new string[,] { { "height", height.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать позицию вертикального скролла
        public bool set_vertical_scroll_pos(int y)
        {
            string[,] aParams = new string[,] { { "y", y.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать позицию горизонтального скролла
        public bool set_horizontal_scroll_pos(int x)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить позицию вертикального скролла
        public int get_vertical_scroll_pos()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить позицию горизонтального скролла
        public int get_horizontal_scroll_pos()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////		

        // очистить заданные куки
        public bool clear_cookies(string match_name, bool clear_session = false, bool clear_flash = true)
        {
            string[,] aParams = new string[,] { { "match_name", match_name }, { "clear_session", clear_session.ToString() }, { "clear_flash", clear_flash.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // очистить Local Storages
        public bool clear_local_storage()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // очистить Indexed DB
        public bool clear_indexed_db()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить куки для текущей страницы
        public string get_cookie(bool as_json = false)
        {
            string[,] aParams = new string[,] { { "as_json", as_json.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // установить куки
        public bool set_cookie(string cookie)
        {
            string[,] aParams = new string[,] { { "cookie", cookie } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить куки для заданного урла
        public string get_cookie_for_url(string url, string name, bool as_json = false )
        {
            string[,] aParams = new string[,] { { "url", url } , { "name", name } , { "as_json", as_json.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать куки для заданного урла
        public bool set_cookie_for_url(string url, string name, string cookie, string expires="", string domain="", string path="", bool httpOnly=false, bool secure=false)
        {
            string[,] aParams = new string[,] { { "url", url }, { "name", name }, { "cookie", cookie } , { "expires", expires }, { "domain", domain }, { "path", path }, { "httpOnly", httpOnly.ToString() }, { "secure", secure.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
	// импорт куков из заданного формата
	public bool import_cookies(string url,string cookies)
	{
		string[,] aParams = new string[,] { { "url", url }, { "cookies", cookies } };
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // получить источник поп-апа по источнику
        public string get_popup_source(string url, int exactly)
        {
            string[,] aParams = new string[,] { { "url", url }, { "exactly", exactly.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // закрыть поп-ап с заданным урлом
        public bool close_popup(string url, int exactly)
        {
            string[,] aParams = new string[,] { { "url", url }, { "exactly", exactly.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // запретить диалоги-сообщения браузера и задать автоответ на них ($answer is one from "Ok","Cancel","Abort","Retry","Ignore","Yes","No")
        public bool enable_browser_message_boxes(bool enable = true, string default_answer = "Ok")
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() }, { "default_answer", default_answer } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить заголовок последнего диалогового сообщения браузера
        public string get_last_messagebox_caption()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить текст последнего диалогового сообщения браузера
        public string get_last_messagebox_text()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить тип последнего диалогового сообщения браузера
        public string get_last_messagebox_type()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // очистить информацию о последнем диалоговом сообщении браузера
        public bool clear_last_messagebox_info()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // установить http авторизацию по умолчанию
        public bool set_default_authorization(string login, string password)
        {
            string[,] aParams = new string[,] { { "login", login }, { "password", password } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сбросить http авторизацию по умолчанию
        public bool reset_default_authorization()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // установить имя серфтификата умолчанию
        public bool set_default_certificate(string text)
        {
            string[,] aParams = new string[,] { { "text", text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // запретить диалог выбора пути для скачивания файлов
        public bool enable_download_file_dialog(bool enable = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверить включенность диалога выбора пути для скачивания файлов
        public bool is_enable_download_file_dialog()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать папку по умолчанию куда будут скачиваться файлы, если выключен диалог выбора пути
        public bool set_default_download(string folder)
        {
            string[,] aParams = new string[,] { { "folder", folder } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сбросить параметры диалога скачивания файлов
        public bool reset_default_download()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить идентификатор последней загрузки
        public int get_last_download_id()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить статус завершения загрузки с заданным id
        public int is_download_complete(int id)
        {
            string[,] aParams = new string[,] { { "id", id.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить информацию о загрузке
        public string get_download_info(int id)
        {
            string[,] aParams = new string[,] { { "id", id.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // задать как открывать popup
        public bool set_popup_type(int popup_type)
        {
            string[,] aParams = new string[,] { { "popup_type", popup_type.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать google api key
        public bool set_google_api_key(string api_key)
        {
            string[,] aParams = new string[,] { { "api_key", api_key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать google default client id
        public bool set_google_default_client_id(string client_id)
        {
            string[,] aParams = new string[,] { { "client_id", client_id } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать google default client secret
        public bool set_google_default_client_secret(string client_secret)
        {
            string[,] aParams = new string[,] { { "client_secret", client_secret } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать акцепт
        public bool set_accept(string accept_string)
        {
            string[,] aParams = new string[,] { { "accept_string", accept_string } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать язык в акцептах (заголовках запроса браузера)
        public bool set_accept_language(string accept_string)
        {
            string[,] aParams = new string[,] { { "accept_string", accept_string } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать кодировку в акцептах (заголовках запроса браузера)
        public bool set_accept_encoding(string accept_string)
        {
            string[,] aParams = new string[,] { { "accept_string", accept_string } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать информацию о приложении
        public bool set_app_info(string appName = "", string appCodeName = "", string appMinorVersion = "", string product = "", string productSub = "", string vendor="", string vendorSub="")
        {
            string[,] aParams = new string[,] { { "appName", appName }, { "appCodeName", appCodeName }, { "appMinorVersion", appMinorVersion }, { "product", product }, { "productSub", productSub } , { "vendor", vendor }, { "vendorSub", vendorSub }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать информацию о приложении
        public bool set_hardware_info(int hardwareConcurrency = -1, int deviceMemory = -1, double devicePixelRatio = -1)
        {
            string[,] aParams = new string[,] { { "hardwareConcurrency", hardwareConcurrency.ToString() }, { "deviceMemory", deviceMemory.ToString() }, { "devicePixelRatio", devicePixelRatio.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать информацию о плагинах
        public bool set_plugins_info(string plugins_info = "", string mime_types = "")
        {
            string[,] aParams = new string[,] { { "plugins_info", plugins_info }, { "mime_types", mime_types } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать часовой пояс
        public bool set_time_zone(string time_zone = "-100")
        {
            string[,] aParams = new string[,] { { "time_zone", time_zone } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать Internationalization API
        public bool set_internationalization(string locale = "", string timeZone = "", string calendar = "", string numberingSystem = "", string year = "", string month = "", string day = "")
        {
            string[,] aParams = new string[,] { { "locale", locale }, { "timeZone", timeZone }, { "calendar", calendar }, { "numberingSystem", numberingSystem }, { "year", year }, { "month", month }, { "day", day } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать платформу
        public bool set_platform(string platform = "Win32", string cpuClass = "x86")
        {
            string[,] aParams = new string[,] { { "platform", platform }, { "cpuClass", cpuClass } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать геоинформацию
        public bool set_geo(string latitude = "", string longitude = "", string accuracy = "", string altitude = "", string altitudeAccuracy = "", string heading = "", string speed = "")
        {
            string[,] aParams = new string[,] { { "latitude", latitude }, { "longitude", longitude }, { "accuracy", accuracy }, { "altitude", altitude }, { "altitudeAccuracy", altitudeAccuracy }, { "heading", heading }, { "speed", speed } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать язык
        public bool set_language(string language = "ru-Ru")
        {
            string[,] aParams = new string[,] { { "language", language } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            wait_for();
            return res;
        }
        // задать разрешение экрана
        public bool set_screen_resolution(int width, int height, int pixelDepth = 24)
        {
            string[,] aParams = new string[,] { { "width", width.ToString() }, { "height", height.ToString() }, { "pixelDepth", pixelDepth.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать информацию о touch
        public bool set_touch_info(string max_points = "", string ontouchevent = "")
        {
            string[,] aParams = new string[,] { { "max_points", max_points }, { "ontouchevent", ontouchevent } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // указать - отправлять заданные данные canvas (для смены finger print)
        public bool set_canvas_toDataURL(string toDataURL = "")
        {
            string[,] aParams = new string[,] { { "toDataURL", toDataURL } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать рандомный WebGL Fingerprint
        public bool set_random_webgl_fingerprint(bool enable = true, string noiseImage="",string noiseParams="",string glVersion="",string shadingLanguageVersion="",
            string vendor="",string renderer="",string unmaskedVendor="",string unmaskedRenderer="")
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } , { "noiseImage", noiseImage.ToString() } , { "noiseParams", noiseParams.ToString() }, { "unmaskedVendor", unmaskedVendor.ToString() } , { "unmaskedRenderer", unmaskedRenderer.ToString() },
		{ "glVersion", glVersion.ToString() }, { "shadingLanguageVersion", shadingLanguageVersion.ToString() }, { "vendor", vendor.ToString() } , { "renderer", renderer.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
   	// задать случайный Audio fingerprint
	public bool set_random_audio_fingerprint(string noiseAudio="", string noiseFrequence="")
	{		
		string[,] aParams = new string[,] { { "noiseAudio", noiseAudio } , { "noiseFrequence", noiseFrequence } };
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}	
   	// задать случайный Bounds fingerprint
	public bool set_random_bounds_fingerprint(int noise=-1)
	{		
		string[,] aParams = new string[,] { { "noise", noise.ToString() } };
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}	
        // указать сайтам не отслеживать наши действия
        public bool set_do_not_track(bool doNotTrack = true)
        {
            string[,] aParams = new string[,] { { "doNotTrack", doNotTrack.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать реферер
        public bool set_referer(string referer)
        {
            string[,] aParams = new string[,] { { "referer", referer } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить реферер
        public string get_referer()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // выполнить команду вставки в браузер
        public bool paste(string text = "")
        {
            string[,] aParams = new string[,] { { "text", text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сохранить текущую страницу в файл
        public bool save_page_as(string file)
        {
            string[,] aParams = new string[,] { { "file", file } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить теущий масштаб отображения
        public string get_zoom()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать текущий масштаб отображения
        public bool set_zoom(int zoom)
        {
            string[,] aParams = new string[,] { { "zoom", zoom.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить команду браузера (ex: IDM_PASTE,IDM_COPY,IDM_PRINT etc.)
        public bool run_command(int command)
        {
            string[,] aParams = new string[,] { { "command", command.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // послать get запрос на заданный урл
        public string send_get_query(string url, string data = "", string type = "", bool set_as_page = false, string add_header = "")
        {
            string[,] aParams = new string[,] { { "url", url }, { "data", data }, { "type", type }, { "set_as_page", set_as_page.ToString() }, { "add_header", add_header } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // послать пост запрос на заданный урл
        public string send_post_query(string url, string data = "", string type = "application/x-www-form-urlencoded", bool set_as_page = false, string add_header = "")
        {
            data = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
            string[,] aParams = new string[,] { { "url", url }, { "data", data }, { "type", type }, { "set_as_page", set_as_page.ToString() }, { "add_header", add_header } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверить соединение с интернетом
        public bool check_internet_connection()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить соединение с заданным урлом
        public bool check_connection(string url, int timeout, bool use_cache = false, int num = -1)
        {
            // делаем переход
            if (!navigate(url, use_cache))
                return false;

            int time = 0;
            bool is_busy = this.is_busy(num);
            while (is_busy)
            {
                time++;
                Thread.Sleep(1000);

                is_busy = this.is_busy(num);
                if (time == timeout)
                    return (is_busy);
            }

            string text = call_function("WebPage.get_body");
            if (text == "")
                return false;

            int index = text.IndexOf("Forbidden");
            if (index != -1)
                return false;

            index = text.IndexOf("The page cannot be found");
            if (index != -1)
                return false;

            index = text.IndexOf("Нет подключения к Интернету.");
            if (index != -1)
                return false;

            index = text.IndexOf("Недействительный адрес");
            if (index != -1)
                return false;

            index = text.IndexOf("Эта программа не может отобразить эту веб-страницу");
            if (index != -1)
                return false;

            index = text.IndexOf("Переход на веб-страницу отменен");
            if (index != -1)
                return false;

            index = text.IndexOf("The requested URL could not be retrieved");
            if (index != -1)
                return false;

            index = text.IndexOf("Navigation to the webpage was canceled");
            if (index != -1)
                return false;

            index = text.IndexOf("This program cannot display the webpage");
            if (index != -1)
                return false;

            index = text.IndexOf("Bad Gateway");
            if (index != -1)
                return false;

            index = text.IndexOf("Internal Server Error");
            if (index != -1)
                return false;

            index = text.IndexOf("The website cannot display the page");
            if (index != -1)
                return false;

            return true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // очистить кэш
        public bool clear_cache()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // очитсить историю
        public bool clear_history()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // очистить историю урлов в адреснм комбобоксе
        public bool clear_address_bar_history()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // управление перерисовкой браузера (позволяет экономить ресурсы)
        public bool set_redraw(bool enable = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать fps
        public bool set_fps(int fps)
        {
            string[,] aParams = new string[,] { { "fps", fps.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // управление режимом изолированных закладок
        public bool enable_isolate_tabs(bool enable = true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // пересоздать браузер
        public bool recreate()
        {
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);
            Thread.Sleep(1000);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;

        }

        // сохранить профиль
        public bool save_profile(string path,string name="",string description="")
        {
            string[,] aParams = new string[,] { { "path", path } , { "name", name } , { "description", description }  };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // загрузить профиль
        public bool load_profile(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
        // изменить папку с кукисами
        public bool change_cookies_folder(string folder)
            {
                string[,] aParams = new string[,] { { "folder", folder } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            // изменить папку с кэшем
            public bool change_cache_folder(string folder)
            {
                string[,] aParams = new string[,] { { "folder", folder } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            // задать набор символов в акцептах (заголовках запроса браузера)
            public bool set_accept_charset(string accept_string)
            {
                string[,] aParams = new string[,] { { "accept_string", accept_string } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
        // начать запись видео части экрана
        public bool start_video_record(string path, int fps = 10, int quality = 70, int x = -1, int y = -1, int width = -1, int height = -1, bool as_gray = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "fps", fps.ToString() }, { "quality", quality.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, { "width", width.ToString() }, { "height", height.ToString() }, { "as_gray", as_gray.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // остановить запись видео части экрана
        public bool stop_video_record()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
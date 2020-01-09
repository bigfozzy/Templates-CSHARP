using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XHE.XHE_DOM;
using XHE.XHE_System;
using XHE.XHE_Window;
using XHE.XHE_Web;

namespace XHE
{
    // class for use with single XHE instance
    public class XHEScript : XHEScriptBase,IDisposable
    {
        #region XHE objects       

        // XHE server
        public static string server = "127.0.0.1:7017";
        // XHE password
        public static string password = "";

        // sms testing services 
        public static XHE5Simnet simnet  = null;
        public static XHESmsActivate smsactivate = null;
        public static XHECheapsms cheapsms = null;

        // capcha testing services
        public static XHEAnticapcha anticaptcha = null;
        public static XHECaptcha24 captcha24 = null;
        public static XHERucapcha rucaptcha = null;
        public static XHE2capcha twocaptcha = null;
        
        public static XHERipcaptcha ripcaptcha = null;
        public static XHEBypasscaptcha bypasscaptcha = null;
        public static XHECaptchabot captchabot = null;

        // create Window objects
        public static XHEApplication app = null;
        public static XHEWindowsShell windows = null;
        public static XHEWindow window = null;
        public static XHEMouse mouse = null;

        // create System objects
        public static XHESound sound = null;
        public static XHEDebug debug = null;
        public static XHEScheduler scheduler = null;
        public static XHEKeyboard keyboard = null;
        public static XHEClipboard clipboard = null;
        public static XHETextFile textfile = null;
        public static XHEFile_os file_os = null;
        public static XHEFolder folder = null;

        // create Web objects
        public static XHEBrowser browser = null;
        public static XHEWebPage webpage = null;
        public static XHERaw raw = null;
        public static XHESEO seo = null;
        public static XHEConnection connection = null;
        public static XHEMail mail = null;
        public static XHEFTP ftp = null;
        public static XHESFTP sftp = null;
        public static XHESubmitter submitter = null;
        public static XHEProxyCheker proxycheker = null;
        public static XHEHarvestor harvestor = null;
        public static XHEProxySwitcher proxyswitcher = null;

        // create Dom (container) object
        public static XHEFrame frame = null;
        public static XHEForm form = null;
        public static XHEBody body = null;

        // create Dom (output) objects
        public static XHEAnchor anchor = null;
        public static XHEImage image = null;
        public static XHEInputButton button = null;
        public static XHEDiv div = null;
        public static XHEStyle style = null;
        public static XHESpan span = null;
        public static XHELabel label = null;
        public static XHETD td = null;
        public static XHETR tr = null;
        public static XHETH th = null;
        public static XHEButton btn = null;
        public static XHESelectElement listbox = null;
        public static XHEScriptElement script = null;
        public static XHETable table = null;
        public static XHEH h1 = null;
        public static XHEH h2 = null;
        public static XHEH h3 = null;
        public static XHEH h4 = null;
        public static XHEH h5 = null;
        public static XHEH h6 = null;
        public static XHEB b = null;
        public static XHEBlockquote blockquote = null;
        public static XHEHtml html = null;
        public static XHECode code = null;
        public static XHEVideo video = null;
        public static XHEI i = null;
        public static XHELi li = null;
        public static XHEMeta meta = null;
        public static XHEOption option = null;
        public static XHEP p = null;
        public static XHEPre pre = null;
        public static XHES s = null;
        public static XHEStrong strong = null;
        public static XHEU u = null;
        public static XHEHead head = null;
        public static XHEHeader header = null;
        public static XHEFooter footer = null;
        public static XHESection section = null;

        // create Dom (input) objects
        public static XHEInput input = null;
        public static XHEHiddenInput hiddeninput = null;
        public static XHEInputFile inputfile = null;
        public static XHETextArea textarea = null;
        public static XHECheckButton checkbox = null;
        public static XHERadioButton radiobox = null;
        public static XHEInputImage inputimage = null;
        public static XHEElement element = null;
        public static XHEFlash flash = null;
        public static XHEEmbed embed = null;
        public static XHEObject obj = null;

        #endregion

        #region initialization        

        // init XHE objects
        public static void InitXHE()
        {
            XHEScript _Script = new XHEScript();

            // check exist of element before action
            XHEBaseDOM.bWaitElementExistBeforeAction = false;
            // time of waiting for element appearing (second))
            XHEBaseDOM.iSecondsWaitElementExistBeforeAction = 15;

            // sms testing services 
            simnet = new XHE5Simnet(_Script, "");
            smsactivate = new XHESmsActivate(_Script, "");
            cheapsms = new XHECheapsms(_Script, "");

            // capcha testing services
            anticaptcha = new XHEAnticapcha("antigate.com", _Script);
            captcha24 = new XHECaptcha24("captcha24.com", _Script);
            rucaptcha = new XHERucapcha("rucaptcha.com", _Script);
            twocaptcha = new XHE2capcha("2captcha.com", _Script);
            ripcaptcha = new XHERipcaptcha("ripcaptcha.com", _Script);
            bypasscaptcha = new XHEBypasscaptcha(_Script);
            captchabot = new XHECaptchabot(_Script);

            // create Window objects
            app = new XHEApplication(server, password, _Script);
            windows = new XHEWindowsShell(server, password, _Script);
            window = new XHEWindow(server, password, _Script);
            mouse = new XHEMouse(server, password, _Script);

            // create System objects
            sound = new XHESound(server, password, _Script);
            debug = new XHEDebug(server, password, _Script);
            scheduler = new XHEScheduler(server, password, _Script);
            keyboard = new XHEKeyboard(server, password, _Script);
            clipboard = new XHEClipboard(server, password, _Script);
            textfile = new XHETextFile(server, password, _Script);
            file_os = new XHEFile_os(server, password, _Script);
            folder = new XHEFolder(server, password, _Script);

            // create Web objects
            browser = new XHEBrowser(server, password, _Script);
            webpage = new XHEWebPage(mouse, server, password, _Script);
            raw = new XHERaw(server, password, _Script);
            seo = new XHESEO(server, password, _Script);
            connection = new XHEConnection(server, password, _Script);
            mail = new XHEMail(server, password, _Script);
            ftp = new XHEFTP(server, password, _Script);
            sftp = new XHESFTP(server, password, _Script);
            submitter = new XHESubmitter(server, password, _Script);
            proxycheker = new XHEProxyCheker(server, password, _Script);
            harvestor = new XHEHarvestor(server, password, _Script);
            proxyswitcher = new XHEProxySwitcher(server, password, _Script);

            // create Dom (container) object
            frame = new XHEFrame(server, password, _Script);
            form = new XHEForm(server, password, _Script);
            body = new XHEBody(server, password, _Script);

            // create Dom (output) objects
            anchor = new XHEAnchor(server, password, _Script);
            image = new XHEImage(server, password, _Script);
            button = new XHEInputButton(server, password, _Script);
            div = new XHEDiv(server, password, _Script);
            style = new XHEStyle(server, password, _Script);
            span = new XHESpan(server, password, _Script);
            label = new XHELabel(server, password, _Script);
            td = new XHETD(server, password, _Script);
            tr = new XHETR(server, password, _Script);
            th = new XHETH(server, password, _Script);
            btn = new XHEButton(server, password, _Script);
            listbox = new XHESelectElement(server, password, _Script);
            script = new XHEScriptElement(server, password, _Script);
            table = new XHETable(server, password, _Script);
            h1 = new XHEH(server, 1, password, _Script);
            h2 = new XHEH(server, 2, password, _Script);
            h3 = new XHEH(server, 3, password, _Script);
            h4 = new XHEH(server, 4, password, _Script);
            h5 = new XHEH(server, 5, password, _Script);
            h6 = new XHEH(server, 6, password, _Script);
            b = new XHEB(server, password, _Script);
            blockquote = new XHEBlockquote(server, password, _Script);
            html = new XHEHtml(server, password, _Script);
            code = new XHECode(server, password, _Script);
            video = new XHEVideo(server, password, _Script);
            i = new XHEI(server, password, _Script);
            li = new XHELi(server, password, _Script);
            meta = new XHEMeta(server, password, _Script);
            option = new XHEOption(server, password, _Script);
            p = new XHEP(server, password, _Script);
            pre = new XHEPre(server, password, _Script);
            s = new XHES(server, password, _Script);
            strong = new XHEStrong(server, password, _Script);
            u = new XHEU(server, password, _Script);
            head = new XHEHead(server, password, _Script);
            header = new XHEHeader(server, password, _Script);
            footer = new XHEFooter(server, password, _Script);
            section = new XHESection(server, password, _Script);

            // create Dom (input) objects
            input = new XHEInput(server, password, _Script);
            hiddeninput = new XHEHiddenInput(server, password, _Script);
            inputfile = new XHEInputFile(server, password, _Script);
            textarea = new XHETextArea(server, password, _Script);
            checkbox = new XHECheckButton(server, password, _Script);
            radiobox = new XHERadioButton(server, password, _Script);
            inputimage = new XHEInputImage(server, password, _Script);
            element = new XHEElement(server, password, _Script);
            flash = new XHEFlash(server, password, _Script);
            embed = new XHEEmbed(server, password, _Script);
            obj = new XHEObject(server, password, _Script);

            // init anticaptcha serices
            image.InitAntiCaptchas(anticaptcha, rucaptcha, captcha24, ripcaptcha, bypasscaptcha, captchabot);
            // init intermedia objects (this need for all XHE objecta)
            image.AddIntermedaiObjects(mouse, browser);

            // test connection to XHE
            app.get_port();
        }        

        // constructor
        public XHEScript()
        {            
            // init XHE
            //InitXHE();            
        }

        // constructor with server and port
        public XHEScript(string _server = "127.0.0.1:7017", string _password = "")
        {
            // connection to XHE params
            server = _server;
            password = _password;

            // init XHE
            InitXHE();
        }

        // dispose
        public void Dispose()
        {
            // XHE server
            server = null;
            // XHE password
            password = null;

            // capcha testing services
            anticaptcha = null;
            captcha24 = null;
            rucaptcha = null;
            ripcaptcha = null;
            bypasscaptcha = null;
            captchabot = null;

            // create Window objects
            app = null;
            windows = null;
            window = null;
            mouse = null;

            // create System objects
            sound = null;
            debug = null;
            scheduler = null;
            keyboard = null;
            clipboard = null;
            textfile = null;
            file_os = null;
            folder = null;

            // create Web objects
            browser = null;
            webpage = null;
            raw = null;
            seo = null;
            connection = null;
            mail = null;
            ftp = null;
            sftp = null;
            submitter = null;
            proxycheker = null;
            harvestor = null;
            proxyswitcher = null;

            // create Dom (container) object
            frame = null;
            form = null;
            body = null;

            // create Dom (output) objects
            anchor = null;
            // remove anticaptcha serices
            image.InitAntiCaptchas(null, null, null, null, null, null);
            // remove intermedia objects
            image.RemoveIntermedaiObjects();
            image = null;
            button = null;
            div = null;
            style = null;
            span = null;
            label = null;
            td = null;
            tr = null;
            th = null;
            btn = null;
            listbox = null;
            script = null;
            table = null;
            h1 = null;
            h2 = null;
            h3 = null;
            h4 = null;
            h5 = null;
            h6 = null;
            b = null;
            blockquote = null;
            html = null;
            code = null;
            i = null;
            li = null;
            meta = null;
            option = null;
            p = null;
            pre = null;
            s = null;
            strong = null;
            u = null;
            head = null;
            header = null;
            footer = null;
            section = null;

            // create Dom (input) objects
            input = null;
            hiddeninput = null;
            inputfile = null;
            textarea = null;
            checkbox = null;
            radiobox = null;
            inputimage = null;
            element = null;
            flash = null;
            embed = null;
            obj = null;

            //Curl.GlobalCleanup();
        }

        #endregion

        #region helpers

        /// <summary>
        /// выход : закрыть связаный со скриптом хуман
        /// </summary>
        public void Exit()
        {
            app.exitapp();
        }

        /// <summary>
        /// разобрать
        /// </summary>
        /// <param name="sUrl">адресс разбора</param>
        /// <returns></returns>
        public string GetContent(string sUrl,int sleepAfter=-1,int waitSeconds=-1)
        {
            string content = "";

            // сделаем разбор
            try
            {                
                // установить паузу на ожидание
                if (waitSeconds > 0)
                    browser.set_wait_params(waitSeconds, 1);
                // перейдем                            
                browser.navigate(sUrl);
                if (sleepAfter != -1)
                    sleep(sleepAfter);

                // получить тело страницы
                content = webpage.get_body();
            }
            catch (Exception)
            {
            }

            return content;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XHE.XHE_DOM;
using XHE.XHE_System;
using XHE.XHE_Window;
using XHE.XHE_Web;

namespace XHE
{
    // class for use with multi XHE instance
    public class XHEScriptMulti : XHEScriptBase, IDisposable
    {
        #region XHE objects       

        // XHE server
        public string server = "127.0.0.1:7017";
        // XHE password
        public string password = "";

        // capcha testing services
        public XHEAnticapcha anticaptcha = null;
        public XHECaptcha24 captcha24 = null;
        public XHERucapcha rucaptcha = null;
        public XHERipcaptcha ripcaptcha = null;
        public XHEBypasscaptcha bypasscaptcha = null;
        public XHECaptchabot captchabot = null;

        // create Window objects
        public XHEApplication app = null;
        public XHEWindowsShell windows = null;
        public XHEWindow window = null;
        public XHEMouse mouse = null;

        // create System objects
        public XHESound sound = null;
        public XHEDebug debug = null;
        public XHEScheduler scheduler = null;
        public XHEKeyboard keyboard = null;
        public XHEClipboard clipboard = null;
        public XHETextFile textfile = null;
        public XHEFile_os file_os = null;
        public XHEFolder folder = null;

        // create Web objects
        public XHEBrowser browser = null;
        public XHEWebPage webpage = null;
        public XHERaw raw = null;
        public XHESEO seo = null;
        public XHEConnection connection = null;
        public XHEMail mail = null;
        public XHEFTP ftp = null;
        public XHESFTP sftp = null;
        public XHESubmitter submitter = null;
        public XHEProxyCheker proxycheker = null;
        public XHEHarvestor harvestor = null;
        public XHEProxySwitcher proxyswitcher = null;

        // create Dom (container) object
        public XHEFrame frame = null;
        public XHEForm form = null;
        public XHEBody body = null;

        // create Dom (output) objects
        public XHEAnchor anchor = null;
        public XHEImage image = null;
        public XHEInputButton button = null;
        public XHEDiv div = null;
        public XHEStyle style = null;
        public XHESpan span = null;
        public XHELabel label = null;
        public XHETD td = null;
        public XHETR tr = null;
        public XHETH th = null;
        public XHEButton btn = null;
        public XHESelectElement listbox = null;
        public XHEScriptElement script = null;
        public XHETable table = null;
        public XHEH h1 = null;
        public XHEH h2 = null;
        public XHEH h3 = null;
        public XHEH h4 = null;
        public XHEH h5 = null;
        public XHEH h6 = null;
        public XHEB b = null;
        public XHEBlockquote blockquote = null;
        public XHEHtml html = null;
        public XHECode code = null;
        public XHEVideo video = null;
        public XHEI i = null;
        public XHELi li = null;
        public XHEMeta meta = null;
        public XHEOption option = null;
        public XHEP p = null;
        public XHEPre pre = null;
        public XHES s = null;
        public XHEStrong strong = null;
        public XHEU u = null;
        public XHEHead head = null;
        public XHEHeader header = null;
        public XHEFooter footer = null;
        public XHESection section = null;

        // create Dom (input) objects
        public XHEInput input = null;
        public XHEHiddenInput hiddeninput = null;
        public XHEInputFile inputfile = null;
        public XHETextArea textarea = null;
        public XHECheckButton checkbox = null;
        public XHERadioButton radiobox = null;
        public XHEInputImage inputimage = null;
        public XHEElement element = null;
        public XHEFlash flash = null;
        public XHEEmbed embed = null;
        public XHEObject obj = null;

        #endregion

        #region initialization

        // init XHE objects
        public void InitXHE()
        {
            // check exist of element before action
            XHEBaseDOM.bWaitElementExistBeforeAction = false;
            // time of waiting for element appearing (second))
            XHEBaseDOM.iSecondsWaitElementExistBeforeAction = 15;
	        //Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

            // capcha testing services
            anticaptcha = new XHEAnticapcha("antigate.com",this);
            captcha24 = new XHECaptcha24("captcha24.com", this);
            rucaptcha = new XHERucapcha("rucaptcha.com", this);
            ripcaptcha = new XHERipcaptcha("ripcaptcha.com", this);
            bypasscaptcha = new XHEBypasscaptcha(this);
            captchabot = new XHECaptchabot(this);

            // create Window objects
            app = new XHEApplication(server, password, this);
            windows = new XHEWindowsShell(server, password, this);
            window = new XHEWindow(server, password, this);
            mouse = new XHEMouse(server, password, this);

            // create System objects
            sound = new XHESound(server, password, this);
            debug = new XHEDebug(server, password, this);
            scheduler = new XHEScheduler(server, password, this);
            keyboard = new XHEKeyboard(server, password, this);
            clipboard = new XHEClipboard(server, password, this);
            textfile = new XHETextFile(server, password, this);
            file_os = new XHEFile_os(server, password, this);
            folder = new XHEFolder(server, password, this);

            // create Web objects
            browser = new XHEBrowser(server, password, this);
            webpage = new XHEWebPage(mouse, server, password, this);
            raw = new XHERaw(server, password, this);
            seo = new XHESEO(server, password, this);
            connection = new XHEConnection(server, password, this);
            mail = new XHEMail(server, password, this);
            ftp = new XHEFTP(server, password, this);
            sftp = new XHESFTP(server, password, this);
            submitter = new XHESubmitter(server, password, this);
            proxycheker = new XHEProxyCheker(server, password, this);
            harvestor = new XHEHarvestor(server, password, this);
            proxyswitcher = new XHEProxySwitcher(server, password, this);

            // create Dom (container) object
            frame = new XHEFrame(server, password, this);
            form = new XHEForm(server, password, this);
            body = new XHEBody(server, password, this);

            // create Dom (output) objects
            anchor = new XHEAnchor(server, password, this);
            image = new XHEImage(server, password, this);
            button = new XHEInputButton(server, password, this);
            div = new XHEDiv(server, password, this);
            style = new XHEStyle(server, password, this);
            span = new XHESpan(server, password, this);
            label = new XHELabel(server, password, this);
            td = new XHETD(server, password, this);
            tr = new XHETR(server, password, this);
            th = new XHETH(server, password, this);
            btn = new XHEButton(server, password, this);
            listbox = new XHESelectElement(server, password, this);
            script = new XHEScriptElement(server, password, this);
            table = new XHETable(server, password, this);
            h1 = new XHEH(server, 1, password, this);
            h2 = new XHEH(server, 2, password, this);
            h3 = new XHEH(server, 3, password, this);
            h4 = new XHEH(server, 4, password, this);
            h5 = new XHEH(server, 5, password, this);
            h6 = new XHEH(server, 6, password, this);
            b = new XHEB(server, password, this);
            blockquote = new XHEBlockquote(server, password, this);
            html = new XHEHtml(server, password, this);
            code = new XHECode(server, password, this);
            i = new XHEI(server, password, this);
            li = new XHELi(server, password, this);
            meta = new XHEMeta(server, password, this);
            option = new XHEOption(server, password, this);
            p = new XHEP(server, password, this);
            pre = new XHEPre(server, password, this);
            s = new XHES(server, password, this);
            strong = new XHEStrong(server, password, this);
            u = new XHEU(server, password, this);
            head = new XHEHead(server, password, this);
            header = new XHEHeader(server, password, this);
            footer = new XHEFooter(server, password, this);
            section = new XHESection(server, password, this);

            // create Dom (input) objects
            input = new XHEInput(server, password, this);
            hiddeninput = new XHEHiddenInput(server, password, this);
            inputfile = new XHEInputFile(server, password, this);
            textarea = new XHETextArea(server, password, this);
            checkbox = new XHECheckButton(server, password, this);
            radiobox = new XHERadioButton(server, password, this);
            inputimage = new XHEInputImage(server, password, this);
            element = new XHEElement(server, password, this);
            flash = new XHEFlash(server, password, this);
            embed = new XHEEmbed(server, password, this);
            obj = new XHEObject(server, password, this);
            video = new XHEVideo(server, password, this);

            // init anticaptcha serices            
            image.InitAntiCaptchas(anticaptcha, rucaptcha, captcha24, ripcaptcha, bypasscaptcha, captchabot);

            // init intermedia objects (this need for all XHE objecta)            
            image.AddIntermedaiObjects(mouse, browser);

            // test connection to XHE
            app.get_port();
        }

        // constructor
        public XHEScriptMulti()
        {
            // init XHE
            InitXHE();
        }

        // constructor with server and port
        public XHEScriptMulti(string _server = "127.0.0.1:7017", string _password = "")
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
	        //Curl.GlobalCleanup();

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
        public string GetContent(string sUrl, int sleepAfter = -1, int waitSeconds=-1)
        {
            string content="";

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

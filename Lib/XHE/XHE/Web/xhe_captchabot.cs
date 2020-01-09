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
    /*
    class OCR 
    {
        var $url;
        var $host;
        var $id;
        function OCR(){
            $this->url          = "http://captchabot.com/rpc/xml.php";
            $this->host         = "captchabot.com";
            $this->SystemKey    = "";
        }
        function Recognize($file, $language=0){
            if(!file_exists($file)){
                return 200;
            }
            $contents=file_get_contents($file);
            if(!$contents){
                return 200;
            }
            $converted = base64_encode($contents);

            $request = "<methodCall><methodName>ocr_server::analyze</methodName><params>";
            $request.= "<param><base64>$converted</base64></param>";
            $request.= "<param><string>system_key</string></param>";
            $request.= "<param><string>".$this->SystemKey."</string></param>";
        $request.= "<param><int>\"124477\"</int></param>";
            $request.= "<param><int>".$language."</int></param>";
            $request.= "</params></methodCall>";
        
            return $this->Response($request);
        }

        function RecognizeExt($file, $symb=0, $case=0, $calc=0, $min=3, $max=30, $phrase=0){
            $s2='';
            $contents=file_get_contents($file);
            if(!$contents){
                return 200;
            }
            $converted=base64_encode($contents);

            $request="<methodCall><methodName>ocr_server::analyze</methodName><params>";
            $request.="<param><base64>$converted</base64></param>";
            $request.="<param><string>system_key</string></param>";
            $request.="<param><string>".$this->SystemKey."</string></param>";
            $request.="<param><int>0</int></param>";
            $request.="<param><int>".$symb."</int></param>";
            $request.="<param><int>".$case."</int></param>";
            $request.="<param><int>".$calc."</int></param>";
            $request.="<param><int>".$min."</int></param>";
            $request.="<param><int>".$max."</int></param>";
        $request.="<param><int>\"124477\"</int></param>";
            $request.="<param><int>".$phrase."</int></param>";	
            $request.="</params></methodCall>";

            return $this->Response($request);
        }

        function Response($request){
            $header[] = "Host: ".$this->host;
            $header[] = "MIME-Version: 1.0";
            $header[] = "Content-type: multipart/mixed; boundary=----doc";
            $header[] = "Accept: text/xml";
            $header[] = "Content-length: ".strlen($request);
            $header[] = "Cache-Control: no-cache";
            $header[] = "Connection: close \r\n";
            $header[] = $request;

            $ch = curl_init();
            curl_setopt($ch, CURLOPT_URL, $this->url);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
            curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
            curl_setopt($ch, CURLOPT_MAXREDIRS, 1);
            curl_setopt($ch, CURLOPT_TIMEOUT, 140);
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');
            curl_setopt($ch, CURLOPT_HTTPHEADER, $header);

            $data = curl_exec($ch);
            if(curl_errno($ch)){
                return "300";
            }
            $npos = strpos($data,"<string>");
            $s2 = '';
            if($npos){
                $start = $npos+strlen("<string>");
                $s1 = substr($data,$start);
                $npos = strpos($s1,"</string>");
                if($npos){
                    $s2 = substr($s1,0,$npos);
                }
            }
            $text = $s2;
            $npos = strpos($data,"<int>");
            if($npos){
                $start = $npos+strlen("<int>");
                $s1 = substr($data,$start);
                $npos = strpos($s1,"</int>");
                if($npos){
                    $s2 = substr($s1,0,$npos);
                }
            }
            $this->id = $s2;
            if($text == ''){
                $text = "Error - ".$s2;
            }
            return $text;
        }

        function Report($result){
            $request = "<methodCall><methodName>ocr_server::ver</methodName><params><param><string>";
            $request.= ($result)?"yes":"no";
            $request.= "</string></param><param><int>".$this->id."</int></param></params></methodCall>";

            $header[] = "Host: ".$this->host;
            $header[] = "MIME-Version: 1.0";
            $header[] = "Content-type: multipart/mixed; boundary=----doc";
            $header[] = "Accept: text/xml";
            $header[] = "Content-length: ".strlen($request);
            $header[] = "Cache-Control: no-cache";
            $header[] = "Connection: close \r\n";
            $header[] = $request;

            $ch = curl_init();
            curl_setopt($ch, CURLOPT_URL, $this->url);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
            curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
            curl_setopt($ch, CURLOPT_MAXREDIRS, 1);
            curl_setopt($ch, CURLOPT_TIMEOUT, 10);
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');
            curl_setopt($ch, CURLOPT_HTTPHEADER, $header);

            $data = curl_exec($ch);
            if(curl_errno($ch)){
                return false;
            }else{
                return true;
            }
        }

        function GetBalance(){
            $request = "<methodCall><methodName>ocr_server::balance</methodName><params>";
            $request.= "<param><string>system_key</string></param>";
            $request.= "<param><string>".$this->SystemKey."</string></param>";        
            $request.= "</params></methodCall>";

            $header[] = "Host: ".$this->host;
            $header[] = "MIME-Version: 1.0";
            $header[] = "Content-type: multipart/mixed; boundary=----doc";
            $header[] = "Accept: text/xml";
            $header[] = "Content-length: ".strlen($request);
            $header[] = "Cache-Control: no-cache";
            $header[] = "Connection: close \r\n";
            $header[] = $request;

            $ch = curl_init();
            curl_setopt($ch, CURLOPT_URL, $this->url);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
            curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
            curl_setopt($ch, CURLOPT_MAXREDIRS, 1);
            curl_setopt($ch, CURLOPT_TIMEOUT, 150);
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');
            curl_setopt($ch, CURLOPT_HTTPHEADER, $header);    
        
            $data = curl_exec($ch);
            if(curl_errno($ch)){
                return "300 - ".curl_error($ch);
            }
            $npos = strpos($data,"<double>");
              $s2="";
            if($npos){
                $start = $npos+strlen("<double>");
                $s1 = substr($data,$start);
                $npos = strpos($s1,"</double>");
                if($npos){
                    $s2 = substr($s1,0,$npos);
                }
            }
            $text = $s2;
            return $text;        
        }

        function GetLimit(){
            $request = "<methodCall><methodName>ocr_server::limit</methodName><params>";
            $request.= "<param><string>system_key</string></param>";
            $request.= "<param><string>".$this->SystemKey."</string></param>";
            $request.= "</params></methodCall>";

            $header[] = "Host: ".$this->host;
            $header[] = "MIME-Version: 1.0";
            $header[] = "Content-type: multipart/mixed; boundary=----doc";
            $header[] = "Accept: text/xml";
            $header[] = "Content-length: ".strlen($request);
            $header[] = "Cache-Control: no-cache";
            $header[] = "Connection: close \r\n";
            $header[] = $request;

            $ch = curl_init();
            curl_setopt($ch, CURLOPT_URL, $this->url);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
            curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
            curl_setopt($ch, CURLOPT_MAXREDIRS, 1);
            curl_setopt($ch, CURLOPT_TIMEOUT, 150);
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');
            curl_setopt($ch, CURLOPT_HTTPHEADER, $header);    
        
            $data = curl_exec($ch);
            if(curl_errno($ch)){
                return "300 - ".curl_error($ch);
            }
            $s2 = '';
            $npos = strpos($data, "<string>");
            if($npos){
                $start = $npos + strlen("<string>");
                $s1 = substr($data, $start);
                $npos = strpos($s1, "</string>");
                if($npos){
                    $s2 = substr($s1, 0, $npos);
                }
            }
            $text = $s2;
            return $text;
        }

        function GetLimitUsed(){
            $request = "<methodCall><methodName>ocr_server::limit</methodName><params>";
            $request.= "<param><string>system_key</string></param>";
            $request.= "<param><string>".$this->SystemKey."</string></param>";        
            $request.= "</params></methodCall>";

            $header[] = "Host: ".$this->host;
            $header[] = "MIME-Version: 1.0";
            $header[] = "Content-type: multipart/mixed; boundary=----doc";
            $header[] = "Accept: text/xml";
            $header[] = "Content-length: ".strlen($request);
            $header[] = "Cache-Control: no-cache";
            $header[] = "Connection: close \r\n";
            $header[] = $request;

            $ch = curl_init();
            curl_setopt($ch, CURLOPT_URL, $this->url);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
            curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
            curl_setopt($ch, CURLOPT_MAXREDIRS, 1);
            curl_setopt($ch, CURLOPT_TIMEOUT, 150);
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');
            curl_setopt($ch, CURLOPT_HTTPHEADER, $header);    
        
            $data = curl_exec($ch);
            if(curl_errno($ch)){
                return "300 - ".curl_error($ch);
            }
            $s2 = '';
            $npos = strripos($data,"<string>");
            if($npos){
                $start = $npos+strlen("<string>");
                $s1 = substr($data, $start);
                $npos = strripos($s1, "</string>");
                if($npos){
                    $s2 = substr($s1, 0, $npos);
                }
            }
            $text2 = $s2;
            return $text2;
        }
    }*/

    ////////////////////////////////////// Captchabot /////////////////////////////////////////////////
    public class XHECaptchabot
    {
        /*      ///////////////////////////////////////////////////////////////////////////////////////////

          var $url;
          var $host;
          var $id;
              // server address
          var $server;
          var $OCR;*/

        ///////////////////////////////////////////////////////////////////////////////////////////
        // скрипт
        protected XHEScriptBase _Script = null;

        // конструктор
        public XHECaptchabot(XHEScriptBase script)
        {
            _Script = script;
            //$this->oOCR=new OCR();
            //$this->oOCR->SystemKey="";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        // задать ключ сервиса
        public void set_system_key(string SystemKey)
        {
            //$this->oOCR->SystemKey=$SystemKey;
        }
        // распознать заданную капчу
        public string recognize(string file, int language = 0)
        {
            //return $this->oOCR->Recognize($file,$language);
            return "";
        }

        /*// получить идентификатор последней капчи
        function get_last_capcha_id()
        {
                return $this->oOCR->id;
        }


        // отрепортовать о результатах распознаниии 
        function report($result)
        {
            return $this->oOCR->report($result);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        // получить баланс
        function get_balance() 
            {
            return $this->oOCR->GetBalance();
        }
        // получить лимит
        function get_limit() 
            {
            return $this->oOCR->GetLimit();
        }	

        // получить использованый лимит
        function get_limit_used()
            {
            return $this->oOCR->GetLimitUsed();
        }		
        ///////////////////////////////////////////////////////////////////////////////////////////
         */
    };
}
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
    // $data is an array
    function bc_post_data($url, $data)
    {
        $ch = curl_init();
        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_HEADER, 0);
        curl_setopt($ch, CURLOPT_POST, 1);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, TRUE); 
        curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
        $ret = curl_exec($ch);
        curl_close($ch);
        return $ret;
    }

    // split fields
    function bc_split($data)
    {
        $ret = array();

        $lines = explode("\n", $data);
        if($lines)
        {
            foreach($lines as $line)
            {
                $x = trim($line);
                if(strlen($x) == 0) continue;

                $value = strstr($x, " ");
                $name = "";
                if($value === FALSE)
                {
                    $name = $x;
                    $value = "";
                }
                else
                {
                    $name = substr($x, 0, strlen($x) - strlen($value));
                    $value = trim($value);
                }
                $ret[$name] = $value;
            }
        }
        return $ret;
    }

    // return NULL if decode failed
    function bc_submit_captcha($key, $img_file_name)
    {
        global $bc_task_id;
        $bc_task_id = -1;

        // read image data of image
        $fp = fopen($img_file_name, "rb");
        if(!$fp) return NULL;
        $file_size = filesize($img_file_name);
        if($file_size <= 0) return NULL;
        $data = fread($fp, $file_size);
        fclose($fp);

        // use base64 encoding to encode it
        $enc_data = base64_encode($data);

        // submit it to server
        if(strlen($key) != 40 && strlen($key) != 32) return NULL;
        $data = bc_post_data("http://bypasscaptcha.com/upload.php",
                array( "key" => $key, "file" => $enc_data, "submit" => "Submit",
                            "gen_task_id" => 1, "base64_code" => 1 , "vendor_key" => "776823d5b52246dae6cf65a5c2a7b8620db2198c" ));

        // dict
        $dict = bc_split($data);

        if(array_key_exists("TaskId", $dict) && array_key_exists("Value", $dict))
        {
            $bc_task_id = $dict["TaskId"];
            return $dict["Value"];
        }
        return NULL;
    }

    // after using the captcha value, you can send the feedback
    function bc_submit_feedback($key, $is_input_correct)
    {
        global $bc_task_id;

        bc_post_data("http://bypasscaptcha.com/check_value.php",
                array( "key" => $key, "task_id" => $bc_task_id,
                            "cv" => ($is_input_correct ? 1 : 0),
                            "submit" => "Submit"));
    }

    // get left number
    function bc_get_left($key)
    {
        $ret = bc_post_data("http://bypasscaptcha.com/ex_left.php",
                array( "key" => $key ));
        $dict = bc_split($ret);
        return $dict['Left'];
    }*/

    ////////////////////////////////////// Captchabot /////////////////////////////////////////////////
    public class XHEBypasscaptcha
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        /*var $url;
        var $host;
        var $id;
            // server address
        var $server;
        var $key;

        // capcha file
        var $last_capcha_filename;
        // capcha reuslt
        var $last_capcha_result;*/
        // скрипт
        protected XHEScriptBase _Script = null;

        ///////////////////////////////////////////////////////////////////////////////////////////

        // конструктор
        public XHEBypasscaptcha(XHEScriptBase script)
        {
            _Script = script;
            //$this->key="";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        // задать ключ сервиса
        public void set_system_key(string key)
        {
            //$this->key=$key;
        }

        // распознать заданную капчу
        public string recognize(string file)
        {
            /*$this->last_capcha_filename=$file;
            $this->last_capcha_result=bc_submit_captcha( $this->key, $file );
            return $this->last_capcha_result;*/
            return "";
        }

        /*
            // отрепортовать о результатах распознаниии 
            function report($result)
            {
                return bc_submit_feedback($this->key,$result);
            }

            ///////////////////////////////////////////////////////////////////////////////////////////
            // получить идентификатор последней капчи
            function get_last_capcha_id()
            {
                global $bc_task_id;
                    return $bc_task_id;
            }
            // get last capcha file
            function get_last_capcha_filename()
            {
                    return $this->last_capcha_filename;
            }
            // get last capcha result
            function get_last_capcha_result()
            {
                    return $this->last_capcha_result;
            }
            // получить баланс
            function get_balance() 
                {
                return bc_get_left($this->key);
            }*/
        ///////////////////////////////////////////////////////////////////////////////////////////
    };
}
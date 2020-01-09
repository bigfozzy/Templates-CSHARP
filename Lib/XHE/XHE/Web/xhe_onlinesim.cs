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
    /////////////////////////////////////////// Seo ////////////////////////////////////////////////////
    public class XHEOnlineSIM : XHEBaseObject
    {
	public static string dev_key = "513747";
	public static string dev_id = "513747";
	public static string apikey;

	var $dev_key="513747";
	var $apikey="";

        /////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////
        // server initialization
        public XHEOnlineSIM(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = "onlinesim.ru/api";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////
	
	// аторизаци€ (получение ключа разработчика)
        public string login(string user,string password,string email)
	{
            string[,] aParams = new string[,] { { "user" , user }, {"password" , password } , { "email" , email } , { "dev_key" , dev_key } , { "dev_id" , dev_key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
		$params = array( "user" => $user , "password" => $password , "email" => $email , "dev_key" => $this->dev_key , "dev_id" => $this->dev_key );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// получение списка доступных сервисов
        public string getServiceList()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// запрос виртуального номера, создает операцию
	public string getNum(string service,string form="",string forward_number="",string forward_minutes="",string clean_call="",string simoperator="",string extension="",string region="")
	{
		$params = array( "apikey" => $this->apikey , "service" => $service , "form" => $form,"forward_number" => $forward_number,"forward_minutes" => $forward_minutes, "clean_call" => $clean_call, "simoperator" => $simoperator, "extension" => $extension,"region" => $region , "dev_key" => $this->dev_key , "dev_id" => $this->dev_key);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// подтверждает переадресацию
	public string setForwardStatusEnable(string tzid)
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// возвращает состо€ние выбранной операции
	public string getState(string tzid,string message_to_code="",string form="",string orderby="")
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid , "message_to_code" => $message_to_code , "form" => $form , "orderby" => $orderby);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// возвращает список и состо€ние всех операции.
	public string getOperations()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// cоздает запрос на уточнение ответа по операции.
	public string setOperationRevise(string tzid)
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// отправл€ет уведомление об успешном получении кода и завершает операцию
	public string setOperationOk($tzid)
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// возвращает информацию о состо€нии баланса.
	public string getBalance()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// получение списка сервисов дл€ повторного заказа —ћ—
	public string getService()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// получает список номеров дл€ указанного сервиса.
	public string getServiceNumber(string service)
	{
		$params = array( "apikey" => $this->apikey , "service" => $service);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// cоздает запрос на повторное использование виртуального номера
	public string getNumRepeat(string service,string number)
	{
		$params = array( "apikey" => $this->apikey , "service" => $service , "number" => $number);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// выводит список всех переадресаций
	public string forwardingList($id="",$page="",$sort="")
	{
		$params = array( "apikey" => $this->apikey , "id" => $id , "page" => $page , "sort" => $sort );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// измен€ет параметры переадресации
	public string forwardingSave(int id,int minutes="",string auto="",string forward_number="",string max_minutes="")
	{
		$params = array( "apikey" => $this->apikey , "id" => $id , "minutes" => $minutes , "auto" => $auto , "forward_number" => $forward_number, "max_minutes" => $max_minutes );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// удал€ет (выключает) переадресацию
	public string forwardingRemove(int id)
	{
		$params = array( "apikey" => $this->apikey , "id" => $id  );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// выводит список всех автоматических платежей
        public string getForwardPaymentsList(int id)
	{
		$params = array( "apikey" => $this->apikey , "id" => $id  );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}
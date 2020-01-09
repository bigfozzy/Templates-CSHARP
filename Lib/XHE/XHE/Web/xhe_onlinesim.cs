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
	
	// ���������� (��������� ����� ������������)
        public string login(string user,string password,string email)
	{
            string[,] aParams = new string[,] { { "user" , user }, {"password" , password } , { "email" , email } , { "dev_key" , dev_key } , { "dev_id" , dev_key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
		$params = array( "user" => $user , "password" => $password , "email" => $email , "dev_key" => $this->dev_key , "dev_id" => $this->dev_key );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ��������� ������ ��������� ��������
        public string getServiceList()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ������ ������������ ������, ������� ��������
	public string getNum(string service,string form="",string forward_number="",string forward_minutes="",string clean_call="",string simoperator="",string extension="",string region="")
	{
		$params = array( "apikey" => $this->apikey , "service" => $service , "form" => $form,"forward_number" => $forward_number,"forward_minutes" => $forward_minutes, "clean_call" => $clean_call, "simoperator" => $simoperator, "extension" => $extension,"region" => $region , "dev_key" => $this->dev_key , "dev_id" => $this->dev_key);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ������������ �������������
	public string setForwardStatusEnable(string tzid)
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ���������� ��������� ��������� ��������
	public string getState(string tzid,string message_to_code="",string form="",string orderby="")
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid , "message_to_code" => $message_to_code , "form" => $form , "orderby" => $orderby);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ���������� ������ � ��������� ���� ��������.
	public string getOperations()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// c������ ������ �� ��������� ������ �� ��������.
	public string setOperationRevise(string tzid)
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ���������� ����������� �� �������� ��������� ���� � ��������� ��������
	public string setOperationOk($tzid)
	{
		$params = array( "apikey" => $this->apikey , "tzid" => $tzid );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ���������� ���������� � ��������� �������.
	public string getBalance()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ��������� ������ �������� ��� ���������� ������ ���
	public string getService()
	{
		$params = array( "apikey" => $this->apikey );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// �������� ������ ������� ��� ���������� �������.
	public string getServiceNumber(string service)
	{
		$params = array( "apikey" => $this->apikey , "service" => $service);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// c������ ������ �� ��������� ������������� ������������ ������
	public string getNumRepeat(string service,string number)
	{
		$params = array( "apikey" => $this->apikey , "service" => $service , "number" => $number);
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ������� ������ ���� �������������
	public string forwardingList($id="",$page="",$sort="")
	{
		$params = array( "apikey" => $this->apikey , "id" => $id , "page" => $page , "sort" => $sort );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// �������� ��������� �������������
	public string forwardingSave(int id,int minutes="",string auto="",string forward_number="",string max_minutes="")
	{
		$params = array( "apikey" => $this->apikey , "id" => $id , "minutes" => $minutes , "auto" => $auto , "forward_number" => $forward_number, "max_minutes" => $max_minutes );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ������� (���������) �������������
	public string forwardingRemove(int id)
	{
		$params = array( "apikey" => $this->apikey , "id" => $id  );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}
	// ������� ������ ���� �������������� ��������
        public string getForwardPaymentsList(int id)
	{
		$params = array( "apikey" => $this->apikey , "id" => $id  );
	    	$res=$this->call_get(__FUNCTION__.".php",$params,$this->timeout);
		return json_decode($res,JSON_UNESCAPED_UNICODE);
	}

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////////////// Scheduler /////////////////////////////////////////////////
    public class XHEScheduler : XHEBaseObject
    {
        ////////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        public XHEScheduler(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Scheduler";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // получить число задач
        public int get_count()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // удалить задачу
        public bool delete(int num_task)
        {
            string[,] aParams = new string[,] { { "num_task", num_task.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить все задачи
        public bool delete_all()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // добавить задачу
        public bool add(string path,int type=0, string date="", string time= "", int count=-1,bool active=true,string comments="",string add_params="")
        {
            DateTime dateD = DateTime.Parse(date);
            DateTime timeT = DateTime.Parse(time);
            string[,] aParams = new string[,] { { "path", path }, { "type", type.ToString() }, { "year", dateD.Year.ToString() },{ "month", dateD.Month.ToString() },{ "day", dateD.Day.ToString() }
                ,{ "hour", timeT.Hour.ToString() }, { "minute", timeT.Minute.ToString() },{ "hour", timeT.Second.ToString() },
                { "count", count.ToString() }, { "active", active.ToString() }, { "comments", comments } , { "add_params", add_params }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // изменить задачу
        public bool edit(int num_task,string path, int type = 0, string date = "", string time = "", int count = -1, bool active = true, string comments="",string add_params="")
        {
            DateTime dateD = DateTime.Parse(date);
            DateTime timeT = DateTime.Parse(time);
            string[,] aParams = new string[,] { { "num_task", num_task.ToString() }, { "path", path }, { "type", type.ToString() },{ "year", dateD.Year.ToString() },{ "month", dateD.Month.ToString() },{ "day", dateD.Day.ToString() }
                ,{ "hour", timeT.Hour.ToString() }, { "minute", timeT.Minute.ToString() },{ "hour", timeT.Second.ToString() }, { "count", count.ToString() }, { "active", active.ToString() }, { "comments", comments } , { "add_params", add_params }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить задачу
        public bool get(int num_task, ref string path, ref int type, ref string date, ref string time, ref int count, ref bool active, ref string comments, ref string add_params)
        {
            string[,] aParams = new string[,] { { "num_task", num_task.ToString() }};
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res=="false")
                return false;
            else 
            {
                char[] separator = new char[] { '\v' };
                string[] aRes = res.Split(separator);
                if (aRes.Length>0)
                {
                    path = aRes[0].Trim();
                    type = Convert.ToInt32(aRes[1].Trim());
                    date = aRes[2].Trim();
                    time = aRes[3].Trim();
                    count = Convert.ToInt32(aRes[4].Trim());
                    if (aRes[5].Trim() == "")
                        active = false;
                    else
                        if (aRes[5].Trim() == "1")
                            active = true;
                    comments = aRes[6].Trim();
                    add_params = aRes[7].Trim();
                    return false;
                }
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
    
        // активировать задачу
        public bool activate(int num_task,bool activate=true)
        {
            string[,] aParams = new string[,] { { "num_task", num_task.ToString() }, { "activate", activate.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // активировать все задачи
        public bool activate_all(bool activate = true)
        {
            string[,] aParams = new string[,] { { "activate", activate.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // принудительно завершать текущий скрипт
        public bool kill_current_script(bool kill)
        {
            string[,] aParams = new string[,] { { "kill", kill.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
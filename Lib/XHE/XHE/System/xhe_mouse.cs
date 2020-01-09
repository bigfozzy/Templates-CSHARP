using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_System
{
    /////////////////////////////////////////////// Mouse ///////////////////////////////////////////////////////
    public class XHEMouse : XHEBaseObject
    {
        //////////////////////////////// SERVICVE VARIABLES /////////////////////////////////////////////////
        // temporary
        private int x;
        private int y;
        //////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////
        // server initialization
        public XHEMouse(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Mouse";            
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // сэмулировать щелчок левой кнопки мыши в заданной точке
        public bool click(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // щелкнуть мышью в координатах экрана
        public bool click_to_screen(int x = -1, int y = -1)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сэмулировать двойной щелчок левой кнопки мыши
        public bool double_click(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сэмулировать нажатие на левую кнопку мыши
        public bool left_button_down(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сэмулировать отпускание левой кнопки мыши
        public bool left_button_up(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // сэмулировать нажатие на правую кнопку мыши
        public bool right_button_click(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
   	// сэмулировать нажатие на правую кнопку мыши в координатах десктопа
   	public bool right_button_click_to_screen(int x=-1,int y=-1)
   	{
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
        // сэмулировать отпускание правой кнопки мыши
        public bool right_button_down(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сэмулировать щелчок правой кнопки мыши в заданной точке
        public bool right_button_up(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // передвинуть мышь в заданные координаты браузера
        public bool move(int x, int y, bool scroll = true, int time = 0, int tremble = 2)
        {
            if (time == 0)
            {
                string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            else
            {
                double xc = get_x(true);
                double yc = get_y(true);
		if (scroll)
		{
		        double sc_x=GetBrowser().get_horizontal_scroll_pos();
		        double sc_y= GetBrowser().get_vertical_scroll_pos();
		        xc+=sc_x;
		        yc+=sc_y;
		}
                double StepX = (x - xc - 0.0001) / time / 30;
                double StepY = (y - yc - 0.0001) / time / 30;
                double prevRandX = 0;
                double prevRandY = 0;
                for (int i = 0; i < 30 * time - 1; i++)
                {                    
                    xc += StepX - prevRandX;
                    yc += StepY - prevRandY;
                    prevRandX=new Random().Next(-tremble,tremble);
                    prevRandY = new Random().Next(-tremble, tremble);
                    string[,] aParams = new string[,] { { "x", xc.ToString() }, { "y", yc.ToString() }, { "scroll", scroll.ToString() } };
                    call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
                    Thread.Sleep(20);
                }
                string[,] aParams1 = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams1);
            }
        }
        // переместить мышь по экрану
        public bool move_on_screen(int x, int y, int time = 0, int tremble = 2)
        {
            if (time == 0)
            {
                string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            else
            {
                double xc = get_x();
                double yc = get_y();
                double StepX = (x - xc - 0.0001) / time / 30;
                double StepY = (y - yc - 0.0001) / time / 30;
                double prevRandX = 0; int prevRandY = 0;
                for (int i = 0; i < 30 * time - 1; i++)
                {
                    xc += StepX - prevRandX;
                    yc += StepY - prevRandY;
                    prevRandX=new Random().Next(-tremble,tremble);
                    prevRandY=new Random().Next(-tremble,tremble);
                    string[,] aParams = new string[,] { { "x", xc.ToString() }, { "y", yc.ToString() } };
                    call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
                    Thread.Sleep(20);
                }
                string[,] aParams1 = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams1);
            }
        }
        // управление колесиком мыши 
        public bool wheel(int time, int x, int y)
        {
            string[,] aParams = new string[,] { { "time", time.ToString() }, { "x", x.ToString() }, { "y", y.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // перемещение мыши по траектории
        public bool move_to(int x, int y, string type_, int time )
        {
            string[,] aParams = new string[,] { { "time", time.ToString() }, { "x", x.ToString() }, { "y", y.ToString() } , { "type", type_.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // отправить щелчок левой кнопки мыши в заданной точке
        public bool send_click(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отправить двойной щелчок левой кнопкой мыши в заданной точке
        public bool send_double_click(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отправить нажатие на левую кнопку мыши
        public bool send_left_button_down(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отправить отпускание левой кнопки мыши
        public bool send_left_button_up(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // отправить щелчок правой кнопки мыши в заданной точке
        public bool send_right_button_click(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отправить нажатие на правую кнопку мыши
        public bool send_right_button_down(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отправить отпускание правой кнопки мыши
        public bool send_right_button_up(int x = -1, int y = -1, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // отправить перемещение мыши в заданную точку
        public bool send_move(int x, int y, bool scroll = true, int time = 0, int tremble = 5, string buttons = "" )
        {
            if (time == 0)
            {
                string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } , { "buttons", buttons } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            else
            {
                double xc = get_x(true,true);
                double yc = get_y(true,true);
		if (scroll)
		{
		        double sc_x= GetBrowser().get_horizontal_scroll_pos();
		        double sc_y= GetBrowser().get_vertical_scroll_pos();
		        xc+=sc_x;
		        yc+=sc_y;
		}
                double StepX = (x - xc - 0.0001) / time / 50;
                double StepY = (y - yc - 0.0001) / time / 50;
                double prevRandX = 0; int prevRandY = 0;
                for (int i = 0; i < 50 * time - 1; i++)
                {
                    xc += StepX - prevRandX;
                    yc += StepY - prevRandY;
                    prevRandX=new Random().Next(-tremble,tremble);
                    prevRandY = new Random().Next(-tremble, tremble);
                    string[,] aParams = new string[,] { { "x", xc.ToString() }, { "y", yc.ToString() }, { "scroll", scroll.ToString() } };
                    call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
                    Thread.Sleep(20);
                }
                string[,] aParams1 = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "scroll", scroll.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams1);
            }
        }
        // отправить прокрутку колеса мыши
        public bool send_wheel(int n, int x = 1200, int y = 600, int key = 0)
        {
            string[,] aParams = new string[,] { { "n", n.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, { "key", key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // виртуальное перемещение мыши по траектории
        public bool send_move_to(int x, int y, string type_, int time)
        {
            string[,] aParams = new string[,] { { "time", time.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, { "type", type_.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
   	// отправить касание пальцев
   	public bool send_touch(int id,int touch_type,int x,int y,int radiusX=0,int radiusY=0,float rotationAngle=0,float pressure=0,int modiefiers=0,int pointerType=0)
   	{
		string[,] aParams = new string[,] { { "id", id.ToString() }, { "touch_type", touch_type.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, 
				{ "radiusX", radiusX.ToString() }, { "radiusY", radiusY.ToString() }, { "rotationAngle", rotationAngle.ToString() }, { "pressure", pressure.ToString() }, { "modiefiers", modiefiers.ToString() }, { "pointerType", pointerType.ToString() } };
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}
   	// отправить касание пальцев по траектории
   	public bool send_touch_to(int x0,int y0,int x,int y, string type_, int time_ )
   	{
		string[,] aParams = new string[,] { { "x0" , x0.ToString() } , { "y0" , y0.ToString() } , { "x" , x.ToString() } , { "y" , y.ToString() } , { "type_" , type_ } , { "time_" , time_.ToString() }};
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить Х и Y положение курсора мыши
        public string get_position(bool in_browser = false,bool is_virtual=false)
        {
            string[,] aParams = new string[,] { { "in_browser", in_browser.ToString() } , { "virtual", is_virtual.ToString() }  };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            int pos = res.IndexOf(' ');
            x = Convert.ToInt32(res.Substring(pos));
            y = Convert.ToInt32(res.Substring(pos + 1));
            return res;
        }

        // получить Х положение курсора мыши
        public int get_x(bool in_browser = false,bool is_virtual=false)
        {
            string[,] aParams = new string[,] { { "in_browser", in_browser.ToString() } , { "virtual", is_virtual.ToString() }  };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить Y положение курсора мыши
        public int get_y(bool in_browser = false,bool is_virtual=false)
        {
            string[,] aParams = new string[,] { { "in_browser", in_browser.ToString() } , { "virtual", is_virtual.ToString() }  };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // отправить событие клика левой кнопки мыши во flash проигрыватель
        public bool send_click_to_flash_player(int x, int y, int flash_num, bool bUseFlashXY = false, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "flash_num", flash_num.ToString() }, { "bUseFlashXY", bUseFlashXY.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отправить событие клика правой кнопки мыши во flash проигрыватель
        public bool send_right_click_to_flash_player(int x, int y, int flash_num, bool bUseFlashXY = false, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "flash_num", flash_num.ToString() }, { "bUseFlashXY", bUseFlashXY.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // отправить событие движения курсора мыши во flash проигрыватель
        public bool send_mouse_move_to_flash_player(int x, int y, int flash_num, bool bUseFlashXY = false, bool scroll = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "flash_num", flash_num.ToString() }, { "bUseFlashXY", bUseFlashXY.ToString() }, { "scroll", scroll.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить Х и Y координаты во flash проигрывателе по координатам в браузере или по текущему положению курсора в браузере
        public string get_mouse_pos_to_flash_player(int flash_num, int x = 0, int y = 0)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "flash_num", flash_num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}
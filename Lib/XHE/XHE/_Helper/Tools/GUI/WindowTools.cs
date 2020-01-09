using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Common.Tools.String;
using IfacesEnumsStructsClasses;

namespace Xedant_Human_Emulator.Common.Tools.GUI
{
    // работа с окнами винды
    public class WindowTools
    {
        #region Win32

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
        
        [DllImport("coredll.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount); 
        
        public const int GW_CHILD = 5;
        public const int GW_OWNER = 4;    
        public const int GW_HWNDNEXT = 2;    
        public const int GW_HWNDFIRST = 0;

        #endregion

        #region вспомогательные

        // получить HWND по номеру
        static public IntPtr GetHwndByNumber(int iNumber,bool bOnlyVisible,bool bOnlyMain)
        {
            int iCount=0;
            
            IntPtr wnd = GetWindow(Main.m_mainForm.Handle, GW_HWNDFIRST);
            for (; wnd != new IntPtr(0); wnd = GetWindow(wnd, GW_HWNDNEXT))
            {	
                // проверка на видимое
                if(bOnlyVisible &&  !IsWindowVisible(wnd) )
                    continue;
                // проверка что главное
                if(bOnlyMain && GetWindow(wnd,GW_OWNER)!= new IntPtr(0) )
                    continue;

                // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
                if (GetWindowText(wnd, sb, 4999) <= 0)
                    continue;
                
                if (iCount == iNumber)
                    return wnd;

                iCount++;
            }

            return new IntPtr(0);
        }
        // получить номер по HWND
        public static int GetNumberByHwnd(IntPtr hWnd,bool bOnlyVisible,bool bOnlyMain)
        {
	        int iCount=0;
	        
            IntPtr wnd = GetWindow(Main.m_mainForm.Handle, GW_HWNDFIRST);
            for (; wnd != new IntPtr(0); wnd = GetWindow(wnd, GW_HWNDNEXT))
	        {	
		        // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;
		        // проверка что главное
		        if(bOnlyMain && GetWindow(wnd,GW_OWNER)!=new  IntPtr(0) )
			        continue;		

	            // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
                if (GetWindowText(wnd, sb, 4999) <= 0)
                    continue;

		        if (wnd==hWnd)
			        return iCount;

		        iCount++;
	        }

	        return -1;
        }

        #endregion

        #region информационные

        // получить число видимых окон
        public static int GetCount(bool bOnlyVisible,bool bOnlyMain)
        {
	        int iCount=0;
            IntPtr wnd = GetWindow(Main.m_mainForm.Handle, GW_HWNDFIRST);
            for (; wnd != new IntPtr(0); wnd = GetWindow(wnd, GW_HWNDNEXT))
	        {
		        // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;
		        // проверка что главное
                if (bOnlyMain && GetWindow(wnd, GW_OWNER) != new IntPtr(0))
			        continue;		
		        // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
	            if( GetWindowText(wnd,sb,4999)<=0 )
			        continue;

		        iCount++;
	        }

	        return iCount;
        }
        // получить текст всех видимых главных окон
        public static string GetAllTexts(bool bOnlyVisible,bool bOnlyMain)
        {
	        // результат
	        string sRes="No visible window<br>";

	        // найдем все главные окна
	        int i=0;
	        IntPtr wnd = GetWindow(Main.m_mainForm.Handle, GW_HWNDFIRST);
            for (; wnd != new IntPtr(0); wnd = GetWindow(wnd, GW_HWNDNEXT))
	        {	
		        // нашли хоть одно - значит будет реузльтат
		        if (i==0)
		        {
			        sRes="";
			        i=1;
		        }
		        
	            // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;
		        // проверка что главное
                if (bOnlyMain && GetWindow(wnd, GW_OWNER) != new IntPtr(0))
			        continue;		
		        // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
	            if( GetWindowText(wnd,sb,4999)<=0 )
			        continue;
                sRes += sb.ToString()+ "<br>";
	        }

	        // результат
	        return sRes;
        }
        // получить текст окна по номеру
        public static string GetTextByNumber(int iNumber,bool bOnlyVisible,bool bOnlyMain)
        {
	        // получим окно
	        string sRes="NA";
	        IntPtr hWnd=GetHwndByNumber(iNumber,bOnlyVisible,bOnlyMain);
	        if (hWnd==new IntPtr(0))
		        return sRes;
        	
	        // получим текст
            StringBuilder sb = new StringBuilder(4999 + 1);
            if( GetWindowText(hWnd,sb,4999)<=0 )
		        return sRes;
            else 
                return sb.ToString();
        }
        // получить число дочерних окон
        public static int GetChildCountByNumber(int iNumber,bool bOnlyVisible,bool bOnlyMain)
        {
            int iCount=0;
	        IntPtr hWnd=GetHwndByNumber(iNumber,bOnlyVisible,bOnlyMain);
	        if (hWnd==new IntPtr(0))
		        return -1;

	        IntPtr wnd = GetWindow(hWnd,GW_CHILD);
	        for(;wnd!=new IntPtr(0);wnd = GetWindow(wnd,GW_HWNDNEXT))
	        {	
		        // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;

		        iCount++;
	        }

	        return iCount;
        }
        // получить текст в дочерних окнах
        public static string GetAllChildTextsByNumber(int iNumber,bool bOnlyVisible,bool bOnlyMain)
        {
	        // результат
	        string sRes="No visible window<br>";

            // получим окно по номеру
	        IntPtr hWnd=GetHwndByNumber(iNumber,bOnlyVisible,bOnlyMain);
	        if (hWnd==new IntPtr(0))
		        return sRes;

            // получим в нем все дочерие окна и их тексты
	        IntPtr wnd = GetWindow(hWnd,GW_CHILD);
	        for(;wnd!=new IntPtr(0);wnd = GetWindow(wnd,GW_HWNDNEXT))
	        {	
		        // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;

		        // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
                if( GetWindowText(wnd,sb,4999)<=0 )
			        continue;

		        if (sRes=="No visible window<br>")
			        sRes=sb+"<br>";
		        else
			        sRes+=sb+"<br>";
	        }

	        return sRes;
        }
        // получить номер по тексту окна
        public static int GetNumberByText(string sText,bool bExactly,bool bOnlyVisible,bool bOnlyMain)
        {
	        int iNum=-1;

            // найдем все главные окна            
            IntPtr wnd = GetWindow(Main.m_mainForm.Handle, GW_HWNDFIRST);
            for(;wnd!=new IntPtr(0);wnd = GetWindow(wnd,GW_HWNDNEXT))
            {			
                // проверка на видимое
                if(bOnlyVisible && !IsWindowVisible(wnd) )
                    continue;
                // проверка что главное
                if(bOnlyMain && GetWindow(wnd,GW_OWNER)!=new IntPtr(0) )
                    continue;		
                // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
                if( GetWindowText(wnd,sb,4999)<=0 )
			        continue;
                
                iNum++;
                if (StringTools.CompareString(sb.ToString(),sText,bExactly))
                    return iNum;                
            }

            // результат
	        return -1;
        }
        
        #endregion

        #region управляющие

        // послать сообщение окну
        public static int SendMessageByNumber(int iNumber,int lMessage,long wParam,long lParam,bool bOnlyVisible,bool bOnlyMain)
        {
	        IntPtr hWnd=GetHwndByNumber(iNumber,bOnlyVisible,bOnlyMain);
	        if (hWnd==new IntPtr(0))
		        return -1;

	        return SendMessage(hWnd,lMessage,new IntPtr(wParam), new IntPtr(lParam)).ToInt32();
           
        }
        // нажать кнопку в окне
        public static bool PressButtonByTextInWindowByNumber(int iNumber,string sText,bool bExactly,bool bOnlyVisible,bool bOnlyMain)
        {
	        IntPtr hWnd=GetHwndByNumber(iNumber,bOnlyVisible,bOnlyMain);
	        if (hWnd==new IntPtr(0))
		        return false;

	        IntPtr wnd = GetWindow(hWnd,GW_CHILD);
	        for(;wnd!=new IntPtr(0);wnd = GetWindow(wnd,GW_HWNDNEXT))
	        {	
		        // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;
        		
	            // получим класс окна
                StringBuilder ClassName = new StringBuilder(100);
                GetClassName(hWnd, ClassName, ClassName.Capacity);
                if (ClassName.ToString() != "Button")
			        continue;

                // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
                if( GetWindowText(wnd,sb,4999)<=0 )
			        continue;

                if (StringTools.CompareString(sb.ToString(),sText,bExactly))
                {
				        SetForegroundWindow(hWnd);
                        SendMessage(wnd, WindowsMessages.WM_KEYDOWN, new IntPtr(32), new IntPtr(0));
				        Thread.Sleep(200);
                        SendMessage(wnd, WindowsMessages.WM_KEYDOWN, new IntPtr(32), new IntPtr(0));                    
                }
	        }

	        return false;
        }
        // ввести текст в окне по ntrcne заголовка окна
        public static bool SetWindowTextByNumberInWindowByNumber(int iNumber,int iChildNumber,string sText,bool bOnlyVisible,bool bOnlyMain)
        {
	        IntPtr hWnd=GetHwndByNumber(iNumber,bOnlyVisible,bOnlyMain);
	        if (hWnd==IntPtr.Zero)
		        return false;

	        IntPtr wnd = GetWindow(hWnd,GW_CHILD);
	        int iNum=-1;
	        for(;wnd!=IntPtr.Zero;wnd = GetWindow(wnd,GW_HWNDNEXT))
	        {	
		        // проверка на видимое
		        if(bOnlyVisible && !IsWindowVisible(wnd) )
			        continue;
        		
	            // получим класс окна
                StringBuilder ClassName = new StringBuilder(100);
                GetClassName(hWnd, ClassName, ClassName.Capacity);

                // получим текст
                StringBuilder sb = new StringBuilder(4999 + 1);
                if( GetWindowText(wnd,sb,4999)<=0 )
			        continue;

		        iNum++;
		        if (iNum!=iChildNumber)
			        continue;

		        SetForegroundWindow(hWnd);
		        SetWindowText(wnd,sText);
		        return true;	
	        }

	        return false;
        }

        #endregion
    }
}

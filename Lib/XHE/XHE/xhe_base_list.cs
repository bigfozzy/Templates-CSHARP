using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE.XHE_DOM;
using System.Collections.Generic;

namespace XHE
{
    public class XHEBaseList:XHEBaseObject
    {
	    /////////////////////////////////////// SERVICE VARIABLES ///////////////////////////////////////////
	    // inner number
        public string inner_numbers;
        /// interfaces
        protected List<XHEBaseInterface> elements=new List<XHEBaseInterface>();
	    /////////////////////////////////////// SERVICE FUNCTIONS ///////////////////////////////////////////
	    // server initialization
        public XHEBaseList(string inner_numbers, string server, string password = ""):base(server, password )
	    {    
		    this.inner_numbers = inner_numbers;
		    m_Server = server;
		    m_Password = password;
	    }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить число элементов
        public int get_count()
   	    {
		    return elements.Count;
   	    }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
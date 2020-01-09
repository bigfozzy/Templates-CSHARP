#region using

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using XHE;
using XHE.XHE_DOM;
using XHE.XHE_System;
using XHE.XHE_Window;
using XHE.XHE_Web;

#endregion

 class MyScript:XHEScript
 {
	  static void Main(string[] args)
	  {			
			// init XHE
			server = "127.0.0.1:7010";
			InitXHE();

			[[SELECTED]]

			// exit
			app.quit();            
	  }
}
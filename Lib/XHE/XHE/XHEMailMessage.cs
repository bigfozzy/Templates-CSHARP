namespace XHE
{
    public class XHEMailMessage
    {
        public string from="";
		public string subject="";
		public string date="";
		public string body="";
		public string text_body="";

	    //  initialization
	    public XHEMailMessage(string content)
	    {    
		    if (content!="")
		    {			
			    string[] vars=content.Split(new string[] { "#@#@@!@@#@#" },System.StringSplitOptions.RemoveEmptyEntries);
                if (vars.Length > 4)
                {
                    this.from = vars[0];
                    this.subject = vars[1];
                    this.date = vars[2];
                    this.body = vars[3];
                    this.text_body = vars[4];
                }
		    }
	    }
    }
}

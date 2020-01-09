using System;
using System.Collections.Generic;
using System.Text;

namespace XHE._Helper.Tools.Web.Mail
{
    public class SmtpClientException : Exception
    {
        private string errorMessage = "";

        public SmtpClientException(string error_message)
        {
            this.errorMessage = error_message;
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Case
{
    /// <summary>
    /// Summary description for Case
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://localhost:65275//Case")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Case : System.Web.Services.WebService
    {
        private const string logFile = "C:\\SOA_A3\\Case.txt";

        [WebMethod]
        public string CaseConvert(string incoming, uint flag)
        {
            myLogging.Write(logFile, "CaseConvert() was called. Parameter value(s): " + incoming + ", " + flag);
            string toReturn = "";

            if (flag == 1)
            {
                toReturn = incoming.ToUpper();
            }
            else if (flag == 2)
            {
                toReturn = incoming.ToLower();
            }

            return toReturn;
        }
    }
}

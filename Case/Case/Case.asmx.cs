using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Case
{
    /// <summary>
    /// Summary description for Case
    /// </summary>

    //If you want to run it from VS:
    //[WebService(Namespace = "http://localhost:65275//Case")]
    //If you want to publish it:
    [WebService(Namespace = "http://localhost//TextService")]
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
            else
            {
                //throw soap fault: Invalid value for parameter: flag
                myLogging.Write(logFile, "**ERROR**: Invalid value for parameter 'flag'");

            }

            return toReturn;
        }
    }
}

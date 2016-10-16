using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Case
{
    /// <summary>
    /// Summary description for Case
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Case : System.Web.Services.WebService
    {

        [WebMethod]
        public string CaseConvert(string incoming, uint flag)
        {
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

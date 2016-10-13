using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Case
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Case" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Case.svc or Case.svc.cs at the Solution Explorer and start debugging.
    public class Case : ICase
    {
        public string CaseConvert(string incomming, uint flag)
        {
            string toReturn = "";

            if (flag == 1)
            {

            }
            else if (flag == 2)
            {
                //test
                toReturn = incomming.ToUpper();
            }
            else
            {
                toReturn = incomming.ToLower();
            }
            return toReturn;
        }
    }
}
